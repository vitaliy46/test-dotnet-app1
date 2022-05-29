using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteLinkMap : BaseEntityMap<VoteLink, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteLink> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(x => x.Vote).WithMany(x=>x.Links).IsRequired().HasForeignKey(x => x.VoteId);

            builder.Property(u => u.LinkId).IsRequired().HasColumnName("link_id");
            builder.Ignore(x => x.Link);

            builder.ToTable("vote_links", "voting");
        }
    }
}
