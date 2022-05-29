using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteMediaMap : BaseEntityMap<VoteMedia, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteMedia> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(x => x.Vote).WithMany(x=>x.Medias).IsRequired().HasForeignKey(x => x.VoteId);

            builder.Property(u => u.MediaId).IsRequired().HasColumnName("media_id");
            builder.Ignore(x => x.Media);

            builder.ToTable("vote_medias", "voting");
        }
    }
}
