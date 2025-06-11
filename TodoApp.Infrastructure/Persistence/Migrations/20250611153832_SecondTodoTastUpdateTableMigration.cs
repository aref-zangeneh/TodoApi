using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondTodoTastUpdateTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), "This is about task title 4 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 4" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "This is about task title 5 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 5" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "This is about task title 6 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 6" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "This is about task title 7 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 7" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "This is about task title 8 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 8" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "This is about task title 9 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 9" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "This is about task title 10 description.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Task title 10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));
        }
    }
}
