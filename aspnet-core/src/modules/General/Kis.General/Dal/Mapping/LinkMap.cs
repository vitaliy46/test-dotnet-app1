using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class LinkMap : BaseEntityMap<Link, Guid>
    {
        public override void Configure(EntityTypeBuilder<Link> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Url).HasColumnName("url");

            builder.ToTable("links", "general");
        }
    }
}
