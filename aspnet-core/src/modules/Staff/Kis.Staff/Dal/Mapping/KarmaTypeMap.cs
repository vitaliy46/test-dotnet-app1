using System;
using Kis.Base.Dao.Mapping;
using Kis.Staff.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Staff.Dao.Mapping
{
    public class KarmaTypeMap: BaseEntityMap<KarmaType, Guid>
    {
        public override void Configure(EntityTypeBuilder<KarmaType> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Value).HasColumnName("value");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Weight).HasColumnName("weight");

            builder.ToTable("karma_types", "hr");
        }
    }
}
