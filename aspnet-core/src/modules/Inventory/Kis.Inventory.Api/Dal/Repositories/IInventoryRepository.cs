using System;
using Abp.Domain.Repositories;

namespace Kis.Inventory.Api.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для инвестора.
    /// </summary>
    public interface IInventoryRepository : IRepository<Entity.Inventory, Guid>
    {
    }
}
