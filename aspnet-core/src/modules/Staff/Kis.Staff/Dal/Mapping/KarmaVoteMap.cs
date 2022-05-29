using System;
using Kis.Base.Dao.Mapping;
using Kis.Staff.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Staff.Dao.Mapping
{
    public class KarmaVoteMap: BaseEntityMap<KarmaVote, Guid>
    {
        public override void Configure(EntityTypeBuilder<KarmaVote> builder)
        {
            base.Configure(builder);
            builder.Property(v => v.EmployeeId).HasColumnName("employee_id");
            builder.Property(v => v.KarmaId).HasColumnName("karma_id");

            builder.HasOne(v => v.Employee).WithMany().HasForeignKey(i => i.EmployeeId);
            builder.HasOne(v => v.Karma).WithMany(k => k.KarmaVotes).HasForeignKey(i => i.KarmaId);

            builder.ToTable("karma_votes", "hr");
        }
    }
}
