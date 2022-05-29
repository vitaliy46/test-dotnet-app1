using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class StateTransitionMap : BaseEntityMap<StateTransition, Guid>
    {
        public override void Configure(EntityTypeBuilder<StateTransition> builder)
        {
            base.Configure(builder);
            builder.Property(s => s.StateFromId).HasColumnName("state_from_id");
            builder.Property(s => s.StateToId).HasColumnName("state_to_id");
            builder.Property(s => s.Name).HasColumnName("name");
            builder.Property(s => s.Description).HasColumnName("description");

            builder.Property(s => s.WorkflowId).HasColumnName("workflow_id");
            builder.HasOne(x => x.Workflow).WithMany().HasForeignKey(x => x.WorkflowId);

            builder.ToTable("state_transitions", "general");
        }
    }
}
