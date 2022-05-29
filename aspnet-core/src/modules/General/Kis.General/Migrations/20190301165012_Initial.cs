using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kis.General.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "general");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "addresses",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    address_type = table.Column<int>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    house = table.Column<string>(nullable: true),
                    housing = table.Column<string>(nullable: true),
                    flat = table.Column<string>(nullable: true),
                    postcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact_types",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "links",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_links", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "media_types",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    Order = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workflows",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflows", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person_addresses",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    person_id = table.Column<Guid>(nullable: false),
                    address_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_addresses_addresses_address_id",
                        column: x => x.address_id,
                        principalSchema: "general",
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    value = table.Column<string>(nullable: true),
                    contact_type_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_contacts_contact_types_contact_type_id",
                        column: x => x.contact_type_id,
                        principalSchema: "general",
                        principalTable: "contact_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment_links",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    comment_id = table.Column<Guid>(nullable: false),
                    link_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_links", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_links_comments_comment_id",
                        column: x => x.comment_id,
                        principalSchema: "general",
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_links_links_link_id",
                        column: x => x.link_id,
                        principalSchema: "general",
                        principalTable: "links",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medias",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    MediaTypeId = table.Column<Guid>(nullable: false),
                    file_name = table.Column<string>(nullable: true),
                    path = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medias", x => x.id);
                    table.ForeignKey(
                        name: "FK_medias_media_types_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalSchema: "general",
                        principalTable: "media_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "state_transitions",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    state_from_id = table.Column<Guid>(nullable: false),
                    state_to_id = table.Column<Guid>(nullable: false),
                    workflow_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state_transitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_state_transitions_states_state_from_id",
                        column: x => x.state_from_id,
                        principalSchema: "general",
                        principalTable: "states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_state_transitions_states_state_to_id",
                        column: x => x.state_to_id,
                        principalSchema: "general",
                        principalTable: "states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_state_transitions_workflows_workflow_id",
                        column: x => x.workflow_id,
                        principalSchema: "general",
                        principalTable: "workflows",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: false),
                    patronymic = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false),
                    birth_date = table.Column<DateTime>(nullable: false),
                    photo_uri = table.Column<string>(nullable: true),
                    snils = table.Column<string>(nullable: true),
                    address_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_person_addresses_address_id",
                        column: x => x.address_id,
                        principalSchema: "general",
                        principalTable: "person_addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comment_medias",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    comment_id = table.Column<Guid>(nullable: false),
                    media_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_medias", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_medias_comments_comment_id",
                        column: x => x.comment_id,
                        principalSchema: "general",
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_medias_medias_media_id",
                        column: x => x.media_id,
                        principalSchema: "general",
                        principalTable: "medias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person_contacts",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    person_id = table.Column<Guid>(nullable: false),
                    contact_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_contacts_contacts_contact_id",
                        column: x => x.contact_id,
                        principalSchema: "general",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_contacts_persons_person_id",
                        column: x => x.person_id,
                        principalSchema: "general",
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "policies",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_date = table.Column<DateTime>(nullable: false),
                    created_by_id = table.Column<Guid>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: false),
                    deleted_date = table.Column<DateTime>(nullable: true),
                    number = table.Column<string>(nullable: true),
                    begin_date = table.Column<DateTime>(nullable: false),
                    series = table.Column<string>(nullable: true),
                    end_date = table.Column<DateTime>(nullable: false),
                    person_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policies", x => x.id);
                    table.ForeignKey(
                        name: "FK_policies_persons_person_id",
                        column: x => x.person_id,
                        principalSchema: "general",
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_links_comment_id",
                schema: "general",
                table: "comment_links",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_links_link_id",
                schema: "general",
                table: "comment_links",
                column: "link_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_medias_comment_id",
                schema: "general",
                table: "comment_medias",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_medias_media_id",
                schema: "general",
                table: "comment_medias",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_contact_type_id",
                schema: "general",
                table: "contacts",
                column: "contact_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_medias_MediaTypeId",
                schema: "general",
                table: "medias",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_person_addresses_address_id",
                schema: "general",
                table: "person_addresses",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_contacts_contact_id",
                schema: "general",
                table: "person_contacts",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_contacts_person_id",
                schema: "general",
                table: "person_contacts",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_address_id",
                schema: "general",
                table: "persons",
                column: "address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_policies_person_id",
                schema: "general",
                table: "policies",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_state_transitions_state_from_id",
                schema: "general",
                table: "state_transitions",
                column: "state_from_id");

            migrationBuilder.CreateIndex(
                name: "IX_state_transitions_state_to_id",
                schema: "general",
                table: "state_transitions",
                column: "state_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_state_transitions_workflow_id",
                schema: "general",
                table: "state_transitions",
                column: "workflow_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_links",
                schema: "general");

            migrationBuilder.DropTable(
                name: "comment_medias",
                schema: "general");

            migrationBuilder.DropTable(
                name: "person_contacts",
                schema: "general");

            migrationBuilder.DropTable(
                name: "policies",
                schema: "general");

            migrationBuilder.DropTable(
                name: "state_transitions",
                schema: "general");

            migrationBuilder.DropTable(
                name: "links",
                schema: "general");

            migrationBuilder.DropTable(
                name: "comments",
                schema: "general");

            migrationBuilder.DropTable(
                name: "medias",
                schema: "general");

            migrationBuilder.DropTable(
                name: "contacts",
                schema: "general");

            migrationBuilder.DropTable(
                name: "persons",
                schema: "general");

            migrationBuilder.DropTable(
                name: "states",
                schema: "general");

            migrationBuilder.DropTable(
                name: "workflows",
                schema: "general");

            migrationBuilder.DropTable(
                name: "media_types",
                schema: "general");

            migrationBuilder.DropTable(
                name: "contact_types",
                schema: "general");

            migrationBuilder.DropTable(
                name: "person_addresses",
                schema: "general");

            migrationBuilder.DropTable(
                name: "addresses",
                schema: "general");
        }
    }
}
