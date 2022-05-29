using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteNoticeMap : BaseEntityMap<VoteNotice, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteNotice> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Message).IsRequired().HasColumnName("message");

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(u => u.Vote).WithMany().IsRequired().HasForeignKey(x=>x.VoteId);
           
            builder.ToTable("vote_notices", "voting");
        }
    }
}
