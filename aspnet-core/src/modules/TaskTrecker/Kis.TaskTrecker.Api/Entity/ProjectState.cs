using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Статус проекта. Позволяет фильтровать или ранжировать проекты
    /// </summary>
    public class ProjectState : EntityBase<Guid>
    {
        public State State { get; set; }
        public Guid StateId { get; set; }

        /// <summary>
        /// Указывает на порядок ранжирования элементов в списке
        /// </summary>
        public byte Order { get; set; }


    }
}
