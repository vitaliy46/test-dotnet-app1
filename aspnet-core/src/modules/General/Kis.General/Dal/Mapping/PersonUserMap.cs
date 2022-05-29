using System;
using Kis.Base.Dao.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class PersonUserMap : BaseEntityMap<PersonUser, Guid>
    {
        public override void Configure(EntityTypeBuilder<PersonUser> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
            builder.HasOne(x => x.Person)
                .WithOne(x=>x.PersonUser).HasForeignKey<PersonUser>(x=>x.PersonId).IsRequired();

            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Ignore(x => x.User);

            builder.ToTable("person_users", "general");
        }
    }
}
