using System;
using Kis.Base.Dao.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Inventory.Dao.Mapping
{
    public class InventoryMap : BaseEntityMap<Api.Entity.Inventory, Guid>
    {
        public override void Configure(EntityTypeBuilder<Api.Entity.Inventory> builder)
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

            builder.ToTable("inventories", "inventory");
        }
    }
}
