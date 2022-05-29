using System;
using Kis.Base.Dao.Mapping;
using Kis.Staff.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Staff.Dao.Mapping
{
    public class KarmaMap : BaseEntityMap<Karma, Guid>
    {
        public override void Configure(EntityTypeBuilder<Karma> builder)
        {
            base.Configure(builder);
            builder.Property(k => k.EmployeeId).HasColumnName("employee_id");
            builder.HasOne(k => k.Employee).WithMany(e => e.Karmas).HasForeignKey(i => i.EmployeeId);

            builder.Property(k => k.KarmaTypeId).HasColumnName("karma_type_id");
            builder.HasOne(k => k.KarmaType).WithOne().HasForeignKey<Karma>(i => i.KarmaTypeId);

            builder.Property(k => k.CreatedById).HasColumnName("created_by_id");
            
            builder.ToTable("karma", "hr");
        }
    }
}
