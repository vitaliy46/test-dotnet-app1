using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteMemberMap : BaseEntityMap<VoteMember, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteMember> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Name).IsRequired().HasColumnName("name");

            builder.Property(u => u.UserId).IsRequired().HasColumnName("user_id");
            builder.Ignore(x => x.User);

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(x => x.Vote).WithMany().IsRequired().HasForeignKey(x => x.VoteId);

            builder.Property(u => u.VoteMemberContactId).IsRequired().HasColumnName("vote_member_contact_id");
            builder.HasOne(x => x.VoteMemberContact).WithOne().IsRequired().HasForeignKey<VoteMember>(x => x.VoteMemberContactId);

            builder.ToTable("vote_members", "voting");
        }
    }
}
