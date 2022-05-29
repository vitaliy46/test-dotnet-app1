using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий для персон.
    /// </summary>
    public class PersonRepository : GeneralRepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
