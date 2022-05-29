using System;
using Abp.Domain.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Dal.Repositories
{
    /// <summary>
    /// Представляет репозиторий для контактов персон.
    /// </summary>
    public interface IPersonContactRepository : IRepository<PersonContact, Guid>
    {
    }
}
