using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto.Vote;

namespace Kis.Voting.Services.Crud
{
     public class VoteResultCrudAppService: AsyncCrudAppServiceBase<VoteResult, VoteResultDto, Guid, VoteResultPagedAndSortedRequestDto, VoteResultDto, VoteResultDto, VoteResultDto, VoteResultDto>, IVoteResultCrudAppService
    {

        public VoteResultCrudAppService(
            [NotNull] IVoteResultRepository voteResultRepository) : base(voteResultRepository)
        {
        }

        protected override IQueryable<VoteResult> CreateFilteredQuery(VoteResultPagedAndSortedRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            if (input.VoteId != null)
            {
                query = query.Where(x => x.VoteId == input.VoteId);
            }

            return query;
        }
    }
}
