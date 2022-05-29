using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="PersonAddress"/>
    /// </summary>
    public class PersonAddressRepository : GeneralRepositoryBase<PersonAddress>, IPersonAddressRepository
    {
        public PersonAddressRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}