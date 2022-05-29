using System;
using Kis.Base.Dao.Mapping;
using Kis.Investors.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Investors.Dao.Mapping
{
    public class InvestedProjectMap : BaseEntityMap<InvestedProject, Guid>
    {
        public override void Configure(EntityTypeBuilder<InvestedProject> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ManagingCompanyId).IsRequired().HasColumnName("managing_company_id");
            builder.Ignore(x => x.ManagingCompany);
            builder.Property(x => x.ProjectId).IsRequired().HasColumnName("project_id");
            builder.Ignore(x => x.Project);

            builder.HasMany(x => x.Investors).WithOne(x => x.Project);
           
            builder.ToTable("invested_projects", "investor");
        }
    }
}
