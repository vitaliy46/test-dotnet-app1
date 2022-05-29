using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.Users.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Проект, над которым работает компания
    /// </summary>
    public class UpdateProjectDto : IShouldNormalize
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
        public Guid ProjectStateId { get; set; }

        public void Normalize()
        {
        }
    }
}
