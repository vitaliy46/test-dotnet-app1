using Kis.Noris.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Noris.Api.Dao.EFMapping
{
    public class ReferenceNamedEntityMap<TReferenceEntity> : ReferenceEntityMap<TReferenceEntity>
        where TReferenceEntity : ReferenceNamedEntity
    {
        public virtual void Configure(EntityTypeBuilder<TReferenceEntity> builder)
        {
            builder.Property(h => h.Name).HasColumnName("name");
        }
    }
}
