using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.General.Exceptions;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Dto.VoteMember;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;
using Kis.Voting.Exceptions;
using Microsoft.AspNetCore.Mvc;
using PermissionNames = Kis.Voting.Authorization.PermissionNames;

namespace Kis.Voting.Web.Controllers
{
    //[Authorize("Pages.Votes")]
    [Route("api/[controller]")]
    public class VoteController : KisControllerBase<IVoteCrudAppService>
    {
        private IVotingApplicationService _votingAppService;
        private readonly IVoteMemberCrudAppService _voteMemberCrudAppService;

        public VoteController(IVoteCrudAppService crudAppService,
            [NotNull] IVotingApplicationService votingAppService,
            [NotNull] IVoteMemberCrudAppService voteMemberCrudAppService) : base(crudAppService)
        {
            _voteMemberCrudAppService = voteMemberCrudAppService ?? throw new ArgumentNullException(nameof(voteMemberCrudAppService));
            _votingAppService = votingAppService ?? throw new ArgumentNullException(nameof(votingAppService));
        }

        [AbpAuthorize(PermissionNames.VoteDetails, PermissionNames.Voting)]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetVoteDto>> Get([FromRoute]Guid id)
        {
            var voteDto = await CrudService.Get(id);

            var voteMember = (await _voteMemberCrudAppService.GetAll(new PagedVoteMemberResultRequestDto(){ VoteId = voteDto.Id })).Items.FirstOrDefault(x => x.UserId == AbpSession.UserId);

            if (voteMember == null && voteDto.InitiatorId != AbpSession.UserId)
            {
                return new VotePermissionViolation();
            }

            return voteDto.MapTo<GetVoteDto>();
        }

        public class VotePermissionViolation : ObjectResult
        {
            public VotePermissionViolation() : base(new { error = "Вам не доступно запрашиваемое голосование." })
            {
                StatusCode = 500;
            }
        }

        [AbpAuthorize(PermissionNames.VoteList)]
        [HttpGet]
        public async Task<PagedResultDto<VoteShortDto>> Get(VotePagedAndSortedResultRequestDto input)
        {
            var votesPagedResultDto = await _votingAppService.GetVotesPagedResultDto();

            return votesPagedResultDto;
        }

        [AbpAuthorize(PermissionNames.VoteManagement)]
        [HttpPost]
        public  async Task<GetVoteDto> Post([FromBody]CreateVoteDto value)
        {
            var dto = await _votingAppService.SaveAsync(value.MapTo<VoteDto>());

            return dto.MapTo<GetVoteDto>();
        }

        [AbpAuthorize(PermissionNames.VoteManagement)]
        [HttpPut("{id}")]
        public  async Task<GetVoteDto> Put([FromRoute]Guid id, [FromBody]UpdateVoteDto value)
        {
            var dto = await _votingAppService.SaveAsync(value.MapTo<VoteDto>());

            return dto.MapTo<GetVoteDto>();
        }

        /// <summary>
        /// Публикация голосования
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.VoteManagement)]
        [HttpPost]
        [Route("[action]")]
        public async Task<GetVoteDto> Publish([FromBody] UpdateVoteDto value)
        {
            var dto = await _votingAppService.Publish(value.MapTo<VoteDto>());

            return dto.MapTo<GetVoteDto>();
        }

        /// <summary>
        /// Участник проголосовал
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.Voting)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<VotedOutputViewModel>> Voted([FromBody] CreateBulletinDto input)
        {
            (BulletinDto bulletin, float votersPersent) result;

            try
            {
                result = await _votingAppService.Voted(input.MapTo<BulletinDto>());
            }
            catch (OneTimePasswordException e)
            {
                return new OnTimePasswordErrorResult(e);
            }
            catch (BulletingException e)
            {
                return new BulletingErrorResult(e);
            }

            return Ok(new VotedOutputViewModel{BulletinDto = result.bulletin, votersPersent = result.votersPersent });
        }

        public class OnTimePasswordErrorResult : ObjectResult
        {
            public OnTimePasswordErrorResult(OneTimePasswordException e) : base(new { error = e.GetType().Name, message = e.Message })
            {
                StatusCode = 500;
            }
        }

        public class BulletingErrorResult : ObjectResult
        {
            public BulletingErrorResult(BulletingException e) : base(new { error = e.GetType().Name, message = e.Message })
            {
                StatusCode = 500;
            }
        }

        public class VotedOutputViewModel
        {
            public BulletinDto BulletinDto { get; set; }
            /// <summary>
            /// Количество проголосовавших участников на момент подачи бюллетеня
            /// </summary>
            public float votersPersent { get; set; }
        }

        /// <summary>
        /// Запрос на уже подписанный отчет
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.Voting)]
        [HttpGet("GetResultReport/{id}")]
        public async Task<FileResult> GetResultReport([FromRoute]Guid id)
        {
            return File(await _votingAppService.GetResultReportAsync(id), "application/pdf", $"{id}.pdf");
        }
    }
}
