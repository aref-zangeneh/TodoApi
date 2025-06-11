using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Persistence
{
    public class TodoAppDbContext : DbContext
    {
        #region Ctor
        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options)
        {

        }
        #endregion

        #region DbSets

        public DbSet<TodoTask> tasks => Set<TodoTask>();
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
                    Id = Guid.NewGuid(),
                    Title = "Task title 1",
                    Description = "This is about task title 1 description.",
                    IsCompleted = false,
                    DueDate = DateTime.UtcNow.AddDays(10)
                },
                new TodoTask
                {
                    Id = Guid.NewGuid(),
                    Title = "Task title 2",
                    Description = "This is about task title 2 description.",
                    IsCompleted = false,
                    DueDate = DateTime.UtcNow.AddDays(10)
                },
                new TodoTask
                {
                    Id = Guid.NewGuid(),
                    Title = "Task title 3",
                    Description = "This is about task title 3 description.",
                    IsCompleted = false,
                    DueDate = DateTime.UtcNow.AddDays(10)
                });
        }

        #endregion

    }
}
