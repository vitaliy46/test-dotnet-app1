using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.General.Migrations
{
    public partial class AddFildsInPersonAdnAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                schema: "general",
                table: "persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "full_address",
                schema: "general",
                table: "addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name",
                schema: "general",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "full_address",
                schema: "general",
                table: "addresses");
        }
    }
}
