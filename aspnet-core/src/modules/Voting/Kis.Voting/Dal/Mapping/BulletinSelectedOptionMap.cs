using System;
using Kis.Base.Dao.Mapping;
using Kis.Voting.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.Voting.Dao.Mapping
{
    public class BulletinSelectedOptionMap : BaseEntityMap<BulletinSelectedOption, Guid>
    {
        public override void Configure(EntityTypeBuilder<BulletinSelectedOption> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.BulletinId).IsRequired().HasColumnName("bulletin_id");
            builder.HasOne(x=>x.Bulletin).WithMany(x=> x.BulletinSelectedOptions).IsRequired().HasForeignKey(x=>x.BulletinId);

            builder.Property(u => u.SelectedOptionId).IsRequired().HasColumnName("selected_option_id");
            builder.HasOne(x => x.SelectedOption).WithMany().IsRequired().HasForeignKey(x => x.SelectedOptionId);

            builder.ToTable("bulletin_selected_options", "voting");
        }
    }
}
