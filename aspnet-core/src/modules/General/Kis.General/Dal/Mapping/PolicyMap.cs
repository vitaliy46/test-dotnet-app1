using Kis.General.Api.Dal.Mapping;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.General.Dal.Mapping
{
    public class PolicyMap : DocumentMap<Policy>
    {
        public override void Configure(EntityTypeBuilder<Policy> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.EndDate).HasColumnName("end_date");
            builder.Property(u => u.Series).HasColumnName("series");

            builder.Property(u => u.PersonId).HasColumnName("person_id");
            builder.HasOne(x => x.Person).WithMany(x=> x.Policies).IsRequired().HasForeignKey(x=> x.PersonId);

            builder.ToTable("policies", "general");
        }
    }
}
