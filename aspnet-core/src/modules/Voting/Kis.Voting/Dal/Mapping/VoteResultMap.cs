using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteResultMap : BaseEntityMap<VoteResult, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteResult> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.SignedResult).IsRequired().HasColumnName("signed_result");

            builder.Property(u => u.TextResult).IsRequired().HasColumnName("text_result");

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(u => u.Vote).WithMany().IsRequired().HasForeignKey(x => x.VoteId);

            builder.ToTable("vote_results", "voting");
        }
    }
}
