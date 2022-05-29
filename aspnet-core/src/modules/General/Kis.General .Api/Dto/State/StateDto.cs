using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Состояние кандидата на вакансию.
    /// </summary>
    public class StateDto : BaseDto<Guid>
    {
        /// <summary>
        /// Значение.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
      
    }
}
