using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoApp.Api.Controllers;
using TodoApp.Application.Interfaces.Services.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Api.Tests
{
    public class TasksApiTests
    {
        [Fact]
        public async void GetAllTasks_ShouldReturnOk_WithTasks()
        {
            // arrange
            var mockService = new Mock<ITaskService>();
            mockService.Setup(service => service.GetAllTasksAsync())
                .ReturnsAsync(new List<TodoTask>
                {
                    new TodoTask
                    {
                        Id = Guid.NewGuid(),
                        Title = "Task1",
                        Description = "description1",
                        IsCompleted = true,
                        DueDate = DateTime.Now.AddDays(2)
                    },
                    new TodoTask
                    {
                        Id = Guid.NewGuid(),
                        Title = "Task2",
                        Description = "description2",
                        IsCompleted = false,
                        DueDate = DateTime.Now.AddDays(2)
                    },
                    new TodoTask
                    {
                        Id = Guid.NewGuid(),
                        Title = "Task3",
                        Description = "description3",
                        IsCompleted = true,
                        DueDate = DateTime.Now.AddDays(2)
                    }

                });

            var apiController = new TasksController(mockService.Object);

            // act
            var res = await apiController.GetAllTasks();

            // assert
            var ok = Assert.IsType<OkObjectResult>(res);
            var tasks = Assert.IsAssignableFrom<IEnumerable<TodoTask>>(ok.Value);
            Assert.NotEmpty(tasks);
        }

        [Fact]
        public async void GetTaskById_ShouldReturnOk_WithTask()
        {
            //arrange
            var taskId = Guid.NewGuid();
            var task = new TodoTask
            {
                Id = taskId,
                Title = "task",
                Description = "description",
                DueDate = DateTime.Today,
                IsCompleted = true
            };

            var mock = new Mock<ITaskService>();
            mock.Setup(s => s.GetTaskByIdAsync(taskId))
                .ReturnsAsync(task);

            var apiController = new TasksController(mock.Object);

            //act
            var res = await apiController.GetTaskById(taskId);
            //assert
            var ok = Assert.IsType<OkObjectResult>(res);
            var returnTask = Assert.IsType<TodoTask>(ok.Value);
            Assert.Equal(taskId, returnTask.Id);
        }

        [Fact]
        public async void CreateTask_ShouldReturnCreatedAtAction_WithCreatedTask()
        {
            //arrange
            var task = new TodoTask
            {
                Title = "task from test title",
                Description = "description",
                DueDate = DateTime.Today,
                IsCompleted = false
            };

            var createdTask = new TodoTask
            {
                Id = Guid.NewGuid(),
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            };

            var mock = new Mock<ITaskService>();
            mock.Setup(s => s.CreateTaskAsync(task))
                .ReturnsAsync(createdTask);

            var apiController = new TasksController(mock.Object);

            // act level
            var res = await apiController.CreateTask(task);

            // assert 
            var resultOfCreate = Assert.IsType<CreatedAtActionResult>(res);
            Assert.Equal(nameof(apiController.GetTaskById), resultOfCreate.ActionName);

            var returnTask = Assert.IsType<TodoTask>(createdTask);
            Assert.Equal(createdTask.Id, returnTask.Id);
            Assert.Equal(task.Title, returnTask.Title);
        }

        [Fact]
        public async Task CreateTask_ShouldReturnBadRequest_IfTaskIsNull()
        {
            //arrange
            var mockService = new Mock<ITaskService>();
            var controller = new TasksController(mockService.Object);

            // act
            var result = await controller.CreateTask(null);

            //assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Task cannot be null", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnOk_IfTaskIsUpdatedSuccessfully()
        {
            //arrange
            var taskId = Guid.NewGuid();
            var taskToUpdate = new TodoTask
            {
                Id = taskId,
                Title = "update test task",
                Description = "descrioption",
                DueDate = DateTime.Now.AddDays(2),
                IsCompleted = true
            };

            var mock = new Mock<ITaskService>();
            mock.Setup(s => s.GetTaskByIdAsync(taskId)).ReturnsAsync(taskToUpdate);
            mock.Setup(s => s.UpdateTaskAsync(taskToUpdate)).ReturnsAsync(taskToUpdate);

            var apiController = new TasksController(mock.Object);

            //act
            var res = await apiController.UpdateTask(taskId, taskToUpdate);

            //assert
            var ok = Assert.IsType<OkObjectResult>(res);
            var returnTask = Assert.IsType<TodoTask>(ok.Value);
            Assert.Equal(taskToUpdate.Id, returnTask.Id);
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnBadRequest_IfTaskIsNull()
        {
            //arrange
            var taskId = Guid.NewGuid();
            var mock = new Mock<ITaskService>();
            var apiController = new TasksController(mock.Object);

            //act
            var res = await apiController.UpdateTask(taskId, null);

            //assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(res);
            Assert.Equal("Task can not be null and your provided id must match", badRequest.Value);
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnBadRequest_IfIdIsEmpty()
        {
            // arrange
            var mock = new Mock<ITaskService>();
            var apiController = new TasksController(mock.Object);

            var task = new TodoTask
            {
                Id = Guid.NewGuid(),
                Title = "Task",
                Description = "Description",
                DueDate = DateTime.Now,
                IsCompleted = false
            };

            //act
            var res = await apiController.UpdateTask(Guid.Empty, task);

            //assert
            Assert.IsType<BadRequestResult>(res);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenTaskIsDeleted()
        {
            //arrange
            var taskId = Guid.NewGuid();
            var mock = new Mock<ITaskService>();
            mock.Setup(s => s.DeleteTaskAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new TodoTask { });

            var controller = new TasksController(mock.Object);

            //act
            var result = await controller.Delete(taskId);

            //assert
            Assert.IsType<NoContentResult>(result);
            mock.Verify(s => s.DeleteTaskAsync(taskId), Times.Once);
        }

    }
}
