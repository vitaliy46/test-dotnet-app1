using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class IssueStateMap : BaseEntityMap<IssueState, Guid>
    {
        public override void Configure(EntityTypeBuilder<IssueState> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.IssueId).IsRequired().HasColumnName("issue_id");
            builder.HasOne(u => u.Issue).WithMany().IsRequired().HasForeignKey(x => x.IssueId);

            builder.Property(u => u.StateId).IsRequired().HasColumnName("state_id");
            builder.Ignore(x => x.State);
            builder.Property(s => s.Order).HasColumnName("order");

            builder.ToTable("issue_states", "task_tracker");
        }
    }
}
