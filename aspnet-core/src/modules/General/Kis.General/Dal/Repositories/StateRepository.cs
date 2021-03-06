using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="State"/>.
    /// </summary>
    public class StateRepository : GeneralRepositoryBase<State>, IStateRepository
    {
        public StateRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
