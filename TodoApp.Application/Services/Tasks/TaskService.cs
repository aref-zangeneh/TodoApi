using TodoApp.Application.Interfaces.Repository;
using TodoApp.Application.Interfaces.Services.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services.Tasks;
public class TaskService : ITaskService
{
    #region Fields
    private readonly IRepository<TodoTask> _taskRepository;
    #endregion

    #region Ctor

    public TaskService(IRepository<TodoTask> taskRepository)
    {
        _taskRepository = taskRepository;
    }

    #endregion

    #region Methods
    public virtual async Task<IList<TodoTask>> GetAllTasksAsync()
    {
        return await _taskRepository.GetAllAsync();
    }

    public virtual async Task<TodoTask> GetTaskByIdAsync(Guid taskId)
    {

        var task = await _taskRepository.GetByIdAsync(taskId);
        return task;

    }

    public virtual async Task<TodoTask> CreateTaskAsync(TodoTask task)
    {
        return await _taskRepository.AddAsync(task);
    }

    public virtual async Task<TodoTask> UpdateTaskAsync(TodoTask task)
    {
        return await _taskRepository.UpdateAsync(task);
    }

    public virtual async Task<TodoTask> DeleteTaskAsync(Guid taskId)
    {
        return await _taskRepository.DeleteAsync(taskId);
    }

    #endregion
}

