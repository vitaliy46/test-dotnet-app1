using System;
using Kis.Base.Dao.Mapping;
using Kis.Crm.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Crm.Dao.Mapping
{
    public class DealMap : BaseEntityMap<Deal, Guid>
    {
        public override void Configure(EntityTypeBuilder<Deal> builder)
        {
            base.Configure(builder);
            //builder.Property(u => u.Street).IsRequired(false).HasColumnName("street");
            //builder.Property(u => u.House).IsRequired(false).HasColumnName("house");
            //builder.Property(u => u.Housing).IsRequired(false).HasColumnName("housing");
            //builder.Property(u => u.Flat).IsRequired(false).HasColumnName("flat");
            //builder.Property(u => u.PostCode).IsRequired(false).HasColumnName("postcode");
            //builder.Property(u => u.City).HasColumnName("city");
            //builder.Property(u => u.Region).HasColumnName("region");
            //builder.Property(u => u.Country).HasColumnName("country");
            //builder.Property(u => u.AddressType).HasColumnName("address_type").IsRequired(false);

            builder.ToTable("deals", "crm");
        }
    }
}
