using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class ProjectStateMap : BaseEntityMap<ProjectState, Guid>
    {
        public override void Configure(EntityTypeBuilder<ProjectState> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.StateId).IsRequired().HasColumnName("state_id");
            builder.Ignore(x => x.State);
            builder.Property(s => s.Order).HasColumnName("order");

            builder.ToTable("project_states", "task_tracker");
        }
    }
}
