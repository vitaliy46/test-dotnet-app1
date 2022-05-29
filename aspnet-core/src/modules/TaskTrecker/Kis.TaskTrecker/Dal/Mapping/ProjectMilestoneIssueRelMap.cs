using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class ProjectMilestoneIssueRelMap : BaseEntityMap<ProjectMilestoneIssueRel, Guid>
    {
        public override void Configure(EntityTypeBuilder<ProjectMilestoneIssueRel> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.IssueId).IsRequired().HasColumnName("issue_id");
            builder.HasOne(u => u.Issue).WithMany().IsRequired().HasForeignKey(x => x.IssueId);

            builder.Property(x => x.MilestoneId).IsRequired().HasColumnName("project_milestone_id");
            builder.HasOne(u => u.Milestone).WithMany(x=>x.KeyIssues).IsRequired().HasForeignKey(x=> x.MilestoneId);


            builder.ToTable("project_milestone_issue_rels", "task_tracker");
        }
    }
}
