using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Investors.Migrations
{
    public partial class AddAuditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "investor",
                table: "partnerships");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "investor",
                table: "partnerships");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "investor",
                table: "partnership_members");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "investor",
                table: "partnership_members");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "investor",
                table: "member_contactors");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "investor",
                table: "member_contactors");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "investor",
                table: "investors");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "investor",
                table: "investors");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "investor",
                table: "invested_projects");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "investor",
                table: "invested_projects");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "investor",
                table: "partnerships",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "investor",
                table: "partnerships",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "investor",
                table: "partnership_members",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "investor",
                table: "partnership_members",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "investor",
                table: "member_contactors",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "investor",
                table: "member_contactors",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "investor",
                table: "investors",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "investor",
                table: "investors",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "investor",
                table: "invested_projects",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "investor",
                table: "invested_projects",
                newName: "last_modification_time");

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "investor",
                table: "partnerships",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "investor",
                table: "partnerships",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "investor",
                table: "partnerships",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "investor",
                table: "partnerships",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "partnerships",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "investor",
                table: "partnership_members",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "investor",
                table: "partnership_members",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "investor",
                table: "partnership_members",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "investor",
                table: "partnership_members",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "partnership_members",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "investor",
                table: "member_contactors",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "investor",
                table: "member_contactors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "investor",
                table: "member_contactors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "investor",
                table: "member_contactors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "member_contactors",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "investor",
                table: "investors",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "investor",
                table: "investors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "investor",
                table: "investors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "investor",
                table: "investors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "investors",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "investor",
                table: "invested_projects",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "investor",
                table: "invested_projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "investor",
                table: "invested_projects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "investor",
                table: "invested_projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "invested_projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "investor",
                table: "partnerships");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "investor",
                table: "partnerships");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "investor",
                table: "partnerships");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "investor",
                table: "partnerships");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "partnerships");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "investor",
                table: "partnership_members");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "investor",
                table: "partnership_members");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "investor",
                table: "partnership_members");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "investor",
                table: "partnership_members");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "partnership_members");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "investor",
                table: "member_contactors");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "investor",
                table: "member_contactors");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "investor",
                table: "member_contactors");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "investor",
                table: "member_contactors");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "member_contactors");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "investor",
                table: "investors");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "investor",
                table: "investors");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "investor",
                table: "investors");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "investor",
                table: "investors");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "investors");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "investor",
                table: "invested_projects");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "investor",
                table: "invested_projects");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "investor",
                table: "invested_projects");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "investor",
                table: "invested_projects");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "investor",
                table: "invested_projects");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "investor",
                table: "partnerships",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "investor",
                table: "partnerships",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "investor",
                table: "partnership_members",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "investor",
                table: "partnership_members",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "investor",
                table: "member_contactors",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "investor",
                table: "member_contactors",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "investor",
                table: "investors",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "investor",
                table: "investors",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "investor",
                table: "invested_projects",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "investor",
                table: "invested_projects",
                newName: "modified_date");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "investor",
                table: "partnerships",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "investor",
                table: "partnerships",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "investor",
                table: "partnership_members",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "investor",
                table: "partnership_members",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "investor",
                table: "member_contactors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "investor",
                table: "member_contactors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "investor",
                table: "investors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "investor",
                table: "investors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "investor",
                table: "invested_projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "investor",
                table: "invested_projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
