using Abp.EntityFrameworkCore;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий должностей.
    /// </summary>
    public class PositionRepository : StaffRepositoryBase<Position>
    {
        public PositionRepository(IDbContextProvider<StaffDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
