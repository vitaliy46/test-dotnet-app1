using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using JetBrains.Annotations;
using Kis.Investors.Api.Services.Bl;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Investors.Service.Bl
{
    /// <summary>
    /// Предоставляет участников голосования по указанному голосованию
   /// </summary>
    public class InvestorsVoteMembersProvider : ApplicationService, IVoteMembersProvider
    {
        private readonly IInvestorApplicationService _investorApplicationService;
        private readonly IVoteRepository _voteRepository;
        private readonly IVoteMemberCrudAppService _voteMemberCrudService;

        public InvestorsVoteMembersProvider([NotNull] IInvestorApplicationService investorApplicationService,
            [NotNull] IVoteRepository voteRepository, [NotNull] IVoteMemberCrudAppService voteMemberCrudService)
        {
            _voteMemberCrudService = voteMemberCrudService ?? throw new ArgumentNullException(nameof(voteMemberCrudService));
            _investorApplicationService = investorApplicationService ?? throw new ArgumentNullException(nameof(investorApplicationService));
            _voteRepository = voteRepository ?? throw new ArgumentNullException(nameof(voteRepository));
        }

        public async Task<IList<VoteMemberDto>> GetVoteMembers(Guid voteId)
        {
            var vote = await _voteRepository.GetAsync(voteId);

            var voteMembers =  (await _investorApplicationService.PrepareVoteMembers(vote.ContextId)).ToList();

            voteMembers.ForEach(m=>m.VoteId = voteId);

            return voteMembers;
        }
    }
}
