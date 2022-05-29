using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteOptionMap : BaseEntityMap<VoteOption, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteOption> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Text).IsRequired().HasColumnName("text");

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(u => u.Vote).WithMany(x=>x.Options).IsRequired().HasForeignKey(x => x.VoteId);

            builder.ToTable("vote_options", "voting");
        }
    }
}
