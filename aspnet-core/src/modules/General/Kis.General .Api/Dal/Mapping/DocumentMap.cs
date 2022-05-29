using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Api.Dal.Mapping
{
    public abstract class DocumentMap<T> : BaseEntityMap<T, Guid> 
        where T : Document
    {
        public override void Configure (EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Number).HasColumnName("number");

            builder.Property(u => u.BeginDate).HasColumnName("begin_date");

        }
    }
}
