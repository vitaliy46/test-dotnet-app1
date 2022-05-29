using System;
using Abp.Domain.Repositories;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker.Api.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий для проектов.
    /// </summary>
    public interface IProjectRepository : IRepository<Project, Guid>
    {
    }
}
