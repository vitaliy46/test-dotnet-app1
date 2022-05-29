using System;
using Kis.Base.Entity;
using Kis.Organization.Api.Entity;
using Kis.Staff.Api.Entity;

namespace Kis.Hr.Api.Entity
{
    /// <summary>
    /// Вакансия в организации.
    /// </summary>
    public class Vacancy : EntityBase<Guid>
    {
        /// <summary>
        /// Подразделение или организация в котором объявлена вакансия.
        /// </summary>
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }

        /// <summary>
        /// Должность в организации, на которую объявлена вакансия.
        /// </summary>
        public virtual Position Position { get; set; }
        public Guid PositionId { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
    }
}
