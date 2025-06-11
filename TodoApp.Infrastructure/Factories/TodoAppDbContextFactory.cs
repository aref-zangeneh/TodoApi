using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Factories;
public class TodoAppDbContextFactory : IDesignTimeDbContextFactory<TodoAppDbContext>
{
    public TodoAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TodoAppDbContext>();
        optionsBuilder.UseSqlServer("Password=***;User ID=sa;Initial Catalog=TodoDb;Data Source= source;TrustServerCertificate=True;");
        return new TodoAppDbContext(optionsBuilder.Options);
    }
}

