using Abp.EntityFrameworkCore;
using Kis.Crm.Api.Dao.Repositories;
using Kis.Crm.Api.Entity;

namespace Kis.Crm.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="Deal"/>
    /// </summary>
    public class DealRepository : CrmRepositoryBase<Deal>, IDealRepository
    {
        public DealRepository(IDbContextProvider<CrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}