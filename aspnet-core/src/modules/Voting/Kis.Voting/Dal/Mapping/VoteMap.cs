using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteMap : BaseEntityMap<Vote, Guid>
    {
        public override void Configure(EntityTypeBuilder<Vote> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Number).IsRequired().HasColumnName("number");
            builder.Property(u => u.Theme).IsRequired().HasColumnName("theme");
            builder.Property(u => u.Text).IsRequired(false).HasColumnName("text");
            builder.Property(u => u.ContextId).IsRequired().HasColumnName("context_id");
            builder.Property(u => u.QuorumPct).IsRequired().HasColumnName("quorum_pct");
            builder.Property(u => u.DecisionMakersPct).IsRequired().HasColumnName("decision_makers_pct");
            builder.Property(u => u.InitiatorId).IsRequired().HasColumnName("initiator_id");
            builder.Property(u => u.IsMultilieChoice).IsRequired().HasColumnName("is_multilice_choice");
            builder.Property(u => u.IsPublished).IsRequired().HasColumnName("is_published");
            builder.Property(u => u.NoteSendingDateTime).HasColumnName("note_sending_date_time");
            builder.Property(u => u.BeginDateTime).HasColumnName("begin_date_time");
            builder.Property(u => u.EndDateTime).HasColumnName("end_date_time");
            builder.Property(u => u.VotingCalculationType).HasColumnName("voting_calculation_type");
            builder.HasMany(x => x.Options).WithOne(x=>x.Vote);
            builder.HasMany(x => x.Medias).WithOne(x=>x.Vote);
            builder.HasMany(x => x.Links).WithOne(x=>x.Vote);

            builder.ToTable("votes", "voting");
        }
    }
}
