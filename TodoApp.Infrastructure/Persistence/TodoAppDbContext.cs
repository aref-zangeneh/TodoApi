using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Persistence;
public class TodoAppDbContext : DbContext
{
    #region Ctor
    public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options)
    {

    }
    #endregion

    #region DbSets

    public DbSet<TodoTask> TodoTasks => Set<TodoTask>();
    #endregion

    #region EF FluentApi
    /// <summary>
    /// configures the model for the context using the Fluent API
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoTask>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TodoTask>()
            .HasData(new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Title = "Task title 1",
                Description = "This is about task title 1 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                Title = "Task title 2",
                Description = "This is about task title 2 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                Title = "Task title 3",
                Description = "This is about task title 3 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000004"),
                Title = "Task title 4",
                Description = "This is about task title 4 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000005"),
                Title = "Task title 5",
                Description = "This is about task title 5 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000006"),
                Title = "Task title 6",
                Description = "This is about task title 6 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000007"),
                Title = "Task title 7",
                Description = "This is about task title 7 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000008"),
                Title = "Task title 8",
                Description = "This is about task title 8 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000009"),
                Title = "Task title 9",
                Description = "This is about task title 9 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new TodoTask
            {
                Id = new Guid("00000000-0000-0000-0000-000000000010"),
                Title = "Task title 10",
                Description = "This is about task title 10 description.",
                IsCompleted = false,
                DueDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });
    }

    #endregion

}

