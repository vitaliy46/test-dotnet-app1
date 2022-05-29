using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteReportMediaMap : BaseEntityMap<VoteReportMedia, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteReportMedia> builder)
        {
            base.Configure(builder);
            
            builder.Property(u => u.VoteReportId).IsRequired().HasColumnName("vote_report_id");
            builder.HasOne(u => u.VoteReport).WithMany(x=>x.Medias).IsRequired().HasForeignKey(x => x.VoteReportId);

            builder.Property(u => u.MediaId).IsRequired().HasColumnName("media_id");
            builder.Ignore(u => u.Media);

            builder.ToTable("vote_report_medias", "voting");
        }
    }
}
