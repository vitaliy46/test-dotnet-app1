using System;
using System.Collections.Generic;
using Kis.General.Api.Dto;
using Kis.Hr.Api.Services;
using Kis.Web.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Hr.Web.Controllers
{
    public class CandidateStatesController : KisControllerBase
    {
        ICandidateStateAsyncCrudAppService _candidateStatesAsyncCrudCrudAppService;
        public CandidateStatesController(ICandidateStateAsyncCrudAppService candidateStatesAsyncCrudCrudAppService)
        {
            _candidateStatesAsyncCrudCrudAppService = candidateStatesAsyncCrudCrudAppService;
        }

        /// <summary>
        /// Спискок состояний в которые можно перейти из указанного состояния
        /// </summary>
        /// <param name="stateId">Идентификатор состояния от которого хотим перейти в другие состояния</param>
        /// <returns></returns>
        [HttpGet]
        public IList<StateDto> GetAvailableStates(Guid stateId)
        {
                var availableStates = _candidateStatesAsyncCrudCrudAppService
                            .GetAvailableStates(new StateDto { Id = stateId });

                return availableStates;
        }
        
    }
}
