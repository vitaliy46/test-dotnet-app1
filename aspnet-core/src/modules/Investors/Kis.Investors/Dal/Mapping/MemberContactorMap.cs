using System;
using Kis.Base.Dao.Mapping;
using Kis.Investors.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Investors.Dao.Mapping
{
    public class MemberContactorMap : BaseEntityMap<MemberContactor, Guid>
    {
        public override void Configure(EntityTypeBuilder<MemberContactor> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.PersonId).IsRequired().HasColumnName("person_id");
            builder.Ignore(x => x.Person);
            
            builder.Property(u => u.PartnershipMemberId).IsRequired().HasColumnName("partnership_member_id");
            builder.HasOne(u => u.PartnershipMember).WithOne(x => x.Contactor).IsRequired().HasForeignKey<MemberContactor>(x => x.PartnershipMemberId);

            builder.Property(x => x.PersonContactId).HasColumnName("contact_id").IsRequired();
            builder.Ignore(x => x.PersonContact);

            builder.ToTable("member_contactors", "investor");
        }
    }
}
