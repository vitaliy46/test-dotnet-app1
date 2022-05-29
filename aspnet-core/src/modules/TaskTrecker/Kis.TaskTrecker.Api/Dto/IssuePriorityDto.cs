using System;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Приоритет задачи назначенной в проекте
    /// </summary>
    public class IssuePriorityDto : BaseDto<Guid>
    {
        public string Name { get; set; }
    }
}
