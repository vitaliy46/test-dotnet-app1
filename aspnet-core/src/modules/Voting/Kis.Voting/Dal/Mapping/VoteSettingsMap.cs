using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteSettingsMap : BaseEntityMap<VoteSettings, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteSettings> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.IsNeedSign).IsRequired().HasColumnName("is_need_sign");
            builder.Property(u => u.VotingCalculationType).IsRequired().HasColumnName("voting_calculation_type");

            builder.Property(u => u.UserId).IsRequired().HasColumnName("user_id");
            //builder.Ignore(u => u.User);
            
            builder.ToTable("vote_settings", "voting");
        }
    }
}
