using System;
using Kis.Base.Dto;

namespace Kis.Staff.Api.Dto
{
    /// <summary>
    /// Назначение сотрудника на должность
    /// </summary>
    public class PositionAppointmentDto : BaseDto<Guid>
    {
        public  EmployeeDto Employee { get; set; }

        public PositionDto Position { get; set; }


    }
}
