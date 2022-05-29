using System;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Рабочий процесс для указанного проекта
    /// </summary>
    public class ProjectWorkflowDto : BaseDto<Guid>
    {
        public Guid ProjectId { get; set; }

        public Guid WorkflowId { get; set; }



    }
}
