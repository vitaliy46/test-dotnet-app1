using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class StateMap : BaseEntityMap<State, Guid>
    {
        public override void Configure(EntityTypeBuilder<State> builder)
        {
            base.Configure(builder);
            builder.Property(s => s.Name).HasColumnName("name");
            builder.Property(s => s.Description).HasColumnName("description");

            builder.ToTable("states", "general");
        }
    }
}
