using System;
using Abp.Domain.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Api.Dao.Repositories
{
    /// <summary>
    /// Интерфейс репозитория для <see cref="KarmaType"/>
    /// </summary>
    public interface IKarmaTypeRepository : IRepository<KarmaType, Guid>
    { }
}
