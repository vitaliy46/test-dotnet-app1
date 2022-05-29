using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteMemberContactMap : BaseEntityMap<VoteMemberContact, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteMemberContact> builder)
        {
            base.Configure(builder);
            
            builder.Property(u => u.ContactId).IsRequired().HasColumnName("contact_id");
            builder.Ignore(x => x.Contact);

            builder.ToTable("vote_member_contacts", "voting");
        }
    }
}
