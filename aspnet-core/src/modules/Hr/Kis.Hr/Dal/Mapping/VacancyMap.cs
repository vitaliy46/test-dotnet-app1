using System;
using Kis.Base.Dao.Mapping;
using Kis.Hr.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Hr.Dao.Mapping
{
    public class VacancyMap : BaseEntityMap<Vacancy, Guid>
    {
        public override void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            base.Configure(builder);
            builder.Property(v => v.OrganizationUnitId).HasColumnName("organization_unit_id");
            builder.Property(v => v.PositionId).HasColumnName("position_id");
            builder.Property(v => v.Description).HasColumnName("description");

            builder.HasOne(v => v.Position).WithMany().HasForeignKey(i => i.PositionId).IsRequired();
            builder.HasOne(v => v.OrganizationUnit).WithMany().HasForeignKey(i => i.OrganizationUnitId);

            builder.ToTable("vacansies", "hr");
        }
    }
}
