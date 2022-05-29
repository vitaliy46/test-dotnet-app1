using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class IssuePriorityMap : BaseEntityMap<IssuePriority, Guid>
    {
        public override void Configure(EntityTypeBuilder<IssuePriority> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Name).IsRequired().HasColumnName("name");
            
            builder.ToTable("issue_priorities", "task_tracker");
        }
    }
}
