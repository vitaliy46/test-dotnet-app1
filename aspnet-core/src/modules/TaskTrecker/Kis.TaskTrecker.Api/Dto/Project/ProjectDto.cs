using System;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Проект, над которым работает компания
    /// </summary>
    public class ProjectDto : BaseDto<Guid>
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
        public ProjectStateDto ProjectState { get; set; }
        public Guid ProjectStateId { get; set; }

        /// <summary>
        /// Менеджер проекта из числа пользователей системы с назначенной  Ролью Менеджера
        /// </summary>
        public Guid? ManagerId { get; set; }

        /// <summary>
        /// Uri на диаграмму канта про проекту
        /// </summary>
        public string Gant { get; set; }
    }
}
