using System;
using Kis.Base.Dao.Mapping;
using Kis.Staff.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Staff.Dao.Mapping
{
    public class EmployeeMap : BaseEntityMap<Employee, Guid>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.PersonId).HasColumnName("person_id");
            builder.Ignore(e => e.Person);

            builder.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            builder.Property(e => e.EmploymentDate).HasColumnName("employment_date").IsRequired(false);

            builder.HasOne(e => e.OrganizationUnit).WithMany().HasForeignKey(i => i.OrganizationUnitId);

            builder.ToTable("employees", "hr");
        }
    }
}
