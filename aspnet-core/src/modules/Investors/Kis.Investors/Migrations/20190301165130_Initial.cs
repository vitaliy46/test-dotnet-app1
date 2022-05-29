using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Investors.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "investor");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "investors",
                schema: "investor",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    member_id = table.Column<Guid>(nullable: false),
                    project_id = table.Column<Guid>(nullable: false),
                    investment_share = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "member_contactors",
                schema: "investor",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    person_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false),
                    partnership_member_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member_contactors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "partnerships",
                schema: "investor",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    oranization_id = table.Column<Guid>(nullable: false),
                    manager_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partnerships", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invested_projects",
                schema: "investor",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    project_id = table.Column<Guid>(nullable: false),
                    managing_company_id = table.Column<Guid>(nullable: false),
                    PartnershipId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invested_projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_invested_projects_partnerships_PartnershipId",
                        column: x => x.PartnershipId,
                        principalSchema: "investor",
                        principalTable: "partnerships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "partnership_members",
                schema: "investor",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    organization_id = table.Column<Guid>(nullable: false),
                    is_allow_sms_notification = table.Column<bool>(nullable: false),
                    PartnershipId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partnership_members", x => x.id);
                    table.ForeignKey(
                        name: "FK_partnership_members_partnerships_PartnershipId",
                        column: x => x.PartnershipId,
                        principalSchema: "investor",
                        principalTable: "partnerships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invested_projects_PartnershipId",
                schema: "investor",
                table: "invested_projects",
                column: "PartnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_investors_member_id",
                schema: "investor",
                table: "investors",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_investors_project_id",
                schema: "investor",
                table: "investors",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_member_contactors_partnership_member_id",
                schema: "investor",
                table: "member_contactors",
                column: "partnership_member_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_partnership_members_PartnershipId",
                schema: "investor",
                table: "partnership_members",
                column: "PartnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_partnerships_manager_id",
                schema: "investor",
                table: "partnerships",
                column: "manager_id");

            migrationBuilder.AddForeignKey(
                name: "FK_investors_partnership_members_member_id",
                schema: "investor",
                table: "investors",
                column: "member_id",
                principalSchema: "investor",
                principalTable: "partnership_members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_investors_invested_projects_project_id",
                schema: "investor",
                table: "investors",
                column: "project_id",
                principalSchema: "investor",
                principalTable: "invested_projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_member_contactors_partnership_members_partnership_member_id",
                schema: "investor",
                table: "member_contactors",
                column: "partnership_member_id",
                principalSchema: "investor",
                principalTable: "partnership_members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_partnerships_partnership_members_manager_id",
                schema: "investor",
                table: "partnerships",
                column: "manager_id",
                principalSchema: "investor",
                principalTable: "partnership_members",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_partnership_members_partnerships_PartnershipId",
                schema: "investor",
                table: "partnership_members");

            migrationBuilder.DropTable(
                name: "investors",
                schema: "investor");

            migrationBuilder.DropTable(
                name: "member_contactors",
                schema: "investor");

            migrationBuilder.DropTable(
                name: "invested_projects",
                schema: "investor");

            migrationBuilder.DropTable(
                name: "partnerships",
                schema: "investor");

            migrationBuilder.DropTable(
                name: "partnership_members",
                schema: "investor");
        }
    }
}
