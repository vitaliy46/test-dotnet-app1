using System.Collections.Generic;
using Abp.Dependency;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Services
{
    /// <summary>
    /// Представляет сервис, который знает переходы из одного состояния в другое.
    /// </summary>
    public interface IStateMachine : ISingletonDependency
    {
        /// <summary>
        /// Список состояний в которые доступен переход.
        /// </summary>
        /// <param name="state">Состояние от которого переходим.
        /// Если аргумент имеет пустой GUID, тогда возвращается список с начальным состоянием</param>
        /// <returns></returns>
        List<State> GetAvailableStates(State state);
    }
}
