using System;
using Abp.Domain.Repositories;
using Kis.Hr.Api.Entity;

namespace Kis.Hr.Api.Dao.Repositories
{
    /// <summary>
    /// Интерфейс репозитория для <see cref="Candidate"/>.
    /// </summary>
    public interface ICandidateRepository : IRepository<Candidate, Guid>
    {
    }
}
