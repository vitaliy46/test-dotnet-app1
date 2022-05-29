using System;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Проект, над которым работает компания
    /// </summary>
    public class ProjectShortDto : BaseDto<Guid>
    {
        /// <summary>
        /// Заголовок проекта
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Состояние проекта
        /// </summary>
        public string StateName { get; set; }
    }
}
