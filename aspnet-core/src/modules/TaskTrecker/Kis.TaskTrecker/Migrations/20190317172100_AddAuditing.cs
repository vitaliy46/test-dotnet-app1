using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.TaskTrecker.Migrations
{
    public partial class AddAuditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "project_workflows");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "project_workflows");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "project_states");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "project_states");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "project_milestones");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "project_milestones");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "project_milestone_issue_rels");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_workflows");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_workflows");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_states");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_states");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_priorities");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_priorities");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_medias");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_medias");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_comments");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_comments");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "projects",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "projects",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "project_workflows",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "project_workflows",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "project_states",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "project_states",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "project_milestones",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "project_milestones",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "issues",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "issues",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "issue_workflows",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "issue_workflows",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "issue_states",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "issue_states",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "issue_priorities",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "issue_priorities",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "issue_medias",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "issue_medias",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                schema: "task_tracker",
                table: "issue_comments",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                schema: "task_tracker",
                table: "issue_comments",
                newName: "last_modification_time");

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "projects",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "projects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "projects",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "project_workflows",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "project_workflows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "project_workflows",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "project_workflows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "project_workflows",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "project_states",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "project_states",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "project_states",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "project_states",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "project_states",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "project_milestones",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "project_milestones",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "project_milestones",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "project_milestones",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "project_milestones",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issues",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issues",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issues",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_workflows",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_workflows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_workflows",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_workflows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_workflows",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_states",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_states",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_states",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_states",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_states",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_priorities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_priorities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_priorities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_priorities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_priorities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_medias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_medias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_medias",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_medias",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_medias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_comments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_comments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "project_workflows");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "project_workflows");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "project_workflows");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "project_workflows");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "project_workflows");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "project_states");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "project_states");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "project_states");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "project_states");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "project_states");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "project_milestones");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "project_milestones");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "project_milestones");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "project_milestones");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "project_milestones");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "project_milestone_issue_rels");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "project_milestone_issue_rels");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_workflows");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_workflows");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_workflows");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_workflows");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_workflows");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_states");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_states");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_states");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_states");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_states");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_priorities");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_priorities");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_priorities");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_priorities");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_priorities");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_medias");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_medias");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_medias");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_medias");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_medias");

            migrationBuilder.DropColumn(
                name: "creator_user_id",
                schema: "task_tracker",
                table: "issue_comments");

            migrationBuilder.DropColumn(
                name: "deleter_user_id",
                schema: "task_tracker",
                table: "issue_comments");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                schema: "task_tracker",
                table: "issue_comments");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "task_tracker",
                table: "issue_comments");

            migrationBuilder.DropColumn(
                name: "last_modifier_user_id",
                schema: "task_tracker",
                table: "issue_comments");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "projects",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "projects",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "project_workflows",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "project_workflows",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "project_states",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "project_states",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "project_milestones",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "project_milestones",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "issues",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "issues",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "issue_workflows",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "issue_workflows",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "issue_states",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "issue_states",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "issue_priorities",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "issue_priorities",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "issue_medias",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "issue_medias",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                schema: "task_tracker",
                table: "issue_comments",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                schema: "task_tracker",
                table: "issue_comments",
                newName: "modified_date");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "project_workflows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "project_workflows",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "project_states",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "project_states",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "project_milestones",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "project_milestones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "issues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_workflows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_workflows",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_states",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_states",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_priorities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_priorities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_medias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_medias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                schema: "task_tracker",
                table: "issue_comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "task_tracker",
                table: "issue_comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
