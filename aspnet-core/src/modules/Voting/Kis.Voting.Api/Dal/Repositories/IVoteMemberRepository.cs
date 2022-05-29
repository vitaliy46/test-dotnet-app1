using Abp.Domain.Repositories;
using Kis.Voting.Api.Entity;
using System;

namespace Kis.Voting.Api.Dao.Repositories
{
    /// <summary>
    /// VoteMember repository interface
    /// </summary>
    public interface IVoteMemberRepository: IRepository<VoteMember,Guid>
    {
    }
}
