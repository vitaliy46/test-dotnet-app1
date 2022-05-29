using System;
using Kis.Base.Dao.Mapping;
using Kis.Hr.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Hr.Dao.Mapping
{
    public class CandidateCommentMap : BaseEntityMap<CandidateComment, Guid>
    {
        public override void Configure(EntityTypeBuilder<CandidateComment> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.CommentId).HasColumnName("comment_id");
            builder.Ignore(c => c.Comment);
            builder.Property(x => x.CandidateId).HasColumnName("candidate_id");
            builder.HasOne(x => x.Candidate).WithMany(c => c.Comments).HasForeignKey(i => i.CandidateId);

            builder.ToTable("candidate_comments", "hr");
        }
    }
}
