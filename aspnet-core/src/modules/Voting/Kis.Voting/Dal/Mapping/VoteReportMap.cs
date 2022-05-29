using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class VoteReportMap : BaseEntityMap<VoteReport, Guid>
    {
        public override void Configure(EntityTypeBuilder<VoteReport> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ReportFileId).IsRequired(false).HasColumnName("report_file_id");
            builder.Ignore(x => x.ReportFile);

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(u => u.Vote).WithMany().IsRequired().HasForeignKey(x => x.VoteId);

            builder.HasMany(u => u.Medias).WithOne(x=>x.VoteReport);

            builder.ToTable("vote_reports", "voting");
        }
    }
}
