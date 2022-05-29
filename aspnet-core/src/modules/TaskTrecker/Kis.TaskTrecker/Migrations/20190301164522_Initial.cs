using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.TaskTrecker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "task_tracker");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "issue_priorities",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue_priorities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project_milestones",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    tag = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_milestones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project_states",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    state_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_states", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    title = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    project_state_id = table.Column<Guid>(nullable: false),
                    manager_id = table.Column<Guid>(nullable: true),
                    gant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_project_states_project_state_id",
                        column: x => x.project_state_id,
                        principalSchema: "task_tracker",
                        principalTable: "project_states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "issue_workflows",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    project_id = table.Column<Guid>(nullable: false),
                    worklow_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue_workflows", x => x.id);
                    table.ForeignKey(
                        name: "FK_issue_workflows_projects_project_id",
                        column: x => x.project_id,
                        principalSchema: "task_tracker",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project_workflows",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    project_id = table.Column<Guid>(nullable: false),
                    worklow_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_workflows", x => x.id);
                    table.ForeignKey(
                        name: "FK_project_workflows_projects_project_id",
                        column: x => x.project_id,
                        principalSchema: "task_tracker",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "issues",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    title = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    parent_id = table.Column<Guid>(nullable: true),
                    priority_id = table.Column<Guid>(nullable: false),
                    state_id = table.Column<Guid>(nullable: false),
                    performer_id = table.Column<Guid>(nullable: true),
                    project_id = table.Column<Guid>(nullable: false),
                    dedline = table.Column<DateTime>(nullable: true),
                    planned_time = table.Column<long>(nullable: true),
                    last_read = table.Column<DateTime>(nullable: true),
                    last_comment_user_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issues", x => x.id);
                    table.ForeignKey(
                        name: "FK_issues_issues_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "task_tracker",
                        principalTable: "issues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_issues_issue_priorities_priority_id",
                        column: x => x.priority_id,
                        principalSchema: "task_tracker",
                        principalTable: "issue_priorities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_issues_projects_project_id",
                        column: x => x.project_id,
                        principalSchema: "task_tracker",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "issue_medias",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    media_id = table.Column<Guid>(nullable: false),
                    issue_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue_medias", x => x.id);
                    table.ForeignKey(
                        name: "FK_issue_medias_issues_issue_id",
                        column: x => x.issue_id,
                        principalSchema: "task_tracker",
                        principalTable: "issues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "issue_states",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    issue_id = table.Column<Guid>(nullable: false),
                    state_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue_states", x => x.id);
                    table.ForeignKey(
                        name: "FK_issue_states_issues_issue_id",
                        column: x => x.issue_id,
                        principalSchema: "task_tracker",
                        principalTable: "issues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project_milestone_issue_rels",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    issue_id = table.Column<Guid>(nullable: false),
                    project_milestone_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_milestone_issue_rels", x => x.id);
                    table.ForeignKey(
                        name: "FK_project_milestone_issue_rels_issues_issue_id",
                        column: x => x.issue_id,
                        principalSchema: "task_tracker",
                        principalTable: "issues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_milestone_issue_rels_project_milestones_project_mil~",
                        column: x => x.project_milestone_id,
                        principalSchema: "task_tracker",
                        principalTable: "project_milestones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "issue_comments",
                schema: "task_tracker",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    issue_id = table.Column<Guid>(nullable: false),
                    comment_id = table.Column<Guid>(nullable: false),
                    work_time = table.Column<long>(nullable: true),
                    issue_state_id = table.Column<Guid>(nullable: false),
                    IssueId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issue_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_issue_comments_issues_issue_id",
                        column: x => x.issue_id,
                        principalSchema: "task_tracker",
                        principalTable: "issues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_issue_comments_issues_IssueId1",
                        column: x => x.IssueId1,
                        principalSchema: "task_tracker",
                        principalTable: "issues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_issue_comments_issue_states_issue_state_id",
                        column: x => x.issue_state_id,
                        principalSchema: "task_tracker",
                        principalTable: "issue_states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_issue_comments_issue_id",
                schema: "task_tracker",
                table: "issue_comments",
                column: "issue_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_comments_IssueId1",
                schema: "task_tracker",
                table: "issue_comments",
                column: "IssueId1");

            migrationBuilder.CreateIndex(
                name: "IX_issue_comments_issue_state_id",
                schema: "task_tracker",
                table: "issue_comments",
                column: "issue_state_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_medias_issue_id",
                schema: "task_tracker",
                table: "issue_medias",
                column: "issue_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_states_issue_id",
                schema: "task_tracker",
                table: "issue_states",
                column: "issue_id");

            migrationBuilder.CreateIndex(
                name: "IX_issue_workflows_project_id",
                schema: "task_tracker",
                table: "issue_workflows",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_issues_parent_id",
                schema: "task_tracker",
                table: "issues",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_issues_priority_id",
                schema: "task_tracker",
                table: "issues",
                column: "priority_id");

            migrationBuilder.CreateIndex(
                name: "IX_issues_project_id",
                schema: "task_tracker",
                table: "issues",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_issues_state_id",
                schema: "task_tracker",
                table: "issues",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_milestone_issue_rels_issue_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                column: "issue_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_milestone_issue_rels_project_milestone_id",
                schema: "task_tracker",
                table: "project_milestone_issue_rels",
                column: "project_milestone_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_workflows_project_id",
                schema: "task_tracker",
                table: "project_workflows",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_project_state_id",
                schema: "task_tracker",
                table: "projects",
                column: "project_state_id");

            migrationBuilder.AddForeignKey(
                name: "FK_issues_issue_states_state_id",
                schema: "task_tracker",
                table: "issues",
                column: "state_id",
                principalSchema: "task_tracker",
                principalTable: "issue_states",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_issue_states_issues_issue_id",
                schema: "task_tracker",
                table: "issue_states");

            migrationBuilder.DropTable(
                name: "issue_comments",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "issue_medias",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "issue_workflows",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "project_milestone_issue_rels",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "project_workflows",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "project_milestones",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "issues",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "issue_priorities",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "projects",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "issue_states",
                schema: "task_tracker");

            migrationBuilder.DropTable(
                name: "project_states",
                schema: "task_tracker");
        }
    }
}
