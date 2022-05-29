using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class MediaMap : BaseEntityMap<Media, Guid>
    {
        public override void Configure(EntityTypeBuilder<Media> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).IsRequired(false).HasColumnName("description");
            builder.Property(x => x.FileName).HasColumnName("file_name");
            builder.Property(x => x.Path).IsRequired(false).HasColumnName("path");
            //builder.Property(x => x.MediaTypeId).HasColumnName("media_type_id");
            //builder.HasOne(x => x.MediaType).WithMany().HasForeignKey(x => x.MediaTypeId);
            builder.Property(x => x.Label).HasColumnName("label");

            builder.HasIndex(x => x.Label);


            builder.ToTable("medias", "general");
        }
    }
}
