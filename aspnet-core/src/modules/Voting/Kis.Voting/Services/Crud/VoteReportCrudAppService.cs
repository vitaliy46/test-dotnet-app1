using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.VoteMember;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteReportCrudAppService : AsyncCrudAppServiceBase<VoteReport, VoteReportDto, Guid, PagedVoteReportResultRequestDto, VoteReportDto, VoteReportDto, VoteReportDto, VoteReportDto>, IVoteReportCrudAppService
    {
        private readonly IMediaCrudAppService _mediaCrudAppService;
        private readonly IVoteReportMediaCrudAppService _voteReportMediaCrudAppService;

        public VoteReportCrudAppService([NotNull]IRepository<VoteReport, Guid> repository,
                                        [NotNull] IMediaCrudAppService mediaCrudAppService,
                                        [NotNull] IVoteReportMediaCrudAppService voteReportMediaCrudAppService) : base(repository)
        {
            _voteReportMediaCrudAppService = voteReportMediaCrudAppService ?? throw new ArgumentNullException(nameof(voteReportMediaCrudAppService));
            _mediaCrudAppService = mediaCrudAppService ?? throw new ArgumentNullException(nameof(mediaCrudAppService));
        }

        public override async Task<PagedResultDto<VoteReportDto>> GetAll(PagedVoteReportResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<VoteReportDto>();

            foreach (var item in result.Items)
            {
                item.ReportFile = (await _voteReportMediaCrudAppService.GetAll(new PagedVoteReportMediaResultRequestDto(){ VoteReportId = item.Id })).Items.FirstOrDefault();
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<VoteReportDto> Create(VoteReportDto input)
        {
            // сначала сохраняем VoteReport и Media от которых зависит VoteReportMedia
            var voteReportDto = await base.Create(input);
            var media = await _mediaCrudAppService.Create(input.ReportFile.Media);

            voteReportDto.ReportFile.VoteReportId = voteReportDto.Id;
            voteReportDto.ReportFile.Media = media;
            voteReportDto.ReportFile.MediaId = media.Id;

            voteReportDto.ReportFile = await _voteReportMediaCrudAppService.Create(voteReportDto.ReportFile);
            
            return voteReportDto;
        }

        protected override IQueryable<VoteReport> CreateFilteredQuery(PagedVoteReportResultRequestDto input)
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
