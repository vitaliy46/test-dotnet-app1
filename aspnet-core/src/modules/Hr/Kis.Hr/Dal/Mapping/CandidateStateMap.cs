using System;
using Kis.Base.Dao.Mapping;
using Kis.Hr.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Hr.Dao.Mapping
{
    public class CandidateStateMap : BaseEntityMap<CandidateState, Guid>
    {
        public override void Configure(EntityTypeBuilder<CandidateState> builder)
        {
            base.Configure(builder);
            builder.Property(s => s.CandidateId).HasColumnName("candidate_id");
            builder.HasOne(s => s.Candidate).WithMany().HasForeignKey(i => i.CandidateId).IsRequired();

            builder.Property(s => s.StateId).HasColumnName("state_id");
            builder.Ignore(s => s.State);

            builder.Property(s => s.TransitionDate).HasColumnName("transition_date");
            builder.Property(s => s.Comment).HasColumnName("comment");
            
            builder.ToTable("candidate_states", "hr");
        }
    }
}
