using System;
using Kis.Base.Dao.Mapping;
using Kis.Organization.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Organization.Dao.Mapping
{
    public class AccountingDetailsMap : BaseEntityMap<AccountingDetails, Guid>
    {
        public override void Configure(EntityTypeBuilder<AccountingDetails> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.OrganizationUnitId).HasColumnName("organization_unit_id");
            builder.HasOne(u => u.OrganizationUnit).WithOne(x=>x.AccountingDetails).HasForeignKey<AccountingDetails>(x=>x.OrganizationUnitId);
            builder.Property(u => u.Inn).HasColumnName("inn");
            builder.Property(u => u.Ogrn).HasColumnName("ogrn");

            builder.ToTable("accounting_details", "organization");
        }
    }
}
