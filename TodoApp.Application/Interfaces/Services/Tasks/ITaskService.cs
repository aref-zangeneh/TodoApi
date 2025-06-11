using TodoApp.Domain.Entities;

namespace TodoApp.Application.Interfaces.Services.Tasks;

/// <summary>
/// task service signatures
/// /// </summary>
public interface ITaskService
{
    /// <summary>
    /// get all tasks asynchronously.
    /// </summary>
    /// <returns></returns>
    Task<IList<TodoTask>> GetAllTasksAsync();

    /// <summary>
    /// get a task by its identifier asynchronously.
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    Task<TodoTask> GetTaskByIdAsync(Guid taskId);

    /// <summary>
    /// create a new task asynchronously.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    Task<TodoTask> CreateTaskAsync(TodoTask task);

    /// <summary>
    /// update an existing task asynchronously.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    Task<TodoTask> UpdateTaskAsync(TodoTask task);

    /// <summary>
    /// delete a task by its identifier asynchronously.
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    Task<TodoTask> DeleteTaskAsync(Guid taskId);
}

