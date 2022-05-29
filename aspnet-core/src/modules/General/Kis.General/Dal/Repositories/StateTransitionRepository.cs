using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="StateTransition"/>.
    /// </summary>
    public class StateTransitionRepository : GeneralRepositoryBase<StateTransition>, IStateTransitionRepository
    {
        public StateTransitionRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
