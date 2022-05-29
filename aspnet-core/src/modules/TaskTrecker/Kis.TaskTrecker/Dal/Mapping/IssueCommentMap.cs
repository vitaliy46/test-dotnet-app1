using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class IssueCommentMap : BaseEntityMap<IssueComment, Guid>
    {
        public override void Configure(EntityTypeBuilder<IssueComment> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.CommentId).IsRequired().HasColumnName("comment_id");
            builder.Ignore(u => u.Comment);

            builder.Property(u => u.WorkTime).IsRequired(false).HasColumnName("work_time");

            builder.Property(u => u.IssueId).IsRequired().HasColumnName("issue_id");
            builder.HasOne(u => u.Issue).WithMany().HasForeignKey(x=>x.IssueId).IsRequired();

            builder.Property(u => u.StateId).IsRequired().HasColumnName("issue_state_id");
            builder.HasOne(u => u.State).WithMany().HasForeignKey(x=>x.StateId).IsRequired();
            
            builder.ToTable("issue_comments", "task_tracker");
        }
    }
}
