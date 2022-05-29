using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Services;
using Kis.Staff.Api.Services;
using Kis.Web.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Hr.Web.Controllers
{
    public class CandidatsController : KisControllerBase
    {
        private ICandidateAppService _candidateAppService;
        private IAsyncCandidateCrudAppService _candidateCrudAppService;
        private readonly IPositionCrudAppService _positionCrudAppService;


        public CandidatsController([NotNull] ICandidateAppService candidateAppService,
            [NotNull] IAsyncCandidateCrudAppService candidateCrudAppService,
            [NotNull] IPositionCrudAppService positionCrudAppService)
        {
            _positionCrudAppService = positionCrudAppService ?? throw new ArgumentNullException(nameof(positionCrudAppService));
            _candidateCrudAppService = candidateCrudAppService ?? throw new ArgumentNullException(nameof(candidateCrudAppService));
            _candidateAppService = candidateAppService ?? throw new ArgumentNullException(nameof(candidateAppService));
        }

        // GET: api/Candidats
        public IEnumerable<CandidateDto> Get()
        {
            return new [] { new CandidateDto(), new CandidateDto() };
        }

        // GET: api/Candidats/5
        public CandidateDto Get(Guid id)
        {
            return null; //TODO _candidateCrudAppService.Get(new CandidateDto{Id = id}).Result;
        }

        // POST: api/Candidats
        public void Post([FromBody]CandidateDto value)
        {
        }

        // PUT: api/Candidats/5
        public void Put(Guid id, [FromBody]CandidateDto value)
        {
        }
        /// <summary>
        /// Принятие кандидата на работу.
        /// </summary>
        /// <param name="candidateId">Идентификатор кандидата</param>
        /// <param name="organizationUnitId">Идентификатор организации</param>
        /// <param name="positionId">Идентификатор должности</param>
        /// <param name="employmentDate">Дата принятия на работу</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RecruitCandidate(Guid candidateId, Guid positionId, DateTime employmentDate)
        {

            var candidateDto = _candidateAppService.Get(candidateId);
            if (candidateId == null) NotFound();

            var positionDto = _positionCrudAppService.Get(positionId);
            if (positionDto == null) return NotFound();

            var employeeDto = _candidateCrudAppService.RecruitCandidate(candidateDto, positionDto, employmentDate);
            return Ok(employeeDto);

        }

        // DELETE: api/Candidats/5
        public void Delete(Guid id)
        {
        }
    }
}
