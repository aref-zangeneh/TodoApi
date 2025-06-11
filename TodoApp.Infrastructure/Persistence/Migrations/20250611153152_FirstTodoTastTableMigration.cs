using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstTodoTastTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "This is about task title 1 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 1" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "This is about task title 2 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 2" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "This is about task title 3 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTasks");
        }
    }
}
