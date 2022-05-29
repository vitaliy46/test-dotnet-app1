using Kis.Base.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Base.Dao.Mapping
{
    public abstract class BaseEntityMap<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase<TId>
       
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(u => u.Id).HasColumnName("id").HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(u => u.CreatorUserId).HasColumnName("creator_user_id");
            builder.Property(u => u.CreationTime).HasColumnName("creation_time");
            builder.Property(u => u.DeleterUserId).HasColumnName("deleter_user_id");
            builder.Property(u => u.DeletionTime).HasColumnName("deletion_time");
            builder.Property(u => u.IsDeleted).HasColumnName("is_deleted");
            builder.Property(u => u.LastModifierUserId).HasColumnName("last_modifier_user_id");
            builder.Property(u => u.LastModificationTime).HasColumnName("last_modification_time");
        }
    }
}
