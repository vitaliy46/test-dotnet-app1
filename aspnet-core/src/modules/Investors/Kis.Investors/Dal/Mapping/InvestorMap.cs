using System;
using Kis.Base.Dao.Mapping;
using Kis.Investors.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Investors.Dao.Mapping
{
    public class InvestorMap : BaseEntityMap<Investor, Guid>
    {
        public override void Configure(EntityTypeBuilder<Investor> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.MemberId).IsRequired().HasColumnName("member_id");
            builder.HasOne(u => u.Member).WithMany(x => x.Investors).IsRequired().HasForeignKey(x=>x.MemberId);

            builder.Property(u => u.InvestmentShare).IsRequired().HasColumnName("investment_share");

            builder.Property(u => u.ProjectId).IsRequired().HasColumnName("project_id");
            builder.HasOne(u => u.Project).WithMany(x=>x.Investors).IsRequired().HasForeignKey(x=>x.ProjectId);
           
            builder.ToTable("investors", "investor");
        }
    }
}
