using Microsoft.EntityFrameworkCore;

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

        public DbSet<Task> tasks => Set<Task>();
        #endregion

        #region EF FluentApi
        /// <summary>
        /// configures the model for the context using the Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion

    }
}
