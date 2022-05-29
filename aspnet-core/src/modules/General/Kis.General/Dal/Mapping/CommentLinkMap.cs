using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class CommentLinkMap : BaseEntityMap<CommentLink, Guid>
    {
        public override void Configure(EntityTypeBuilder<CommentLink> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CommentId).IsRequired().HasColumnName("comment_id");
            builder.HasOne(x => x.Comment).WithMany().IsRequired().HasForeignKey(x => x.CommentId);

            builder.Property(x => x.LinkId).IsRequired().HasColumnName("link_id");
            builder.HasOne(x => x.Link).WithMany().IsRequired().HasForeignKey(x => x.LinkId);

            builder.ToTable("comment_links", "general");
        }
    }
}
