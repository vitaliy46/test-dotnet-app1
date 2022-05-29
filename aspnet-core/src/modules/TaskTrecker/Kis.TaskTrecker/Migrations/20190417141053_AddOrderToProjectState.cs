using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.TaskTrecker.Migrations
{
    public partial class AddOrderToProjectState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "order",
                schema: "task_tracker",
                table: "project_states",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "order",
                schema: "task_tracker",
                table: "issue_states",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order",
                schema: "task_tracker",
                table: "project_states");

            migrationBuilder.DropColumn(
                name: "order",
                schema: "task_tracker",
                table: "issue_states");
        }
    }
}
