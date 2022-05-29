using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class MediaTypeMap : BaseEntityMap<MediaType, Guid>
    {
        public override void Configure(EntityTypeBuilder<MediaType> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.SystemName).HasColumnName("system_name");

            builder.ToTable("media_types", "general");
        }
    }
}
