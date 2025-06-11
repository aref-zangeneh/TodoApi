using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Factories
{
    public class TodoAppDbContextFactory : IDesignTimeDbContextFactory<TodoAppDbContext>
    {
        public TodoAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoAppDbContext>();
            optionsBuilder.UseSqlServer("Password=Armin1324@$Z;User ID=sa;Initial Catalog=TodoDb;Data Source=ARMIN\\MSSQLSERVER1;TrustServerCertificate=True;");
            return new TodoAppDbContext(optionsBuilder.Options);
        }
    }
}
