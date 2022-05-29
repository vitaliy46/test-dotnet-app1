using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.Voting.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "voting");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "vote_member_contacts",
                schema: "voting",
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
                    contact_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_member_contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vote_settings",
                schema: "voting",
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
                    user_id = table.Column<long>(nullable: false),
                    is_need_sign = table.Column<bool>(nullable: false),
                    voting_calculation_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bulletin_selected_options",
                schema: "voting",
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
                    bulletin_id = table.Column<Guid>(nullable: false),
                    selected_option_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bulletin_selected_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vote_members",
                schema: "voting",
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
                    name = table.Column<string>(nullable: false),
                    user_id = table.Column<long>(nullable: false),
                    vote_id = table.Column<Guid>(nullable: false),
                    vote_member_contact_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_members", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_members_vote_member_contacts_vote_member_contact_id",
                        column: x => x.vote_member_contact_id,
                        principalSchema: "voting",
                        principalTable: "vote_member_contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bulletins",
                schema: "voting",
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
                    vote_member_id = table.Column<Guid>(nullable: false),
                    vote_id = table.Column<Guid>(nullable: false),
                    voting_result_xml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bulletins", x => x.id);
                    table.ForeignKey(
                        name: "FK_bulletins_vote_members_vote_member_id",
                        column: x => x.vote_member_id,
                        principalSchema: "voting",
                        principalTable: "vote_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notice_receipt_confimations",
                schema: "voting",
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
                    confimation_xml = table.Column<string>(nullable: true),
                    vote_id = table.Column<Guid>(nullable: false),
                    member_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notice_receipt_confimations", x => x.id);
                    table.ForeignKey(
                        name: "FK_notice_receipt_confimations_vote_members_member_id",
                        column: x => x.member_id,
                        principalSchema: "voting",
                        principalTable: "vote_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vote_report_medias",
                schema: "voting",
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
                    vote_report_id = table.Column<Guid>(nullable: false),
                    media_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_report_medias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "votes",
                schema: "voting",
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
                    number = table.Column<long>(nullable: false),
                    theme = table.Column<string>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    VoteResultId = table.Column<Guid>(nullable: true),
                    initiator_id = table.Column<long>(nullable: false),
                    context_id = table.Column<Guid>(nullable: false),
                    is_multilice_choice = table.Column<bool>(nullable: false),
                    quorum_pct = table.Column<float>(nullable: false),
                    decision_makers_pct = table.Column<float>(nullable: false),
                    begin_date_time = table.Column<DateTime>(nullable: false),
                    end_date_time = table.Column<DateTime>(nullable: false),
                    note_sending_date_time = table.Column<DateTime>(nullable: false),
                    voting_calculation_type = table.Column<int>(nullable: false),
                    ReportFormat = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vote_links",
                schema: "voting",
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
                    vote_id = table.Column<Guid>(nullable: false),
                    link_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_links", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_links_votes_vote_id",
                        column: x => x.vote_id,
                        principalSchema: "voting",
                        principalTable: "votes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vote_medias",
                schema: "voting",
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
                    vote_id = table.Column<Guid>(nullable: false),
                    media_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_medias", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_medias_votes_vote_id",
                        column: x => x.vote_id,
                        principalSchema: "voting",
                        principalTable: "votes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vote_notices",
                schema: "voting",
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
                    message = table.Column<string>(nullable: false),
                    vote_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_notices", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_notices_votes_vote_id",
                        column: x => x.vote_id,
                        principalSchema: "voting",
                        principalTable: "votes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vote_options",
                schema: "voting",
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
                    text = table.Column<string>(nullable: false),
                    vote_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_options_votes_vote_id",
                        column: x => x.vote_id,
                        principalSchema: "voting",
                        principalTable: "votes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vote_reports",
                schema: "voting",
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
                    vote_id = table.Column<Guid>(nullable: false),
                    report_file_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_reports_votes_vote_id",
                        column: x => x.vote_id,
                        principalSchema: "voting",
                        principalTable: "votes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vote_results",
                schema: "voting",
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
                    vote_id = table.Column<Guid>(nullable: false),
                    signed_result = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_results", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_results_votes_vote_id",
                        column: x => x.vote_id,
                        principalSchema: "voting",
                        principalTable: "votes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bulletin_selected_options_bulletin_id",
                schema: "voting",
                table: "bulletin_selected_options",
                column: "bulletin_id");

            migrationBuilder.CreateIndex(
                name: "IX_bulletin_selected_options_selected_option_id",
                schema: "voting",
                table: "bulletin_selected_options",
                column: "selected_option_id");

            migrationBuilder.CreateIndex(
                name: "IX_bulletins_vote_id",
                schema: "voting",
                table: "bulletins",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_bulletins_vote_member_id",
                schema: "voting",
                table: "bulletins",
                column: "vote_member_id");

            migrationBuilder.CreateIndex(
                name: "IX_notice_receipt_confimations_member_id",
                schema: "voting",
                table: "notice_receipt_confimations",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_notice_receipt_confimations_vote_id",
                schema: "voting",
                table: "notice_receipt_confimations",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_links_vote_id",
                schema: "voting",
                table: "vote_links",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_medias_vote_id",
                schema: "voting",
                table: "vote_medias",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_members_vote_id",
                schema: "voting",
                table: "vote_members",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_members_vote_member_contact_id",
                schema: "voting",
                table: "vote_members",
                column: "vote_member_contact_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vote_notices_vote_id",
                schema: "voting",
                table: "vote_notices",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_options_vote_id",
                schema: "voting",
                table: "vote_options",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_report_medias_vote_report_id",
                schema: "voting",
                table: "vote_report_medias",
                column: "vote_report_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_reports_vote_id",
                schema: "voting",
                table: "vote_reports",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_results_vote_id",
                schema: "voting",
                table: "vote_results",
                column: "vote_id");

            migrationBuilder.CreateIndex(
                name: "IX_votes_VoteResultId",
                schema: "voting",
                table: "votes",
                column: "VoteResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_bulletin_selected_options_bulletins_bulletin_id",
                schema: "voting",
                table: "bulletin_selected_options",
                column: "bulletin_id",
                principalSchema: "voting",
                principalTable: "bulletins",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bulletin_selected_options_vote_options_selected_option_id",
                schema: "voting",
                table: "bulletin_selected_options",
                column: "selected_option_id",
                principalSchema: "voting",
                principalTable: "vote_options",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vote_members_votes_vote_id",
                schema: "voting",
                table: "vote_members",
                column: "vote_id",
                principalSchema: "voting",
                principalTable: "votes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bulletins_votes_vote_id",
                schema: "voting",
                table: "bulletins",
                column: "vote_id",
                principalSchema: "voting",
                principalTable: "votes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notice_receipt_confimations_votes_vote_id",
                schema: "voting",
                table: "notice_receipt_confimations",
                column: "vote_id",
                principalSchema: "voting",
                principalTable: "votes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vote_report_medias_vote_reports_vote_report_id",
                schema: "voting",
                table: "vote_report_medias",
                column: "vote_report_id",
                principalSchema: "voting",
                principalTable: "vote_reports",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_vote_results_VoteResultId",
                schema: "voting",
                table: "votes",
                column: "VoteResultId",
                principalSchema: "voting",
                principalTable: "vote_results",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vote_results_votes_vote_id",
                schema: "voting",
                table: "vote_results");

            migrationBuilder.DropTable(
                name: "bulletin_selected_options",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "notice_receipt_confimations",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_links",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_medias",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_notices",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_report_medias",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_settings",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "bulletins",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_options",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_reports",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_members",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_member_contacts",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "votes",
                schema: "voting");

            migrationBuilder.DropTable(
                name: "vote_results",
                schema: "voting");
        }
    }
}
