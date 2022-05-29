using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Voting.Migrations
{
    public partial class AddTextResultInVoteResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "text_result",
                schema: "voting",
                table: "vote_results",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "text_result",
                schema: "voting",
                table: "vote_results");
        }
    }
}
