using System;
using System.Collections.Generic;
using Abp.Organizations;
using Kis.Base.Entity;
using Kis.General.Api.Entity;
using OrganizationUnit = Kis.Organization.Api.Entity.OrganizationUnit;

namespace Kis.Staff.Api.Entity
{
    /// <summary>
    /// Сотрудник учреждения/фирмы/организации.
    /// </summary>
    public class Employee : EntityBase<Guid>
    {
        /// <summary>
        /// Персона (физ. лицо).
        /// </summary>
        public Person Person { get; set; }
        public Guid PersonId { get; set; }

        /// <summary>
        /// Организация/подразделение в которой работает сотрудник.
        /// </summary>
        public  OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }

        /// <summary>
        /// Контактные данные сотрудника
        /// </summary>
        public virtual IList<EmployeeContact> WorkContacts { get; set; }

        /// <summary>
        /// Назначения на должности.
        /// </summary>
        public virtual IList<PositionAppointment> PositionAppointments { get; set; }

        /// <summary>
        /// Список карм сотрудника.
        /// </summary>
        public virtual IList<Karma> Karmas { get; set; }

        /// <summary>
        /// Дата устройства на работу.
        /// </summary>
        public DateTime? EmploymentDate { get; set; }
    }
}
