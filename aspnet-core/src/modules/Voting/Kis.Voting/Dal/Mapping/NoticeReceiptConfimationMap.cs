using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class NoticeReceiptConfimationMap : BaseEntityMap<NoticeReceiptConfimation, Guid>
    {
        public override void Configure(EntityTypeBuilder<NoticeReceiptConfimation> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ConfimationXml).IsRequired(false).HasColumnName("confimation_xml");

            builder.Property(u => u.VoteId).IsRequired().HasColumnName("vote_id");
            builder.HasOne(x => x.Vote).WithMany().IsRequired().HasForeignKey(x => x.VoteId);

            builder.Property(u => u.MemberId).IsRequired().HasColumnName("member_id");
            builder.HasOne(x => x.Member).WithMany().IsRequired().HasForeignKey(x => x.MemberId);

            builder.ToTable("notice_receipt_confimations", "voting");
        }
    }
}
