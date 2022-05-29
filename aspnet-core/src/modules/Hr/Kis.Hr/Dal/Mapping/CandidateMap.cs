using System;
using Kis.Base.Dao.Mapping;
using Kis.Hr.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Hr.Dao.Mapping
{
    public class CandidateMap : BaseEntityMap<Candidate, Guid>
    {
        public override void Configure(EntityTypeBuilder<Candidate> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.PersonId).HasColumnName("person_id");
            builder.Ignore(c => c.Person);
            builder.Property(c => c.VacancyId).HasColumnName("vacancy_id");
            builder.Property(c => c.InfomationSourceId).HasColumnName("infomation_source_id");
            builder.Property(c => c.OrganizationUnitId).HasColumnName("organization_unit_id");
            builder.Property(c => c.DesiredPosition).HasColumnName("desired_position");
            builder.Property(c => c.FinalPosition).HasColumnName("final_position");
            builder.Property(c => c.DesiredSalary).HasColumnName("desired_salary");
            builder.Property(c => c.ProbationSalary).HasColumnName("probation_salary");
            builder.Property(c => c.FinalSalary).HasColumnName("final_salary");
            builder.Property(c => c.Description).HasColumnName("description");
            builder.Property(c => c.AppearingDate).HasColumnName("appearing_date");
            builder.Property(c => c.ExternalId).HasColumnName("external_id");
            builder.Property(c => c.StateId).HasColumnName("state_id");
            builder.HasOne(x => x.State).WithMany().HasForeignKey(x => x.StateId).IsRequired();
            builder.HasOne(c => c.Vacancy).WithMany().HasForeignKey(i => i.VacancyId);
            builder.HasOne(c => c.InfomationSource).WithMany().HasForeignKey(i => i.InfomationSourceId);
            builder.HasOne(c => c.OrganizationUnit).WithMany().HasForeignKey(i => i.OrganizationUnitId);

            builder.ToTable("candidates", "hr");
        }
    }
}
