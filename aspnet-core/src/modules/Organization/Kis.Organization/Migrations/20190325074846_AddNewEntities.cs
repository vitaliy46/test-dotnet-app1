using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Organization.Migrations
{
    public partial class AddNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounting_details",
                schema: "organization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    creation_time = table.Column<DateTime>(nullable: false),
                    creator_user_id = table.Column<long>(nullable: true),
                    last_modification_time = table.Column<DateTime>(nullable: true),
                    last_modifier_user_id = table.Column<long>(nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    deleter_user_id = table.Column<long>(nullable: true),
                    deletion_time = table.Column<DateTime>(nullable: true),
                    organization_unit_id = table.Column<Guid>(nullable: false),
                    inn = table.Column<string>(nullable: true),
                    ogrn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounting_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_accounting_details_organization_units_organization_unit_id",
                        column: x => x.organization_unit_id,
                        principalSchema: "organization",
                        principalTable: "organization_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organization_unit_medias",
                schema: "organization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    creation_time = table.Column<DateTime>(nullable: false),
                    creator_user_id = table.Column<long>(nullable: true),
                    last_modification_time = table.Column<DateTime>(nullable: true),
                    last_modifier_user_id = table.Column<long>(nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    deleter_user_id = table.Column<long>(nullable: true),
                    deletion_time = table.Column<DateTime>(nullable: true),
                    organization_unit_id = table.Column<Guid>(nullable: false),
                    media_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_unit_medias", x => x.id);
                    table.ForeignKey(
                        name: "FK_organization_unit_medias_organization_units_organization_un~",
                        column: x => x.organization_unit_id,
                        principalSchema: "organization",
                        principalTable: "organization_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounting_details_organization_unit_id",
                schema: "organization",
                table: "accounting_details",
                column: "organization_unit_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organization_unit_medias_organization_unit_id",
                schema: "organization",
                table: "organization_unit_medias",
                column: "organization_unit_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounting_details",
                schema: "organization");

            migrationBuilder.DropTable(
                name: "organization_unit_medias",
                schema: "organization");
        }
    }
}
