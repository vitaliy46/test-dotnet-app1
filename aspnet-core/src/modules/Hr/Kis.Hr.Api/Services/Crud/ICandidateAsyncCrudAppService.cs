using System;
using Kis.Base.Services.Bl;
using Kis.Hr.Api.Dto;
using Kis.Staff.Api.Dto;

namespace Kis.Hr.Api.Services
{
    public interface ICandidateAsyncCrudAppService : IAsyncCrudAppService<CandidateDto, Guid>
        
    {
        /// <summary>
        /// Принятие сотрудника на работу на основе его кандидата.
        /// </summary>
        /// <param name="candidateDto">Кандидат на должность</param>
        /// <param name="positionDto">Должность</param>
        /// <param name="employmentDate">Дата принятия на работу</param>
        /// <returns></returns>
        EmployeeDto RecruitCandidate(CandidateDto candidateDto, PositionDto positionDto, DateTime employmentDate);

    }
}
