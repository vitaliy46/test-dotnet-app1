using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="Policy"/>
    /// </summary>
    public class PolicyRepository : GeneralRepositoryBase<Policy>, IPolicyRepository
    {
        public PolicyRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}