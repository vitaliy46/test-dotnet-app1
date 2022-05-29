using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class BulletinMap : BaseEntityMap<Bulletin, Guid>
    {
        public override void Configure(EntityTypeBuilder<Bulletin> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.VoteMemberId).IsRequired().HasColumnName("vote_member_id");
            builder.HasOne(x => x.VoteMember).WithMany().IsRequired().HasForeignKey(x => x.VoteMemberId);

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(x => x.Vote).WithMany().IsRequired().HasForeignKey(x => x.VoteId);

            builder.Property(u => u.VotingResultXml).IsRequired(false).HasColumnName("voting_result_xml");

            builder.ToTable("bulletins", "voting");
        }
    }
}
