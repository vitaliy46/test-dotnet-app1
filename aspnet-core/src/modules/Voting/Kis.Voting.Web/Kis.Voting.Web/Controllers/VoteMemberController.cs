using System;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Kis.Voting.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Voting.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class VoteMemberController : KisControllerBase<IVoteMemberCrudAppService>
    {
        private readonly IVoteMemberApplicationService _voteMemberApplicationService;
        public VoteMemberController(IVoteMemberCrudAppService crudAppService,
            [NotNull] IVoteMemberApplicationService voteMemberApplicationService) : base(crudAppService)
        {
            _voteMemberApplicationService = voteMemberApplicationService ?? throw new ArgumentNullException(nameof(voteMemberApplicationService));
        }

        [AbpAuthorize(PermissionNames.VoteMemberGetCurrentForVote)]
        [HttpGet("/GetCurrentMemberForVote/{voteId}")]
        public async Task<VoteMemberDto> GetCurrentMemberForVote([FromRoute]Guid voteId)
        {
            var dto = await _voteMemberApplicationService.GetMemberForVote(voteId);

            return dto;
        }

    }
}
