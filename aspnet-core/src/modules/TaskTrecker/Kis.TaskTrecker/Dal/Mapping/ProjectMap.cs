using System;
using Kis.Base.Dao.Mapping;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kis.TaskTrecker.Dal.Mapping
{
    public class ProjectMap : BaseEntityMap<Project, Guid>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Title).IsRequired().HasColumnName("title");
            builder.Property(u => u.Description).IsRequired(false).HasColumnName("description");
            builder.Property(u => u.Gant).IsRequired(false).HasColumnName("gant");
            builder.Property(u => u.ManagerId).IsRequired(false).HasColumnName("manager_id");
            builder.Ignore(x => x.Manager);
            builder.Property(u => u.ProjectStateId).IsRequired().HasColumnName("project_state_id");
            builder.HasOne(x => x.ProjectState).WithMany().IsRequired().HasForeignKey(x => x.ProjectStateId);

            builder.ToTable("projects", "task_tracker");
        }
    }
}
