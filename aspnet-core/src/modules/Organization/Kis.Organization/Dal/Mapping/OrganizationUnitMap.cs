using System;
using Kis.Base.Dao.Mapping;
using Kis.Organization.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Organization.Dao.Mapping
{
    public class OrganizationUnitMap : BaseEntityMap<OrganizationUnit, Guid>
    {
        public override void Configure(EntityTypeBuilder<OrganizationUnit> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ParentId).HasColumnName("parent_id");
            builder.Property(u => u.HeaderId).HasColumnName("header_id");
            builder.Ignore(x => x.Header);
            builder.Property(u => u.Name).HasColumnName("name");
            builder.HasMany(x => x.Contacts).WithOne(x => x.OrganizationUnit);

            builder.ToTable("organization_units", "organization");
        }
    }
}
