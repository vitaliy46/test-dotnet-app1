using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Voting.Migrations
{
    public partial class AddIsPublishedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_published",
                schema: "voting",
                table: "votes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_published",
                schema: "voting",
                table: "votes");
        }
    }
}
