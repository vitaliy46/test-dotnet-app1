using Abp.Domain.Repositories;
using Kis.Voting.Api.Entity;
using System;

namespace Kis.Voting.Api.Dao.Repositories
{
    public interface IVoteLinkRepository:IRepository<VoteLink, Guid>
    {
    }
}
