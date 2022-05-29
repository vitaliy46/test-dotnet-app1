using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private ICandidateAsyncAppService _candidateAsyncAppService;
        private ICandidateAsyncCrudAppService _candidateAsyncCrudAppService;
        private readonly IPositionAsyncCrudAppService _positionCrudAppService;


        public CandidatsController([NotNull] ICandidateAsyncAppService candidateAsyncAppService,
            [NotNull] ICandidateAsyncCrudAppService candidateAsyncCrudAppService,
            [NotNull] IPositionAsyncCrudAppService positionCrudAppService)
        {
            _positionCrudAppService = positionCrudAppService ?? throw new ArgumentNullException(nameof(positionCrudAppService));
            _candidateAsyncCrudAppService = candidateAsyncCrudAppService ?? throw new ArgumentNullException(nameof(candidateAsyncCrudAppService));
            _candidateAsyncAppService = candidateAsyncAppService ?? throw new ArgumentNullException(nameof(candidateAsyncAppService));
        }

        // GET: api/Candidats
        public IEnumerable<CandidateDto> Get()
        {
            return new [] { new CandidateDto(), new CandidateDto() };
        }

        // GET: api/Candidats/5
        public CandidateDto Get(Guid id)
        {
            return null; //TODO _candidateAsyncCrudAppService.Get(new CandidateDto{Id = id}).Result;
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
        public async Task<IActionResult> RecruitCandidate(Guid candidateId, Guid positionId, DateTime employmentDate)
        {

            var candidateDto = await _candidateAsyncCrudAppService.Get(candidateId);
            if (candidateId == null) NotFound();

            var positionDto = await _positionCrudAppService.Get(positionId);
            if (positionDto == null) return NotFound();

            var employeeDto = _candidateAsyncCrudAppService.RecruitCandidate(candidateDto, positionDto, employmentDate);
            return Ok(employeeDto);

        }

        // DELETE: api/Candidats/5
        public void Delete(Guid id)
        {
        }
    }
}
