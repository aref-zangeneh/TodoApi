using Microsoft.AspNetCore.Mvc;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers
{
    public class TodoTaskController : Controller
    {
        private readonly HttpClient _httpClient;

        public TodoTaskController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("TodoApi");
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _httpClient.GetFromJsonAsync<List<TodoTaskViewModel>>("tasks");
            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoTaskViewModel task)
        {
            task.Id = Guid.NewGuid();
            task.IsCompleted = false;

            var response = await _httpClient.PostAsJsonAsync("https://localhost:8001/api/tasks", task);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating task.");
            var tasks = await _httpClient.GetFromJsonAsync<List<TodoTaskViewModel>>("https://localhost:5001/api/tasks");
            return View("Index", tasks);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var task = await _httpClient.GetFromJsonAsync<TodoTaskViewModel>($"https://localhost:8001/api/tasks/{id}");
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TodoTaskViewModel task)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:8001/api/tasks/{task.Id}", task);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "updating task was failed");
            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:8001/api/tasks/{id}");
            return RedirectToAction("Index");
        }


    }
}
