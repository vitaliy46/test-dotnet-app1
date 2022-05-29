using System;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Рабочий процесс для задач, принадлежащих указанному проекту
    /// </summary>
    public class IssueWorkflowDto : BaseDto<Guid>
    {
        public Guid ProjectId { get; set; }

        public Guid WorkflowId { get; set; }



    }
}
