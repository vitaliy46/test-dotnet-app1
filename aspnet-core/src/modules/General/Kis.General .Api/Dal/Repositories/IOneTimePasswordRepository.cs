using System;
using Abp.Domain.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Dal.Repositories
{
    /// <summary>
    /// Представляет репозиторий для одноразовых паролей.
    /// </summary>
    public interface IOneTimePasswordRepository : IRepository<OneTimePassword, Guid>
    {
    }
}
