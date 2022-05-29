﻿// <auto-generated />
using System;
using Kis.Investors.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kis.Investors.Migrations
{
    [DbContext(typeof(InvestorsDbContext))]
    partial class InvestorsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kis.Investors.Api.Entity.InvestedProject", b =>
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

                    b.Property<Guid>("ManagingCompanyId")
                        .HasColumnName("managing_company_id");

                    b.Property<Guid?>("PartnershipId");

                    b.Property<Guid>("ProjectId")
                        .HasColumnName("project_id");

                    b.HasKey("Id");

                    b.HasIndex("PartnershipId");

                    b.ToTable("invested_projects","investor");
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.Investor", b =>
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

                    b.Property<double>("InvestmentShare")
                        .HasColumnName("investment_share");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("MemberId")
                        .HasColumnName("member_id");

                    b.Property<Guid>("ProjectId")
                        .HasColumnName("project_id");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProjectId");

                    b.ToTable("investors","investor");
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.MemberContactor", b =>
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

                    b.Property<Guid>("PartnershipMemberId")
                        .HasColumnName("partnership_member_id");

                    b.Property<Guid>("PersonId")
                        .HasColumnName("person_id");

                    b.HasKey("Id");

                    b.HasIndex("PartnershipMemberId")
                        .IsUnique();

                    b.ToTable("member_contactors","investor");
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.Partnership", b =>
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

                    b.Property<Guid?>("ManagerId")
                        .HasColumnName("manager_id");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnName("oranization_id");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("partnerships","investor");
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.PartnershipMember", b =>
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

                    b.Property<bool>("IsAllowSmsNotification")
                        .HasColumnName("is_allow_sms_notification");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnName("organization_id");

                    b.Property<Guid?>("PartnershipId");

                    b.HasKey("Id");

                    b.HasIndex("PartnershipId");

                    b.ToTable("partnership_members","investor");
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.InvestedProject", b =>
                {
                    b.HasOne("Kis.Investors.Api.Entity.Partnership")
                        .WithMany("Projects")
                        .HasForeignKey("PartnershipId");
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.Investor", b =>
                {
                    b.HasOne("Kis.Investors.Api.Entity.PartnershipMember", "Member")
                        .WithMany("Investors")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.Investors.Api.Entity.InvestedProject", "Project")
                        .WithMany("Investors")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.MemberContactor", b =>
                {
                    b.HasOne("Kis.Investors.Api.Entity.PartnershipMember", "PartnershipMember")
                        .WithOne("Contactor")
                        .HasForeignKey("Kis.Investors.Api.Entity.MemberContactor", "PartnershipMemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.Partnership", b =>
                {
                    b.HasOne("Kis.Investors.Api.Entity.PartnershipMember", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("Kis.Investors.Api.Entity.PartnershipMember", b =>
                {
                    b.HasOne("Kis.Investors.Api.Entity.Partnership")
                        .WithMany("Members")
                        .HasForeignKey("PartnershipId");
                });
#pragma warning restore 612, 618
        }
    }
}
