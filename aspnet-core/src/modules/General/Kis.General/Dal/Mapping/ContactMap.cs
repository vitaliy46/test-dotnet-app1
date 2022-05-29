using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class ContactMap : BaseEntityMap<Contact, Guid>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Value).HasColumnName("value");

            builder.Property(u => u.ContactType).HasColumnName("contact_type");

            builder.ToTable("contacts", "general");
        }
    }
}
