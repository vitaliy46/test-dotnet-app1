using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.General.Migrations
{
    public partial class AddPersonUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person_users",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    person_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_users_persons_person_id",
                        column: x => x.person_id,
                        principalSchema: "general",
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_users_person_id",
                schema: "general",
                table: "person_users",
                column: "person_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person_users",
                schema: "general");
        }
    }
}
