using Kis.Base.Dao.Mapping;
using Kis.Organization.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kis.Organization.Dal.Mapping
{
    class OrganizationUnitUserMap : BaseEntityMap<OrganizationUnitUser, Guid?>
    {
        public override void Configure(EntityTypeBuilder<OrganizationUnitUser> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.OrganizationUnitId).HasColumnName("organization_unit_id");
            builder.HasOne(x => x.OrganizationUnit).WithOne().HasForeignKey<OrganizationUnitUser>(x => x.OrganizationUnitId);

            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Ignore(x => x.User);

            builder.ToTable("organization_unit_users", "organization");
        }
    }
}
