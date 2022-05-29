using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Investors.Migrations
{
    public partial class AddMemberContactFromPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "contact_id",
                schema: "investor",
                table: "member_contactors",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contact_id",
                schema: "investor",
                table: "member_contactors");
        }
    }
}
