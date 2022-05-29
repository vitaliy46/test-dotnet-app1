using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class IssueMap: BaseEntityMap<Issue, Guid>
    {
        public override void Configure(EntityTypeBuilder<Issue> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Title).IsRequired().HasColumnName("title");
            builder.Property(u => u.Dedline).IsRequired(false).HasColumnName("dedline");
            builder.Property(u => u.Description).IsRequired(false).HasColumnName("description");
            builder.Property(u => u.PlannedTime).IsRequired(false).HasColumnName("planned_time");
            builder.Property(u => u.LastCommentUserId).IsRequired(false).HasColumnName("last_comment_user_id");
            builder.Property(u => u.LastRead).IsRequired(false).HasColumnName("last_read");

            builder.Property(u => u.ParentId).HasColumnName("parent_id");
            builder.HasOne(x => x.Parent).WithMany().IsRequired(false).HasForeignKey(x=>x.ParentId);

            builder.Property(u => u.PerformerId).IsRequired(false).HasColumnName("performer_id");
            builder.Ignore(x => x.Performer);

            builder.Property(u => u.ProjectId).HasColumnName("project_id").IsRequired();
            builder.HasOne(x => x.Project).WithMany().IsRequired().HasForeignKey(x => x.ProjectId);

            builder.HasOne(x => x.Priority).WithMany().IsRequired().HasForeignKey(x=>x.PriorityId);
            builder.Property(x => x.PriorityId).IsRequired().HasColumnName("priority_id");

            builder.Property(u => u.StateId).HasColumnName("state_id").IsRequired();
            builder.HasOne(x => x.State).WithMany().IsRequired().HasForeignKey(x => x.StateId);


            builder.HasMany(u => u.Medias).WithOne(x=>x.Issue);
            builder.HasMany(u => u.Comments).WithOne(x =>x.Issue);

            builder.ToTable("issues", "task_tracker");
        }
    }
}
