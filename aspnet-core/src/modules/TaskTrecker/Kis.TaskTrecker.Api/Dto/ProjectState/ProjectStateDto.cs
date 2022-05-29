using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Статус проекта. Позволяет фильтровать или ранжировать проекты
    /// </summary>
    public class ProjectStateDto : BaseDto<Guid>
    {
        public StateDto State { get; set; }
        public Guid StateId { get; set; }

        /// <summary>
        /// Указывает на порядок ранжирования элементов в списке
        /// </summary>
        public int Order { get; set; }
    }
}
