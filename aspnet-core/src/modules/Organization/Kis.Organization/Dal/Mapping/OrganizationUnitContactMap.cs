using System;
using Kis.Base.Dao.Mapping;
using Kis.Organization.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Organization.Dao.Mapping
{
    public class OrganizationUnitContactMap : BaseEntityMap<OrganizationUnitContact, Guid>
    {
        public override void Configure(EntityTypeBuilder<OrganizationUnitContact> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.OrganizationUnitId).HasColumnName("organization_unit_id");
            builder.HasOne(x => x.OrganizationUnit).WithMany(x=>x.Contacts).HasForeignKey(x=>x.OrganizationUnitId);

            builder.Property(u => u.ContactId).HasColumnName("contact_id");
            builder.Ignore(x=>x.Contact);

            builder.ToTable("organization_unit_contacts", "organization");
        }
    }
}
