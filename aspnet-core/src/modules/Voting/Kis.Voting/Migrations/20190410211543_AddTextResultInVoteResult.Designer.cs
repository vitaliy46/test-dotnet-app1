﻿// <auto-generated />
using System;
using Kis.Voting.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kis.Voting.Migrations
{
    [DbContext(typeof(VotingDbContext))]
    [Migration("20190410211543_AddTextResultInVoteResult")]
    partial class AddTextResultInVoteResult
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kis.Voting.Api.Entity.Bulletin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.Property<Guid>("VoteMemberId")
                        .HasColumnName("vote_member_id");

                    b.Property<string>("VotingResultXml")
                        .HasColumnName("voting_result_xml");

                    b.HasKey("Id");

                    b.HasIndex("VoteId");

                    b.HasIndex("VoteMemberId");

                    b.ToTable("bulletins","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.BulletinSelectedOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("BulletinId")
                        .HasColumnName("bulletin_id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("SelectedOptionId")
                        .HasColumnName("selected_option_id");

                    b.HasKey("Id");

                    b.HasIndex("BulletinId");

                    b.HasIndex("SelectedOptionId");

                    b.ToTable("bulletin_selected_options","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.NoticeReceiptConfimation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("ConfimationXml")
                        .HasColumnName("confimation_xml");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("MemberId")
                        .HasColumnName("member_id");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("VoteId");

                    b.ToTable("notice_receipt_confimations","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.Vote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("BeginDateTime")
                        .HasColumnName("begin_date_time");

                    b.Property<Guid>("ContextId")
                        .HasColumnName("context_id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<float>("DecisionMakersPct")
                        .HasColumnName("decision_makers_pct");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnName("end_date_time");

                    b.Property<long>("InitiatorId")
                        .HasColumnName("initiator_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsMultilieChoice")
                        .HasColumnName("is_multilice_choice");

                    b.Property<bool>("IsPublished")
                        .HasColumnName("is_published");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<DateTime>("NoteSendingDateTime")
                        .HasColumnName("note_sending_date_time");

                    b.Property<long>("Number")
                        .HasColumnName("number");

                    b.Property<float>("QuorumPct")
                        .HasColumnName("quorum_pct");

                    b.Property<int?>("ReportFormat");

                    b.Property<string>("Text")
                        .HasColumnName("text");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnName("theme");

                    b.Property<Guid?>("VoteResultId");

                    b.Property<int>("VotingCalculationType")
                        .HasColumnName("voting_calculation_type");

                    b.HasKey("Id");

                    b.HasIndex("VoteResultId");

                    b.ToTable("votes","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("LinkId")
                        .HasColumnName("link_id");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.HasKey("Id");

                    b.HasIndex("VoteId");

                    b.ToTable("vote_links","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteMedia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("MediaId")
                        .HasColumnName("media_id");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.HasKey("Id");

                    b.HasIndex("VoteId");

                    b.ToTable("vote_medias","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteMemberVoteInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.Property<Guid>("VoteMemberContactId")
                        .HasColumnName("vote_member_contact_id");

                    b.HasKey("Id");

                    b.HasIndex("VoteId");

                    b.HasIndex("VoteMemberContactId")
                        .IsUnique();

                    b.ToTable("vote_members","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteMemberContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("ContactId")
                        .HasColumnName("contact_id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.HasKey("Id");

                    b.ToTable("vote_member_contacts","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteNotice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnName("message");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.HasKey("Id");

                    b.HasIndex("VoteId");

                    b.ToTable("vote_notices","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnName("text");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.HasKey("Id");

                    b.HasIndex("VoteId");

                    b.ToTable("vote_options","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("ReportFileId")
                        .HasColumnName("report_file_id");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.HasKey("Id");

                    b.HasIndex("VoteId");

                    b.ToTable("vote_reports","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteReportMedia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("MediaId")
                        .HasColumnName("media_id");

                    b.Property<Guid>("VoteReportId")
                        .HasColumnName("vote_report_id");

                    b.HasKey("Id");

                    b.HasIndex("VoteReportId");

                    b.ToTable("vote_report_medias","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("SignedResult")
                        .IsRequired()
                        .HasColumnName("signed_result");

                    b.Property<string>("TextResult")
                        .IsRequired()
                        .HasColumnName("text_result");

                    b.Property<Guid>("VoteId")
                        .HasColumnName("vote_id");

                    b.HasKey("Id");

                    b.HasIndex("VoteId");

                    b.ToTable("vote_results","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsNeedSign")
                        .HasColumnName("is_need_sign");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.Property<int>("VotingCalculationType")
                        .HasColumnName("voting_calculation_type");

                    b.HasKey("Id");

                    b.ToTable("vote_settings","voting");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.Bulletin", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany()
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.Voting.Api.Entity.VoteMemberVoteInfo", "VoteMemberVoteInfo")
                        .WithMany()
                        .HasForeignKey("VoteMemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.BulletinSelectedOption", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Bulletin", "Bulletin")
                        .WithMany("BulletinSelectedOptions")
                        .HasForeignKey("BulletinId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.Voting.Api.Entity.VoteOption", "SelectedOption")
                        .WithMany()
                        .HasForeignKey("SelectedOptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.NoticeReceiptConfimation", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.VoteMemberVoteInfo", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany()
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.Vote", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.VoteResult", "VoteResult")
                        .WithMany()
                        .HasForeignKey("VoteResultId");
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteLink", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany("Links")
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteMedia", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany("Medias")
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteMemberVoteInfo", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany()
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.Voting.Api.Entity.VoteMemberContact", "VoteMemberContact")
                        .WithOne()
                        .HasForeignKey("Kis.Voting.Api.Entity.VoteMemberVoteInfo", "VoteMemberContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteNotice", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany()
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteOption", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany("Options")
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteReport", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany()
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteReportMedia", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.VoteReport", "VoteReport")
                        .WithMany("Medias")
                        .HasForeignKey("VoteReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Voting.Api.Entity.VoteResult", b =>
                {
                    b.HasOne("Kis.Voting.Api.Entity.Vote", "Vote")
                        .WithMany()
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
