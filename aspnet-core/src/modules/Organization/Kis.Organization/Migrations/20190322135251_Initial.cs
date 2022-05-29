using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Organization.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "organization");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "organization_units",
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
                    name = table.Column<string>(nullable: true),
                    parent_id = table.Column<Guid>(nullable: true),
                    header_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_units", x => x.id);
                    table.ForeignKey(
                        name: "FK_organization_units_organization_units_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "organization",
                        principalTable: "organization_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "organization_unit_addresses",
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
                    address_id = table.Column<Guid>(nullable: false),
                    organization_unit_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_unit_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_organization_unit_addresses_organization_units_organization~",
                        column: x => x.organization_unit_id,
                        principalSchema: "organization",
                        principalTable: "organization_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organization_unit_contacts",
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
                    contact_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_unit_contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_organization_unit_contacts_organization_units_organization_~",
                        column: x => x.organization_unit_id,
                        principalSchema: "organization",
                        principalTable: "organization_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organization_unit_users",
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
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_unit_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_organization_unit_users_organization_units_organization_uni~",
                        column: x => x.organization_unit_id,
                        principalSchema: "organization",
                        principalTable: "organization_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_organization_unit_addresses_organization_unit_id",
                schema: "organization",
                table: "organization_unit_addresses",
                column: "organization_unit_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organization_unit_contacts_organization_unit_id",
                schema: "organization",
                table: "organization_unit_contacts",
                column: "organization_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_organization_unit_users_organization_unit_id",
                schema: "organization",
                table: "organization_unit_users",
                column: "organization_unit_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organization_units_parent_id",
                schema: "organization",
                table: "organization_units",
                column: "parent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organization_unit_addresses",
                schema: "organization");

            migrationBuilder.DropTable(
                name: "organization_unit_contacts",
                schema: "organization");

            migrationBuilder.DropTable(
                name: "organization_unit_users",
                schema: "organization");

            migrationBuilder.DropTable(
                name: "organization_units",
                schema: "organization");
        }
    }
}
