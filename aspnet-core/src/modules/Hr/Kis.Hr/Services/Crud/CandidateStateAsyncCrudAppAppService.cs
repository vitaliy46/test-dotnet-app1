using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dao.Repositories;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services;
using Kis.Hr.Api.Dao.Repositories;
using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Hr.Api.Services;

namespace Kis.Hr.Services.Crud
{
    /// <summary>
    /// Сервис предоставляет возможность перевести кандидата из одного состояния в другое.
    /// Предоставляет список состояний, в которые возможен переход.
    /// </summary>
    public class CandidateStateAsyncCrudAppService : AsyncCrudAppServiceBase<CandidateState, CandidateStateDto, Guid>, ICandidateStateAsyncCrudAppService
    {

        private readonly IStateMachine _stateMachine;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IStateRepository _stateRepository;
                
        public CandidateStateAsyncCrudAppService(IRepository<CandidateState, Guid> repository, ICandidateRepository candidateRepository, 
                    IStateRepository stateRepository, IStateMachine stateMachine): base(repository)
        {
            _candidateRepository = candidateRepository;
            _stateRepository = stateRepository;
            _stateMachine = stateMachine;
        }


        /// <summary>
        /// Изменение состояния кандидата.Перегруженная версия метода ChangeState
        /// </summary>
        /// <param name="candidateDto">кандидат, у которого нужно изменить состояние</param>
        /// <param name="stateDto">состояние, на который нужно поменять текущий состояние</param>
        /// <param name="comment">Причина, обоснование перевода в состояние</param>
        /// <returns></returns>
        /// TODO переделать медоды осуществляющие переход по состояниям
        public CandidateDto ChangeState(CandidateDto candidateDto, StateDto stateDto, string comment)
        {
            //проверяем аргументы на null
            if (candidateDto == null)
                throw new ArgumentNullException($"Параметр {nameof(candidateDto)} не может быть NULL", nameof(candidateDto));
            if (stateDto == null)
                throw new ArgumentNullException($"Параметр {nameof(stateDto)} не может быть NULL", nameof(stateDto));


            // проверяем, есть ли такой кандидат
            Candidate candidate = _candidateRepository.FirstOrDefault(candidateDto.Id);
            if (candidate == null)
                throw new EntityNotFoundException($"Кандидат {candidateDto.Id} не найден.");

            // проверяем есть ли такое состояние в базе
            State state = _stateRepository.FirstOrDefault(stateDto.Id);
            if (state == null)
                throw new EntityNotFoundException($"Состояние {stateDto.Id}  не найдено.");

            //текущее состояние кандидата           
            CandidateState currentState = candidate.State;


            // получаем cписок состояний и проверяем  можно ли перейти в указанное состояние
            List<State> availableStates = _stateMachine.GetAvailableStates(currentState.State);
            if (!availableStates.Exists(x => x.Id == state.Id))
                throw new KeyNotFoundException("Из текущего состояния невозможно перейти в указанное состояние");

            // изменяем состояние кандидата,
            // для этого создаем сущность CandidateState и добавляем ее в репозиторий
            CandidateState candidateState = new CandidateState()
            {
                Candidate = candidate,
                State = state,
                TransitionDate = DateTime.Now,
                Comment = comment
            };

            CandidateState insertedCandidateState = Repository.Insert(candidateState);

            //получаем и возвращаем кандидата с новым состоянием
            candidate = _candidateRepository.Get(candidateDto.Id);
            var newCandidateDto = ObjectMapper.Map<CandidateDto>(candidate);
            return newCandidateDto;

        }


        /// <summary>
        /// Изменение состояния кандидата
        /// </summary>
        /// <param name="candidateDto">кандидат, у которого нужно изменить состояние</param>
        /// <param name="stateDto">состояние, на который нужно поменять текущий состояние</param>        
        /// <returns></returns>
        public CandidateDto ChangeState(CandidateDto candidateDto, StateDto stateDto)
        {
            return ChangeState(candidateDto, stateDto, "");
        }

        /// <summary>
        /// Спискок состояний в которые можно перейти из указанного состояния
        /// </summary>
        /// <param name="stateDto">Состояние от которого хотим перейти в другие состояния
        /// Если аргумент null или имеет пустой GUID, тогда возвращается список с начальным состоянием</param>
        /// <returns></returns>
        public List<StateDto> GetAvailableStates(StateDto stateDto)
        {
            State state = (stateDto != null)
                ? ObjectMapper.Map<State>(stateDto)
                : GetEmptyState();
            var availableStates = _stateMachine.GetAvailableStates(state);
            var availableStatesDto = ObjectMapper.Map<List<StateDto>>(availableStates);
            return availableStatesDto;
        }

        /// <summary>
        /// Метод возвращает объект класса State с пустым GUID
        /// </summary>
        /// <returns></returns>
        private State GetEmptyState()
        {
            State emptyState = new State() { Id = Guid.Empty };
            return emptyState;
        }

    }
}
