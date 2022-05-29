using System;
using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="Address"/>
    /// </summary>
    public class AddressRepository : GeneralRepositoryBase<Address, Guid>, IAddressRepository
    {
        public AddressRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}