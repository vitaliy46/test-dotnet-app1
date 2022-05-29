using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class AddressMap : BaseEntityMap<Address, Guid>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Street).IsRequired(false).HasColumnName("street");
            builder.Property(u => u.House).IsRequired(false).HasColumnName("house");
            builder.Property(u => u.Housing).IsRequired(false).HasColumnName("housing");
            builder.Property(u => u.Flat).IsRequired(false).HasColumnName("flat");
            builder.Property(u => u.PostCode).IsRequired(false).HasColumnName("postcode");
            builder.Property(u => u.City).HasColumnName("city").IsRequired(false);
            builder.Property(u => u.Region).HasColumnName("region").IsRequired(false);
            builder.Property(u => u.Country).HasColumnName("country").IsRequired(false);
            builder.Property(u => u.FullAddress).HasColumnName("full_address").IsRequired(false);
            builder.Property(u => u.AddressType).HasColumnName("address_type").IsRequired(false);

            builder.ToTable("addresses", "general");
        }
    }
}
