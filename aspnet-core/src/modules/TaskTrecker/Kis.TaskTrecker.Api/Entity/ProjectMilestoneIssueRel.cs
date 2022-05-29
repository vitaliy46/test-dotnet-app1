using System;
using Kis.Base.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Сопоставление ключевых задач вехам проекта
    /// </summary>
    public class ProjectMilestoneIssueRel : EntityBase<Guid>
    {
        public virtual Issue Issue { get; set; }
        public Guid IssueId { get; set; }


        public virtual ProjectMilestone Milestone { get; set; }
        public Guid MilestoneId { get; set; }

       
    }
}
