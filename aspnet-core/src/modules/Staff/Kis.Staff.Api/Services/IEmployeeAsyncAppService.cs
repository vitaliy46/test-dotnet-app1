using System;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.Staff.Api.Dto;

namespace Kis.Staff.Api.Services
{
    public interface IEmployeeAsyncAppService : IAsyncCrudAppService<EmployeeDto, Guid>
    {
        /// <summary>
        /// Принятие сотрудника на работу на основе персоны.
        /// </summary>
        /// <param name="personDto">Лицо, принимаемое на работу</param>
        /// <param name="positionDto">Должность</param>
        /// <param name="employmentDate">Дата принятия на работу</param>
        /// <returns></returns>
        EmployeeDto RecruitPerson(PersonDto personDto, PositionDto positionDto, DateTime employmentDate);
     
        /// <summary>
        /// Увольнение сотрудника.
        /// </summary>
        /// <param name="employeeDto">Увольняемый сотрудник</param>
        void Dismiss(EmployeeDto employeeDto);

        /// <summary>
        /// Перевод сотрудника с одной должности на другую.
        /// </summary>
        /// <param name="employeeDto">Сотрудник</param>
        /// <param name="newPositionDto">Новая должность</param>
        /// <returns></returns>
        EmployeeDto Reassignment(EmployeeDto employeeDto, PositionDto newPositionDto);

        /// <summary>
        /// Задание даты устройства на работу сотрудника.
        /// </summary>
        /// <param name="employeeDto">Сотрудник</param>
        /// <param name="employmentDate">Дата устройства на работу</param>
        EmployeeDto SetEmploymentDate(EmployeeDto employeeDto, DateTime employmentDate);
    }
}
