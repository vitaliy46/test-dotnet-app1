using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий для персон.
    /// </summary>
    public class OneTimePasswordRepository : GeneralRepositoryBase<OneTimePassword>, IOneTimePasswordRepository
    {
        public OneTimePasswordRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
