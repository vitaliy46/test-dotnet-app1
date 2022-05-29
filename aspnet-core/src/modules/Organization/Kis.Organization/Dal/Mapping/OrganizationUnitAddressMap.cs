using System;
using Kis.Base.Dao.Mapping;
using Kis.Organization.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Organization.Dao.Mapping
{
    public class OrganizationUnitAddressMap : BaseEntityMap<OrganizationUnitAddress, Guid>
    {
        public override void Configure(EntityTypeBuilder<OrganizationUnitAddress> builder)
        {
            base.Configure(builder);
            builder.Property(a => a.AddressId).HasColumnName("address_id");
            builder.Ignore(a => a.Address);
            builder.Property(a => a.OrganizationUnitId).HasColumnName("organization_unit_id");
            builder.HasOne(a => a.OrganizationUnit).WithOne(u => u.OrganizationUnitAddress)
                .HasForeignKey<OrganizationUnitAddress>(i => i.OrganizationUnitId);

            builder.ToTable("organization_unit_addresses", "organization");
        }
    }
}
