using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public  class CommentMap : BaseEntityMap<Comment, Guid>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Text).HasColumnName("text");

            builder.HasMany(x => x.Medias).WithOne(x => x.Comment);
            builder.HasMany(x => x.Links).WithOne(x => x.Comment);
            //https://docs.microsoft.com/en-us/ef/core/modeling/relationships#many-to-many
            //https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
            //TODO Создать сущности-связки и переопределить связи many to many
            //builder.HasMany(x => x.Medias).WithMany()
            //    .Map(m => m.MapLeftKey("comment_id")
            //        .MapRightKey("media_id")
            //        .ToTable("rel_comment_to_media", "general"));
            //builder.HasMany(x => x.Links).WithMany()
            //    .Map(m => m.MapLeftKey("comment_id")
            //        .MapRightKey("link_id")
            //        .ToTable("rel_comment_to_link", "general"));

            builder.ToTable("comments", "general");
        }
    }
}
