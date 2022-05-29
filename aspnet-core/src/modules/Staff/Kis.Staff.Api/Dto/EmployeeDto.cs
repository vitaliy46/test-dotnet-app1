using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.Organization.Api.Dto;

namespace Kis.Staff.Api.Dto
{
    /// <summary>
    /// Сотрудник учреждения/фирмы/организации 
    /// </summary>
    public class EmployeeDto : BaseDto<Guid>
    {
        public PersonDto Person { get; set; }

        /// <summary>
        /// Назначения на должности
        /// </summary>
        public  IList<PositionAppointmentDto> PositionAppointments { get; set; }

        /// <summary>
        ///Организация/подразделение в которой работает сотрудник
        /// </summary>
        public  OrganizationUnitDto OrganizationUnit { get; set; }

        /// <summary>
        /// Дата устройства на работу
        /// </summary>
        public DateTime EmploymentDate { get; set; }


    }
}
