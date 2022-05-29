using System;
using Abp.Domain.Repositories;
using Kis.Crm.Api.Entity;

namespace Kis.Crm.Api.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий для проектов.
    /// </summary>
    public interface IProjectRepository : IRepository<Project, Guid>
    {
    }
}
