using System;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.Hr.Api.Dao.Repositories;
using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Hr.Api.Services;

namespace Kis.Hr.Services.Crud
{
    public class CandidateAppService: ICandidateAsyncAppService
    {
        private readonly ICandidateAsyncCrudAppService _candidateAsyncCrudAppService;
        ICandidateStateAsyncCrudAppService _candidateStatusAsyncCrudAppService;

        public CandidateAppService(ICandidateAsyncCrudAppService candidateAsyncCrudAppService, 
            [NotNull] ICandidateStateAsyncCrudAppService candidateStatusAsyncCrudAppService)
        {
            _candidateAsyncCrudAppService = candidateAsyncCrudAppService;
            _candidateStatusAsyncCrudAppService = candidateStatusAsyncCrudAppService;
        }

        public CandidateDto Add(PersonDto person, VacancyDto vacancy, string source)
        {
            if (person == null)
                throw new ArgumentException($"Параметр {nameof(person)} не может быть NULL", nameof(person));

            if (vacancy == null)
                throw new ArgumentException($"Параметр {nameof(vacancy)} не может быть NULL", nameof(vacancy));

            var candidate = _candidateAsyncCrudAppService.Create(new CandidateDto()
            {
                Person = new PersonDto() { Id = person.Id }
            }).Result;

            _candidateStatusAsyncCrudAppService.ChangeState(candidate, new StateDto());
            
            return candidate;
        }

        public void Decline(CandidateDto candidate, string comment)
        {
            throw new NotImplementedException();
        }

        public void SetInterviewResult(CandidateDto candidate, int resultId)
        {
            throw new NotImplementedException();
        }

        public void SetPriorityCommunication(CandidateDto candidate, string contact)
        {
            throw new NotImplementedException();
        }

        public void SignOffer(Guid candidateId, Guid organizationId, string offer)
        {
            throw new NotImplementedException();
        }
    }
}
