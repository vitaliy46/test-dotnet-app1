using System;
using System.Linq;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteOptionCrudAppService : AsyncCrudAppServiceBase<VoteOption, VoteOptionDto, Guid, PagedVoteOptionResultRequestDto, VoteOptionDto, VoteOptionDto, VoteOptionDto, VoteOptionDto>, IVoteOptionCrudAppService
    {
        public VoteOptionCrudAppService([NotNull]IRepository<VoteOption, Guid> repository) : base(repository)
        {
        }

        protected override IQueryable<VoteOption> CreateFilteredQuery(PagedVoteOptionResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            if (input.VoteId != null)
            {
                query = query.Where(x => x.VoteId == input.VoteId);
            }

            return query;
        }

        protected override IQueryable<VoteOption> ApplySorting(IQueryable<VoteOption> query, PagedVoteOptionResultRequestDto input)
        {
            query = query.OrderBy(x => x.CreationTime);

            return base.ApplySorting(query, input);
        }
    }
    
}
