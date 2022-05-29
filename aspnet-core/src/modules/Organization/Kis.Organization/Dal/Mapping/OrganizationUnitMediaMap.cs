using System;
using Kis.Base.Dao.Mapping;
using Kis.Organization.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Organization.Dao.Mapping
{
    public class OrganizationUnitMediaMap : BaseEntityMap<OrganizationUnitMedia, Guid>
    {
        public override void Configure(EntityTypeBuilder<OrganizationUnitMedia> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.OrganizationUnitId).HasColumnName("organization_unit_id");
            builder.HasOne(x => x.OrganizationUnit).WithMany(x=>x.Medias).HasForeignKey(x=>x.OrganizationUnitId);

            builder.Property(u => u.MediaId).HasColumnName("media_id");
            builder.Ignore(x => x.Media);


            builder.ToTable("organization_unit_medias", "organization");
        }
    }
}
