using System;
using Kis.Base.Dao.Mapping;
using Kis.Staff.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Staff.Dao.Mapping
{
    public class PositionMap : BaseEntityMap<Position, Guid>
    {
        public override void Configure(EntityTypeBuilder<Position> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.OrganizationUnitId).HasColumnName("organization_unit_id").IsRequired();
            builder.HasOne(p => p.OrganizationUnit).WithMany().HasForeignKey(p => p.OrganizationUnitId).IsRequired();
            builder.Property(p => p.Name).HasColumnName("name");

            builder.ToTable("positions", "hr");
        }
    }
}
