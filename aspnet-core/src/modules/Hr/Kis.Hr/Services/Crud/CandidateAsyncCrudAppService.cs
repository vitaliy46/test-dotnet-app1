using System;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Hr.Api.Services;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;

namespace Kis.Hr.Services.Crud
{
    public class CandidateAsyncCrudAppService : AsyncCrudAppServiceBase<Candidate, CandidateDto, Guid>, ICandidateAsyncCrudAppService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionAppointmentRepository _positionAppointmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        
        public CandidateAsyncCrudAppService(
            [NotNull] IRepository<Candidate, Guid> candidateRepository,
            [NotNull] IPositionRepository positionRepository,
            [NotNull] IPositionAppointmentRepository positionAppointmentRepository,
            [NotNull] IEmployeeRepository employeeRepository) : base(candidateRepository)
        {
            if (candidateRepository == null) throw new ArgumentNullException(nameof(candidateRepository));
           
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _positionAppointmentRepository = positionAppointmentRepository ?? throw new ArgumentNullException(nameof(positionAppointmentRepository));
            _positionRepository = positionRepository ?? throw new ArgumentNullException(nameof(positionRepository));
        }
        
        /// <summary>
        /// Принятие кандидата на работу.
        /// </summary>
        /// <param name="candidateDto">Кандидат, принимаемый на работу</param>
        /// <param name="positionDto">Должность</param>
        /// <param name="employmentDate">Дата принятия на работу</param>
        /// <returns></returns>
        public EmployeeDto RecruitCandidate(CandidateDto candidateDto, PositionDto positionDto, DateTime employmentDate)
        {
            if (candidateDto == null) throw new ArgumentNullException(nameof(candidateDto));
            if (positionDto == null) throw new ArgumentNullException(nameof(positionDto));

            var candidate = Repository.FirstOrDefault(candidateDto.Id) ??
                            throw new EntityNotFoundException($"Кандидата с идентификатором {candidateDto.Id} не существует.");

            var position = _positionRepository.FirstOrDefault(positionDto.Id) ??
                           throw new EntityNotFoundException($"Должности с идентификатором {positionDto.Id} не существует.");

            Employee newEmployee = new Employee
            {
                Person = candidate.Person,
                OrganizationUnit = position.OrganizationUnit,
                EmploymentDate = employmentDate
            };

            newEmployee = _employeeRepository.Insert(newEmployee) ?? throw new InvalidOperationException("Ошибка при сохранении в базу");
            PositionAppointment newPositionAppointment = new PositionAppointment { Employee = newEmployee, Position = position };

            newPositionAppointment = _positionAppointmentRepository.Insert(newPositionAppointment) ??
                                     throw new InvalidOperationException("Ошибка при сохранении в базу");

            return ObjectMapper.Map<EmployeeDto>(newPositionAppointment.Employee);
        }
    }
    
}
