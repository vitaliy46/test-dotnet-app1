using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="PersonContact"/>
    /// </summary>
    public class PersonContactRepository : GeneralRepositoryBase<PersonContact>, IPersonContactRepository
    {
        public PersonContactRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}