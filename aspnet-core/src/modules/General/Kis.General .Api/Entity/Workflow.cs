using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Рабочий процесс, с которым связаны состояния и переходи
    /// </summary>
    public class Workflow :  EntityBase<Guid>
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
