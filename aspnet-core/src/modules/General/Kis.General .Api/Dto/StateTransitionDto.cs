using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Переход от одного состояния к другому.
    /// С помошью этой сущности описывается машина состояний.
    /// </summary>
    public class StateTransitionDto : BaseDto<Guid>
    {
        /// <summary>
        /// Название перехода
        /// </summary>
        public  string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор состояния из которого осуществляется переход.
        /// </summary>
        public Guid StateFromId { get; set; }

        /// <summary>
        /// Идентификатор состояния в которое возможно осуществить переход.
        /// </summary>
        public Guid StateToId { get; set; }

        /// <summary>
        /// Рабочий процесс, к которому относится переход из одного состояния в другое
        /// </summary>
        public Guid WorkflowId { get; set; }

    }
}
