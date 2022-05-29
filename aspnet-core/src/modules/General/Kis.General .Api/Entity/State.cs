using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Состояние.
    /// </summary>
    public class State : EntityBase<Guid>
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
