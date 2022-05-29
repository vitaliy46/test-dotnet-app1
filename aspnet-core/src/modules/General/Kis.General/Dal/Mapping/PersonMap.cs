using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class PersonMap: BaseEntityMap<Person, Guid>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.FullName).HasColumnName("full_name").IsRequired(false);
            builder.Property(x => x.BirthDate).HasColumnName("birth_date").IsRequired(false);
            builder.Property(x => x.Name).HasColumnName("name").IsRequired(false);
            builder.Property(x => x.Patronymic).HasColumnName("patronymic").IsRequired(false);
            builder.Property(x => x.PhotoUri).HasColumnName("photo_uri").IsRequired(false);
            builder.Property(x => x.Snils).HasColumnName("snils").IsRequired(false);
            builder.Property(x => x.Surname).HasColumnName("surname").IsRequired(false);
            builder.Property(x => x.Gender).HasColumnName("gender").IsRequired(false);
            builder.Property(x => x.AddressId).HasColumnName("address_id").IsRequired(false);
            builder.HasOne(x => x.Address).WithOne().HasForeignKey<Person>(x=>x.AddressId).IsRequired(false);
            builder.HasMany(x => x.Policies).WithOne(x => x.Person);
            builder.HasMany(x => x.Contacts).WithOne(x => x.Person);

            builder.ToTable("persons", "general");
        }
    }
}
