using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Рабочий процесс, с которым связаны состояния и переходи
    /// </summary>
    public class WorkflowDto :  BaseDto<Guid>
    {
        /// <summary>
        /// Название состояния
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
    }
}
