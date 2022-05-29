using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.General.Migrations
{
    public partial class DeleteOrdetInState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order",
                schema: "general",
                table: "states");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "order",
                schema: "general",
                table: "states",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
