using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Файлы любого содержания, прикрепленные к задаче.
    /// </summary>
    public class IssueMedia : EntityBase<Guid>
    {
        /// <summary>
        /// Медиа информация.
        /// </summary>
        public Media Media { get; set; }
        public Guid MediaId { get; set; }

        /// <summary>
        /// Кандидат на рабочее место.
        /// </summary>
        public virtual Issue Issue { get; set; }
        public Guid IssueId { get; set; }
    }
}
