using System;
using Kis.Base.Dao.Mapping;
using Kis.Staff.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Staff.Dao.Mapping
{
    public class PositionAppointmentMap : BaseEntityMap<PositionAppointment, Guid>
    {
        public override void Configure(EntityTypeBuilder<PositionAppointment> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.EmployeeId).HasColumnName("employee_id");
            builder.HasOne(p => p.Employee).WithMany(a => a.PositionAppointments).HasForeignKey(i => i.EmployeeId);
            builder.Property(p => p.PositionId).HasColumnName("position_id");
            builder.HasOne(p => p.Position).WithMany().HasForeignKey(i => i.PositionId);

            
            

            builder.ToTable("position_appointments", "hr");
        }
    }
}
