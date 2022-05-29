using System;
using Abp.Domain.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Dal.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="StateTransition"/>
    /// </summary>
    public interface IStateTransitionRepository : IRepository<StateTransition, Guid>
    { }
}
