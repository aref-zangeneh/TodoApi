using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstTodoTaskMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tasks",
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
                    table.PrimaryKey("PK_tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { new Guid("70e5fc52-79e6-476c-ba95-4bf25e2dd48e"), "This is about task title 1 description.", new DateTime(2025, 6, 21, 13, 2, 7, 932, DateTimeKind.Utc).AddTicks(9402), false, "Task title 1" },
                    { new Guid("a5a4fc1d-3d3d-4c21-ab43-1bd28bb8e235"), "This is about task title 2 description.", new DateTime(2025, 6, 21, 13, 2, 7, 932, DateTimeKind.Utc).AddTicks(9581), false, "Task title 2" },
                    { new Guid("eed4592f-b415-46d2-b971-b5a39be295aa"), "This is about task title 3 description.", new DateTime(2025, 6, 21, 13, 2, 7, 932, DateTimeKind.Utc).AddTicks(9585), false, "Task title 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");
        }
    }
}
