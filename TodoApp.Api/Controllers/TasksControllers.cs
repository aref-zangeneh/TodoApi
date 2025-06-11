using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Interfaces.Services.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    #region Fields

    private readonly ITaskService _taskService;

    #endregion

    #region Ctor

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    #endregion

    #region Endpoints Methods
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TodoTask task)
    {
        if (task == null)
        {
            return BadRequest("Task cannot be null");
        }
        var createdTask = await _taskService.CreateTaskAsync(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TodoTask task)
    {
        if (task == null || !task.Id.Equals(id))
        {
            return BadRequest("Task can not be null and your provided id must match");
        }
        var existingTask = await _taskService.GetTaskByIdAsync(id);
        if (existingTask == null)
        {
            return NotFound();
        }
        var updatedTask = await _taskService.UpdateTaskAsync(task);
        return Ok(updatedTask);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _taskService.DeleteTaskAsync(id);
        return NoContent();
    }
    #endregion
}

