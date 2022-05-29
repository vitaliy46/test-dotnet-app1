using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Состояние кандидата на вакансию.
    /// </summary>
    public class CreateStateDto : IShouldNormalize
    {
        /// <summary>
        /// Значение.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        public void Normalize()
        {
        }
    }
}
