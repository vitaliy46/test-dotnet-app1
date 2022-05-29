using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.General.Migrations
{
    public partial class AddAuditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "workflows");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "workflows");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "states");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "states");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "state_transitions");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "state_transitions");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "policies");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "policies");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "person_users");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "person_users");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "person_contacts");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "person_contacts");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "person_addresses");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "person_addresses");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "media_types");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "media_types");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "links");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "links");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "comment_medias");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "comment_medias");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "comment_links");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "comment_links");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "general",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "general",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "workflows",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "workflows",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "states",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "states",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "state_transitions",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "state_transitions",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "policies",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "policies",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "persons",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "persons",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "person_users",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "person_users",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "person_contacts",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "person_contacts",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "person_addresses",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "person_addresses",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "medias",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "medias",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "media_types",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "media_types",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "links",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "links",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "contacts",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "contacts",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "comments",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "comments",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "comment_medias",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "comment_medias",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "comment_links",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "comment_links",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "general",
                table: "addresses",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "general",
                table: "addresses",
                newName: "last_modification_time");

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "workflows",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "workflows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "workflows",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "workflows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "workflows",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "states",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "states",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "states",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "states",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "states",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "state_transitions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "state_transitions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "state_transitions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "state_transitions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "state_transitions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "policies",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "policies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "policies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "policies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "policies",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "persons",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "persons",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "persons",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "persons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "persons",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "person_users",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "person_users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "person_users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "person_users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "person_users",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "person_contacts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "person_contacts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "person_contacts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "person_contacts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "person_contacts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "person_addresses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "person_addresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "person_addresses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "person_addresses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "person_addresses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "medias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "medias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "medias",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "medias",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "medias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "media_types",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "media_types",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "media_types",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "media_types",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "media_types",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "links",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "links",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "links",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "links",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "links",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "contacts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "contacts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "contacts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "contacts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "contacts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "comments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "comments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "comments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "comment_medias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "comment_medias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "comment_medias",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "comment_medias",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "comment_medias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "comment_links",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "comment_links",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "comment_links",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "comment_links",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "comment_links",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "general",
                table: "addresses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "general",
                table: "addresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "general",
                table: "addresses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "general",
                table: "addresses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "general",
                table: "addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "workflows");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "workflows");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "workflows");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "workflows");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "workflows");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "states");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "states");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "states");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "states");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "states");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "state_transitions");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "state_transitions");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "state_transitions");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "state_transitions");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "state_transitions");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "policies");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "policies");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "policies");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "policies");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "policies");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "person_users");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "person_users");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "person_users");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "person_users");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "person_users");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "person_contacts");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "person_contacts");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "person_contacts");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "person_contacts");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "person_contacts");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "person_addresses");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "person_addresses");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "person_addresses");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "person_addresses");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "person_addresses");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "medias");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "media_types");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "media_types");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "media_types");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "media_types");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "media_types");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "links");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "links");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "links");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "links");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "links");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "comment_medias");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "comment_medias");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "comment_medias");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "comment_medias");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "comment_medias");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "comment_links");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "comment_links");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "comment_links");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "comment_links");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "comment_links");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "general",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "general",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "general",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "general",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "general",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "workflows",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "workflows",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "states",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "states",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "state_transitions",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "state_transitions",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "policies",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "policies",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "persons",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "persons",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "person_users",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "person_users",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "person_contacts",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "person_contacts",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "person_addresses",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "person_addresses",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "medias",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "medias",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "media_types",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "media_types",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "links",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "links",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "contacts",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "contacts",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "comments",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "comments",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "comment_medias",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "comment_medias",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "comment_links",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "comment_links",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "general",
                table: "addresses",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "general",
                table: "addresses",
                newName: "modified_date");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "workflows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "workflows",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "states",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "states",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "state_transitions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "state_transitions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "policies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "policies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "persons",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "persons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "person_users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "person_users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "person_contacts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "person_contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "person_addresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "person_addresses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "medias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "medias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "media_types",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "media_types",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "links",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "links",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "contacts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "comment_medias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "comment_medias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "comment_links",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "comment_links",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "general",
                table: "addresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "general",
                table: "addresses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
