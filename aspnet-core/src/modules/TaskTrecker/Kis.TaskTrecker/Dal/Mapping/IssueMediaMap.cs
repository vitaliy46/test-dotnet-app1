using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class IssueMediaMap : BaseEntityMap<IssueMedia, Guid>
    {
        public override void Configure(EntityTypeBuilder<IssueMedia> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.IssueId).IsRequired().HasColumnName("issue_id");
            builder.HasOne(u => u.Issue).WithMany(x => x.Medias).IsRequired().HasForeignKey(x => x.IssueId);

            builder.Property(u => u.MediaId).IsRequired().HasColumnName("media_id");
            builder.Ignore(x => x.Media);
            

            builder.ToTable("issue_medias", "task_tracker");
        }
    }
}
