using System;
using Kis.Base.Dao.Mapping;
using Kis.Hr.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Hr.Dao.Mapping
{
    public class InfomationSourceMap : BaseEntityMap<InfomationSource, Guid>
    {
        public override void Configure(EntityTypeBuilder<InfomationSource> builder)
        {
            base.Configure(builder);
            builder.Property(i => i.SourceName).HasColumnName("source_name");
            builder.Property(i => i.HasApi).HasColumnName("has_api");

            builder.ToTable("infomation_sources", "hr");
        }
    }
}
