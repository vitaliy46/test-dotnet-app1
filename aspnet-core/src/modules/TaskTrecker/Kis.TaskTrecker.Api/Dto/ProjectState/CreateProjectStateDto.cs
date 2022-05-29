using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Статус проекта. Позволяет фильтровать или ранжировать проекты
    /// </summary>
    public class CreateProjectStateDto : IShouldNormalize
    {
        public CreateStateDto State { get; set; }

        /// <summary>
        /// Предлагаемое значение идентификатора. Если не указано, то то id будет назначен
        /// Используется для наполнения БД предустановленными данными
        /// </summary>
        public Guid? ProposedId { get; set; }

        /// <summary>
        /// Указывает на порядок ранжирования элементов в списке
        /// </summary>
        public int Order { get; set; }

        public void Normalize()
        {
        }
    }
}
