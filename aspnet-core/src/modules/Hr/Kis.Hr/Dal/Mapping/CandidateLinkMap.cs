using System;
using Kis.Base.Dao.Mapping;
using Kis.Hr.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Hr.Dao.Mapping
{
    public class CandidateLinkMap : BaseEntityMap<CandidateLink, Guid>
    {
        public override void Configure(EntityTypeBuilder<CandidateLink> builder)
        {
            base.Configure(builder);
            builder.Property(l => l.LinkId).HasColumnName("link_id");
            builder.Ignore(l => l.Link);
            builder.Property(l => l.CandidateId).HasColumnName("candidate_id").IsRequired();
            builder.HasOne(l => l.Candidate).WithMany(c => c.Links).HasForeignKey(i => i.CandidateId);

            builder.ToTable("candidate_links", "hr");
        }
    }
}
