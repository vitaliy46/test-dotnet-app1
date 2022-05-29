using Abp.Domain.Repositories;
using System;
using Kis.Voting.Api.Entity;


namespace Kis.Voting.Api.Dao.Repositories
{
  public  interface IVoteResultRepository: IRepository<VoteResult, Guid>
    {
    }
}
