using System;
using System.Collections.Generic;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.Hr.Api.Dto;

namespace Kis.Hr.Api.Services
{
    /// <summary>
    /// Сервис предоставляет возможность перевести кандидата из одного состояния в другое.
    /// Предоставляет список состояний, в которые возможен переход.
    /// </summary>
    public interface ICandidateStateAsyncCrudAppService : IAsyncCrudAppService<CandidateStateDto, Guid>
    {
        /// <summary>
        /// Изменение состояния кандидата
        /// </summary>
        /// <param name="candidateDto">кандидат, у которого нужно изменить состояние</param>
        /// <param name="stateDto">состояние, на который нужно поменять текущее состояние</param>
        /// <returns></returns>
        CandidateDto ChangeState(CandidateDto candidateDto, StateDto stateDto);


        /// <summary>
        /// Изменение состояния кандидата
        /// </summary>
        /// <param name="candidateDto">кандидат, у которого нужно изменить состояние</param>
        /// <param name="stateDto">состояние, на который нужно поменять текущее состояние</param>
        /// <param name="comment">Причина, обоснование перевода в состояние</param>
        /// <returns></returns>
        CandidateDto ChangeState(CandidateDto candidateDto, StateDto stateDto, string comment);


        /// <summary>
        /// Спискок состояний в которые можно перейти из указанного состояния
        /// </summary>
        /// <param name="stateDto">Состояние от которого хотим перейти в другие состояния
        /// Если аргумент null или имеет пустой GUID, тогда возвращается список с начальным состоянием</param>
        /// <returns></returns>
        List<StateDto> GetAvailableStates(StateDto stateDto);
    }
}
