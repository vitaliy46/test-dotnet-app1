using Abp.EntityFrameworkCore;
using Kis.Inventory.Api.Dao.Repositories;

namespace Kis.Inventory.Dao.Repositories
{
    public class InventoryRepository : InventoryRepositoryBase<Api.Entity.Inventory>, IInventoryRepository
    {
        public InventoryRepository(IDbContextProvider<InventoryDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}