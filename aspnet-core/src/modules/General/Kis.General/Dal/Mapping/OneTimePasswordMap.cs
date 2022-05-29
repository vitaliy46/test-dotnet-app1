using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class OneTimePasswordMap : BaseEntityMap<OneTimePassword, Guid>
    {
        public override void Configure(EntityTypeBuilder<OneTimePassword> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Password).HasColumnName("password").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(x => x.NumberOfAttempts).HasColumnName("number_of_attempts").IsRequired();
            builder.Property(x => x.Confirmed).HasColumnName("confirmed").IsRequired();

            builder.ToTable("one_time_passwords", "general");
        }
    }
}
