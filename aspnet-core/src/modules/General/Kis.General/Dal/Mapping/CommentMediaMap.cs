using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class CommentMediaMap : BaseEntityMap<CommentMedia, Guid>
    {
        public override void Configure(EntityTypeBuilder<CommentMedia> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CommentId).IsRequired().HasColumnName("comment_id");
            builder.HasOne(x => x.Comment).WithMany().HasForeignKey(x => x.CommentId);

            builder.Property(x => x.MediaId).IsRequired().HasColumnName("media_id");
            builder.HasOne(x => x.Media).WithMany().IsRequired().HasForeignKey(x => x.MediaId);

            builder.ToTable("comment_medias", "general");
        }
    }
}
