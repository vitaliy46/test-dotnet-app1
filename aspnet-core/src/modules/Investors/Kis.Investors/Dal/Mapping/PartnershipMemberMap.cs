using System;
using Kis.Base.Dao.Mapping;
using Kis.Investors.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Investors.Dao.Mapping
{
    public class PartnershipMemberMap : BaseEntityMap<PartnershipMember, Guid>
    {
        public override void Configure(EntityTypeBuilder<PartnershipMember> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.OrganizationId).IsRequired().HasColumnName("organization_id");
            builder.Ignore(x => x.Organization);

            builder.HasOne(x => x.Contactor).WithOne(x => x.PartnershipMember);

            builder.Property(u => u.IsAllowSmsNotification).IsRequired().HasColumnName("is_allow_sms_notification");

            builder.HasMany(x => x.Investors).WithOne(x => x.Member);

            builder.ToTable("partnership_members", "investor");
        }
    }
}
