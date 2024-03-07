using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTodoProxy.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientBudget",
                table: "TaskTodoTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientUrl",
                table: "TaskTodoTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "TaskTodoTable",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "TaskTodoTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaskStatus",
                table: "TaskTodoTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientBudget",
                table: "TaskTodoTable");

            migrationBuilder.DropColumn(
                name: "ClientUrl",
                table: "TaskTodoTable");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "TaskTodoTable");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "TaskTodoTable");

            migrationBuilder.DropColumn(
                name: "TaskStatus",
                table: "TaskTodoTable");
        }
    }
}
