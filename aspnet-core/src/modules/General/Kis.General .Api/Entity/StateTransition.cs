using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Переход от одного состояния к другому.
    /// С помошью этой сущности описывается машина состояний.
    /// </summary>
    public class StateTransition : EntityBase<Guid>
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
        public virtual State StateFrom { get; set; }
        public Guid StateFromId { get; set; }

        /// <summary>
        /// Идентификатор состояния в которое возможно осуществить переход.
        /// </summary>
        public virtual State StateTo { get; set; }
        public Guid StateToId { get; set; }

        /// <summary>
        /// Рабочий процесс, к которому относится переход из одного состояния в другое
        /// </summary>
        public virtual Workflow Workflow { get; set; }
        public Guid WorkflowId { get; set; }

    }
}
