namespace TodoApp.Domain.Entities;
public class Task
{
    /// <summary>
    /// gets or sets a guid unique identifier for the task.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// gets or sets the title of the task.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// gets or sets the description of the task.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// gets or sets the status of the task.
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// gets or sets the due date of the task.
    /// </summary>
    public DateTime DueDate { get; set; }
}

