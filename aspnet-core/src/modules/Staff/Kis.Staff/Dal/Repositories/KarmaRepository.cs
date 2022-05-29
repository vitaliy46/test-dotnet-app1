using Abp.EntityFrameworkCore;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="Karma"/>
    /// </summary>
    public class KarmaRepository : StaffRepositoryBase<Karma>, IKarmaRepository
    {
        public KarmaRepository(IDbContextProvider<StaffDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}