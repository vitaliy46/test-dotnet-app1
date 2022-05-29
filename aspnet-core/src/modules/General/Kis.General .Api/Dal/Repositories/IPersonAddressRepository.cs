using System;
using Abp.Domain.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Dal.Repositories
{
    /// <summary>
    /// Представляет репозиторий для адресов персон.
    /// </summary>
    public interface IPersonAddressRepository : IRepository<PersonAddress, Guid>
    {
    }
}