using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Рабочий процесс для задач, принадлежащих указанному проекту
    /// </summary>
    public class IssueWorkflow : EntityBase<Guid>
    {
        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public Workflow Workflow { get; set; }
        public Guid WorkflowId { get; set; }



    }
}
