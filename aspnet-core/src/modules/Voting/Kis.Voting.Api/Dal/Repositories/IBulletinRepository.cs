using Abp.Domain.Repositories;
using Kis.Voting.Api.Entity;
using System;

namespace Kis.Voting.Api.Dao.Repositories
{
    public interface IBulletinRepository: IRepository<Bulletin, Guid>
    {
    }
}
