﻿// <auto-generated />
using System;
using Kis.Organization.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kis.Organization.Migrations
{
    [DbContext(typeof(OrganizationDbContext))]
    [Migration("20190322135251_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kis.Organization.Api.Entity.OrganizationUnit", b =>
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

                    b.Property<Guid?>("HeaderId")
                        .HasColumnName("header_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnName("parent_id");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("organization_units","organization");
                });

            modelBuilder.Entity("Kis.Organization.Api.Entity.OrganizationUnitAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AddressId")
                        .HasColumnName("address_id");

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

                    b.Property<Guid>("OrganizationUnitId")
                        .HasColumnName("organization_unit_id");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationUnitId")
                        .IsUnique();

                    b.ToTable("organization_unit_addresses","organization");
                });

            modelBuilder.Entity("Kis.Organization.Api.Entity.OrganizationUnitContact", b =>
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

                    b.Property<Guid>("OrganizationUnitId")
                        .HasColumnName("organization_unit_id");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationUnitId");

                    b.ToTable("organization_unit_contacts","organization");
                });

            modelBuilder.Entity("Kis.Organization.Api.Entity.OrganizationUnitUser", b =>
                {
                    b.Property<Guid?>("Id")
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

                    b.Property<Guid>("OrganizationUnitId")
                        .HasColumnName("organization_unit_id");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationUnitId")
                        .IsUnique();

                    b.ToTable("organization_unit_users","organization");
                });

            modelBuilder.Entity("Kis.Organization.Api.Entity.OrganizationUnit", b =>
                {
                    b.HasOne("Kis.Organization.Api.Entity.OrganizationUnit", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Kis.Organization.Api.Entity.OrganizationUnitAddress", b =>
                {
                    b.HasOne("Kis.Organization.Api.Entity.OrganizationUnit", "OrganizationUnit")
                        .WithOne("OrganizationUnitAddress")
                        .HasForeignKey("Kis.Organization.Api.Entity.OrganizationUnitAddress", "OrganizationUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Organization.Api.Entity.OrganizationUnitContact", b =>
                {
                    b.HasOne("Kis.Organization.Api.Entity.OrganizationUnit", "OrganizationUnit")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.Organization.Api.Entity.OrganizationUnitUser", b =>
                {
                    b.HasOne("Kis.Organization.Api.Entity.OrganizationUnit", "OrganizationUnit")
                        .WithOne()
                        .HasForeignKey("Kis.Organization.Api.Entity.OrganizationUnitUser", "OrganizationUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
