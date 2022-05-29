using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class ProjectMilestoneMap : BaseEntityMap<ProjectMilestone, Guid>
    {
        public override void Configure(EntityTypeBuilder<ProjectMilestone> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Tag).IsRequired().HasColumnName("tag");
            builder.Property(u => u.Description).IsRequired(false).HasColumnName("description");
            builder.Property(u => u.Name).IsRequired(false).HasColumnName("name");
            builder.HasMany(u => u.KeyIssues);


            builder.ToTable("project_milestones", "task_tracker");
        }
    }
}
