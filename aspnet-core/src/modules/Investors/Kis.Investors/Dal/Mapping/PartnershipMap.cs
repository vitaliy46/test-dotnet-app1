using System;
using Kis.Base.Dao.Mapping;
using Kis.Investors.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Investors.Dao.Mapping
{
    public class PartnershipMap : BaseEntityMap<Partnership, Guid>
    {
        public override void Configure(EntityTypeBuilder<Partnership> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.OrganizationId).IsRequired().HasColumnName("oranization_id");
            builder.Ignore(x => x.Organization);

            builder.Property(x => x.ManagerId).IsRequired(false).HasColumnName("manager_id");

            builder.ToTable("partnerships", "investor");
        }
    }
}
