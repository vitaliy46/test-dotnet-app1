// <auto-generated />
using System;
using Kis.General.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kis.General.Migrations
{
    [DbContext(typeof(GeneralDbContext))]
    [Migration("20190518192210_AddConfirmationPassword")]
    partial class AddConfirmationPassword
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kis.General.Api.Entity.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int?>("AddressType")
                        .HasColumnName("address_type");

                    b.Property<string>("City")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<string>("Flat")
                        .HasColumnName("flat");

                    b.Property<string>("FullAddress")
                        .HasColumnName("full_address");

                    b.Property<string>("House")
                        .HasColumnName("house");

                    b.Property<string>("Housing")
                        .HasColumnName("housing");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("PostCode")
                        .HasColumnName("postcode");

                    b.Property<string>("Region")
                        .HasColumnName("region");

                    b.Property<string>("Street")
                        .HasColumnName("street");

                    b.HasKey("Id");

                    b.ToTable("addresses","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Comment", b =>
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
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.ToTable("comments","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.CommentLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("CommentId")
                        .HasColumnName("comment_id");

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

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("LinkId");

                    b.ToTable("comment_links","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.CommentMedia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("CommentId")
                        .HasColumnName("comment_id");

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

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("MediaId");

                    b.ToTable("comment_medias","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.ConfirmationPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool>("Confirmed")
                        .HasColumnName("confirmed");

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

                    b.Property<long>("NumberOfAttempts")
                        .HasColumnName("number_of_attempts");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("confirmation_passwords","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("ContactType")
                        .HasColumnName("contact_type");

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

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("contacts","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Link", b =>
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

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Url")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("links","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Media", b =>
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

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("FileName")
                        .HasColumnName("file_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Label")
                        .HasColumnName("label");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Path")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.HasIndex("Label");

                    b.ToTable("medias","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.MediaType", b =>
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
                        .HasColumnName("name");

                    b.Property<string>("SystemName")
                        .HasColumnName("system_name");

                    b.HasKey("Id");

                    b.ToTable("media_types","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("AddressId")
                        .HasColumnName("address_id");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<string>("FullName")
                        .HasColumnName("full_name");

                    b.Property<int?>("Gender")
                        .HasColumnName("gender");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .HasColumnName("patronymic");

                    b.Property<string>("PhotoUri")
                        .HasColumnName("photo_uri");

                    b.Property<string>("Snils")
                        .HasColumnName("snils");

                    b.Property<string>("Surname")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("persons","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.PersonAddress", b =>
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

                    b.Property<Guid>("PersonId")
                        .HasColumnName("person_id");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("person_addresses","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.PersonContact", b =>
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

                    b.Property<Guid>("PersonId")
                        .HasColumnName("person_id");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("PersonId");

                    b.ToTable("person_contacts","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.PersonUser", b =>
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

                    b.Property<Guid>("PersonId")
                        .HasColumnName("person_id");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("person_users","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Policy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnName("begin_date");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnName("creator_user_id");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnName("deleter_user_id");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time");

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Number")
                        .HasColumnName("number");

                    b.Property<Guid>("PersonId")
                        .HasColumnName("person_id");

                    b.Property<string>("Series")
                        .HasColumnName("series");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("policies","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.State", b =>
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

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("states","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.StateTransition", b =>
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

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<Guid>("StateFromId")
                        .HasColumnName("state_from_id");

                    b.Property<Guid>("StateToId")
                        .HasColumnName("state_to_id");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnName("workflow_id");

                    b.HasKey("Id");

                    b.HasIndex("StateFromId");

                    b.HasIndex("StateToId");

                    b.HasIndex("WorkflowId");

                    b.ToTable("state_transitions","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Workflow", b =>
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

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnName("last_modifier_user_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("workflows","general");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.CommentLink", b =>
                {
                    b.HasOne("Kis.General.Api.Entity.Comment", "Comment")
                        .WithMany("Links")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.General.Api.Entity.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.General.Api.Entity.CommentMedia", b =>
                {
                    b.HasOne("Kis.General.Api.Entity.Comment", "Comment")
                        .WithMany("Medias")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.General.Api.Entity.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Person", b =>
                {
                    b.HasOne("Kis.General.Api.Entity.PersonAddress", "Address")
                        .WithOne()
                        .HasForeignKey("Kis.General.Api.Entity.Person", "AddressId");
                });

            modelBuilder.Entity("Kis.General.Api.Entity.PersonAddress", b =>
                {
                    b.HasOne("Kis.General.Api.Entity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.General.Api.Entity.PersonContact", b =>
                {
                    b.HasOne("Kis.General.Api.Entity.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.General.Api.Entity.Person", "Person")
                        .WithMany("Contacts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.General.Api.Entity.PersonUser", b =>
                {
                    b.HasOne("Kis.General.Api.Entity.Person", "Person")
                        .WithOne("PersonUser")
                        .HasForeignKey("Kis.General.Api.Entity.PersonUser", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.General.Api.Entity.Policy", b =>
                {
                    b.HasOne("Kis.General.Api.Entity.Person", "Person")
                        .WithMany("Policies")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kis.General.Api.Entity.StateTransition", b =>
                {
                    b.HasOne("Kis.General.Api.Entity.State", "StateFrom")
                        .WithMany()
                        .HasForeignKey("StateFromId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.General.Api.Entity.State", "StateTo")
                        .WithMany()
                        .HasForeignKey("StateToId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kis.General.Api.Entity.Workflow", "Workflow")
                        .WithMany()
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
