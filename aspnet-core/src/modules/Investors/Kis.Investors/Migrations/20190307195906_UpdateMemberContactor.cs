using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Investors.Migrations
{
    public partial class UpdateMemberContactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "investor",
                table: "member_contactors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                schema: "investor",
                table: "member_contactors",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
