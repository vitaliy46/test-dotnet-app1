using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public class IssueState : EntityBase<Guid>
    {
        public virtual Issue Issue { get; set; }
        public Guid IssueId { get; set; }

        public State State { get; set; }
        public Guid StateId { get; set; }

        /// <summary>
        /// Указывает на порядок ранжирования элементов в списке
        /// </summary>
        public int Order { get; set; }
    }
}
