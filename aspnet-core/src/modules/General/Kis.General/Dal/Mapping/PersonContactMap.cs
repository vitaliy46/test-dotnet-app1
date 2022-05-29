using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class PersonContactMap : BaseEntityMap<PersonContact, Guid>
    {
        public override void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.PersonId).HasColumnName("person_id");
            builder.HasOne(x => x.Person).WithMany(x => x.Contacts).HasForeignKey(x => x.PersonId);

            builder.Property(x => x.ContactId).HasColumnName("contact_id");
            builder.HasOne(x => x.Contact).WithMany().HasForeignKey(x => x.ContactId);

            builder.ToTable("person_contacts", "general");
        }
    }
}
