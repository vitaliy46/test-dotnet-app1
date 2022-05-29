using System;
using System.Collections.Generic;
using System.Linq;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;
using Kis.General.Api.Services;

namespace Kis.General.Services
{
    /// <summary>
    /// Представляет сервис, который осуществляет переходы из одного 
    /// состояния в другое
    /// </summary>
    public class StateMachine : IStateMachine
    {
        private readonly IStateTransitionRepository _stateTransitionRepository;

        public StateMachine(IStateTransitionRepository stateTransitionRepository)
        {
            _stateTransitionRepository = stateTransitionRepository;
        }

        /// <summary>
        /// Список состояний в которые доступен переход.
        /// </summary>
        /// <param name="state">Состояние от которого переходим.
        /// Если аргумент имеет пустой GUID, тогда возвращается список с начальным состоянием</param>
        /// <returns></returns>
        public List<State> GetAvailableStates(State state)
        {
            if (state == null)
                throw new ArgumentNullException($"Параметр {nameof(state)} не может быть NULL", nameof(state));

            return _stateTransitionRepository
                .GetAllList(x => x.StateFrom.Id == state.Id)
                .Select(y => y.StateTo)
                .ToList();
        }
    }
}
