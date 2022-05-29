using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Рабочий процесс для указанного проекта
    /// </summary>
    public class ProjectWorkflow : EntityBase<Guid>
    {
        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public Workflow Workflow { get; set; }
        public Guid WorkflowId { get; set; }



    }
}
