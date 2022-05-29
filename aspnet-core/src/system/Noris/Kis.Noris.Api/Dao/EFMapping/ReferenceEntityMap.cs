using Kis.Noris.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Noris.Api.Dao.EFMapping
{
    public class ReferenceEntityMap<TReferenceEntity> : IEntityTypeConfiguration<TReferenceEntity>
        where TReferenceEntity : ReferenceEntity
    {
        public virtual void Configure(EntityTypeBuilder<TReferenceEntity> builder)
        {
            builder.HasKey(h => h.VersionId);

            builder.Property(h => h.VersionId).HasColumnName("version_id");
            builder.HasIndex(x => x.VersionId).IsUnique();
            builder.Property(h => h.RecordId).HasColumnName("record_id");
            builder.HasIndex(x => x.RecordId).IsUnique(false);
            builder.Property(h => h.IsDeleted).HasColumnName("is_deleted");
            builder.Property(h => h.Code).HasColumnName("code");
            builder.HasIndex(x => x.Code).IsUnique(false);
            builder.Property(h => h.ReleaseDateBegin).HasColumnName("release_date_begin");
            builder.Property(h => h.ReleaseDateEnd).HasColumnName("release_date_end");
            builder.Ignore(h => h.IsActual);
        }
    }
}
