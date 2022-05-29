using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.General.Migrations
{
    public partial class DeleteContactType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_contact_types_contact_type_id",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "contact_types",
                schema: "general");

            migrationBuilder.DropIndex(
                name: "IX_contacts_contact_type_id",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "contact_type_id",
                schema: "general",
                table: "contacts");

            migrationBuilder.AddColumn<int>(
                name: "contact_type",
                schema: "general",
                table: "contacts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contact_type",
                schema: "general",
                table: "contacts");

            migrationBuilder.AddColumn<Guid>(
                name: "contact_type_id",
                schema: "general",
                table: "contacts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "contact_types",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_by_id = table.Column<Guid>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_types", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_contact_type_id",
                schema: "general",
                table: "contacts",
                column: "contact_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_contact_types_contact_type_id",
                schema: "general",
                table: "contacts",
                column: "contact_type_id",
                principalSchema: "general",
                principalTable: "contact_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
