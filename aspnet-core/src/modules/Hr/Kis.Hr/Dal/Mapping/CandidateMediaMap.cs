using System;
using Kis.Base.Dao.Mapping;
using Kis.Hr.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Hr.Dao.Mapping
{
    public class CandidateMediaMap : BaseEntityMap<CandidateMedia, Guid>
    {
        public override void Configure(EntityTypeBuilder<CandidateMedia> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.MediaId).HasColumnName("media_id");
            builder.Ignore(m => m.Media);
            builder.Property(m => m.CandidateId).HasColumnName("candidate_id");
            builder.HasOne(m => m.Candidate).WithMany(c => c.MediaFiles).HasForeignKey(i => i.CandidateId);

            builder.ToTable("candidate_medias", "hr");
        }
    }
}
