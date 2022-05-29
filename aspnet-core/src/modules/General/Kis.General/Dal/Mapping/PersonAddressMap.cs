using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class PersonAddressMap : BaseEntityMap<PersonAddress, Guid>
    {
        public override void Configure(EntityTypeBuilder<PersonAddress> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.PersonId).HasColumnName("person_id");

            builder.Property(x => x.AddressId).HasColumnName("address_id");
            builder.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressId);

            builder.ToTable("person_addresses", "general");
        }
    }
}
