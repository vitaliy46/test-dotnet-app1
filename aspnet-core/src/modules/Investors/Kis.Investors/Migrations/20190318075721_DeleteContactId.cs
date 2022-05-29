using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Investors.Migrations
{
    public partial class DeleteContactId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contactor_id",
                schema: "investor",
                table: "partnership_members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "contactor_id",
                schema: "investor",
                table: "partnership_members",
                nullable: true);
        }
    }
}
