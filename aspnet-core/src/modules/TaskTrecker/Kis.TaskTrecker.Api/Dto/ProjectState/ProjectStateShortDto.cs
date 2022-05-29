using System;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Статус проекта. Позволяет фильтровать или ранжировать проекты
    /// </summary>
    public class ProjectStateShortDto : BaseDto<Guid>
    {
        public string StateName { get; set; }

        /// <summary>
        /// Указывает на порядок ранжирования элементов в списке
        /// </summary>
        public int Order { get; set; }

    }
}
