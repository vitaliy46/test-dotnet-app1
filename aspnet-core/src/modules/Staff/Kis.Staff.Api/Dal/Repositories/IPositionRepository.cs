using System;
using Abp.Domain.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Api.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий должностей.
    /// </summary>
    public interface IPositionRepository : IRepository<Position, Guid>
    {
    }
}
