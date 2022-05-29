using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class IssueWorkflowMap : BaseEntityMap<IssueWorkflow, Guid>
    {
        public override void Configure(EntityTypeBuilder<IssueWorkflow> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ProjectId).IsRequired().HasColumnName("project_id");
            builder.HasOne(u => u.Project).WithMany().IsRequired().HasForeignKey(x => x.ProjectId);

            builder.Property(u => u.WorkflowId).IsRequired().HasColumnName("worklow_id");
            builder.Ignore(x => x.Workflow);

            builder.ToTable("issue_workflows", "task_tracker");
        }
    }
}
