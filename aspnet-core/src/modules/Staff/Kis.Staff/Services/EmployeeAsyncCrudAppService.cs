using System;
using Abp.Domain.Entities;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dao.Repositories;
using Kis.General.Api.Dto;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;
using Kis.Staff.Api.Services;

namespace Kis.Staff.Services
{
    /// <summary>
    /// Представляет сервис сотрудников компании.
    /// </summary>
    public class EmployeeAsyncCrudAppService : AsyncCrudAppServiceBase<Employee, EmployeeDto, Guid>, IEmployeeAsyncAppService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionAppointmentRepository _positionAppointmentRepository;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="EmployeeAsyncCrudAppService"/>.
        /// </summary>
        /// <param name="personRepository">Репозиторий персон</param>
        /// <param name="positionRepository">Репозиторий должностей</param>
        /// <param name="positionAppointmentRepository">Репозиторий назначений сотруднико на должность</param>
        /// <param name="employeeRepository">Репозиторий сотрудников компании</param>
        /// <param name="mapper"></param>
        public EmployeeAsyncCrudAppService(
            IPersonRepository personRepository,
            IPositionRepository positionRepository,
            IPositionAppointmentRepository positionAppointmentRepository,
            IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _personRepository = personRepository;
            _positionRepository = positionRepository;
            _positionAppointmentRepository = positionAppointmentRepository;
        }

        /// <summary>
        /// Принятие сотрудника на работу на основе его персоны (физ. лица).
        /// </summary>
        /// <param name="personDto">Персона (физю лицо), принимаемая на работу</param>
        /// <param name="positionDto">Должность</param>
        /// <param name="employmentDate">Дата принятия на работу</param>
        /// <returns></returns>
        public EmployeeDto RecruitPerson(PersonDto personDto, PositionDto positionDto, DateTime employmentDate)
        {
            if (personDto == null) throw new ArgumentNullException(nameof(personDto));
            if (positionDto == null) throw new ArgumentNullException(nameof(positionDto));

            var person = _personRepository.FirstOrDefault(personDto.Id) ??
                throw new EntityNotFoundException($"Персоны (физ. лица) с идентификатором {personDto.Id} не существует.");

            var position = _positionRepository.FirstOrDefault(positionDto.Id) ??
                throw new EntityNotFoundException($"Должности с идентификатором {positionDto.Id} не существует.");

            Employee newEmployee = new Employee
            {
                Person = person,
                OrganizationUnit = position.OrganizationUnit,
                EmploymentDate = employmentDate
            };

            newEmployee = Repository.Insert(newEmployee) ?? throw new InvalidOperationException("Ошибка при сохранении в базу");
            PositionAppointment newPositionAppointment = new PositionAppointment { Employee = newEmployee, Position = position };

            newPositionAppointment = _positionAppointmentRepository.Insert(newPositionAppointment) ??
                throw new InvalidOperationException("Ошибка при сохранении в базу");

            return ObjectMapper.Map<EmployeeDto>(newPositionAppointment.Employee);
        }

        

        /// <summary>
        /// Увольнение сотрудника.
        /// </summary>
        /// <param name="employeeDto">Увольняемый сотрудник</param>
        public void Dismiss(EmployeeDto employeeDto)
        {
            if (employeeDto == null) throw new ArgumentNullException(nameof(employeeDto));

            var employee = Repository.FirstOrDefault(employeeDto.Id) ??
                throw new EntityNotFoundException($"Сотрудника с идентификатором {employeeDto.Id} не существует.");

            Repository.Delete(employee);
        }

        /// <summary>
        /// Перевод сотрудника с одной должности на другую.
        /// </summary>
        /// <param name="employeeDto">Сотрудник</param>
        /// <param name="newPositionDto">Новая должность</param>
        /// <returns></returns>
        public EmployeeDto Reassignment(EmployeeDto employeeDto, PositionDto newPositionDto)
        {
            if (employeeDto == null) throw new ArgumentNullException(nameof(employeeDto));
            if (newPositionDto == null) throw new ArgumentNullException(nameof(newPositionDto));

            var employee = Repository.FirstOrDefault(employeeDto.Id) ??
                throw new EntityNotFoundException($"Сотрудника с идентификатором {employeeDto.Id} не существует.");

            var position = _positionRepository.FirstOrDefault(newPositionDto.Id) ??
                throw new EntityNotFoundException($"Должности с идентификатором {newPositionDto.Id} не существует.");

            PositionAppointment newPositionAppointment = new PositionAppointment { Employee = employee, Position = position };

            newPositionAppointment = _positionAppointmentRepository.Insert(newPositionAppointment) ??
                throw new InvalidOperationException("Ошибка при сохранении в базу");

            return ObjectMapper.Map<EmployeeDto>(newPositionAppointment.Employee);
        }

        /// <summary>
        /// Задание даты устройства на работу сотрудника.
        /// </summary>
        /// <param name="employeeDto">Сотрудник</param>
        /// <param name="employmentDate">Дата устройства на работу</param>
        public EmployeeDto SetEmploymentDate(EmployeeDto employeeDto, DateTime employmentDate)
        {
            if (employeeDto == null) throw new ArgumentNullException(nameof(employeeDto));

            var employee = Repository.FirstOrDefault(employeeDto.Id) ??
                throw new EntityNotFoundException($"Сотрудника с идентификатором {employeeDto.Id} не существует.");

            employee.EmploymentDate = employmentDate;
            employee = Repository.Update(employee) ?? throw new InvalidOperationException("Ошибка при сохранении в базу");

            return ObjectMapper.Map<EmployeeDto>(employee);
        }
    }
}
