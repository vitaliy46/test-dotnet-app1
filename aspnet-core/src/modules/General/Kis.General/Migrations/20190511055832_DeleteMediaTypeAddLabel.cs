using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.General.Migrations
{
    public partial class DeleteMediaTypeAddLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medias_media_types_MediaTypeId",
                schema: "general",
                table: "medias");

            migrationBuilder.DropIndex(
                name: "IX_medias_MediaTypeId",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "MediaTypeId",
                schema: "general",
                table: "medias");

            migrationBuilder.AddColumn<string>(
                name: "label",
                schema: "general",
                table: "medias",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_medias_label",
                schema: "general",
                table: "medias",
                column: "label");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_medias_label",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "label",
                schema: "general",
                table: "medias");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaTypeId",
                schema: "general",
                table: "medias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_medias_MediaTypeId",
                schema: "general",
                table: "medias",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_medias_media_types_MediaTypeId",
                schema: "general",
                table: "medias",
                column: "MediaTypeId",
                principalSchema: "general",
                principalTable: "media_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
