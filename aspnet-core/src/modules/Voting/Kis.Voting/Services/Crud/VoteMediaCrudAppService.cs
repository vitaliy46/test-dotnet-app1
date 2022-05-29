using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteMediaCrudAppService : AsyncCrudAppServiceBase<VoteMedia, VoteMediaDto, Guid,
        PagedVoteMediaResultRequestDto, VoteMediaDto,
        VoteMediaDto, VoteMediaDto, VoteMediaDto>, IVoteMediaCrudAppService
    {
        private readonly IMediaCrudAppService _mediaCrudAppService;
        public VoteMediaCrudAppService([NotNull]IRepository<VoteMedia, Guid> repository,
            [NotNull] IMediaCrudAppService mediaCrudAppService) : base(repository)
        {
            _mediaCrudAppService = mediaCrudAppService ?? throw new ArgumentNullException(nameof(mediaCrudAppService));
        }

        public override async Task<PagedResultDto<VoteMediaDto>> GetAll(PagedVoteMediaResultRequestDto input)
        {
            var dtos = await base.GetAll(input);

            foreach (var voteMedia in dtos.Items)
            {
                voteMedia.Media = await _mediaCrudAppService.Get(voteMedia.MediaId);
            }

            return dtos;
        }

        public override async Task<VoteMediaDto> Create(VoteMediaDto input)
        {
            input.Media.Label = "vote_media_files";

            input.MediaId =  (await _mediaCrudAppService.Create(input.Media)).Id;

            return await base.Create(input);
        }

        protected override IQueryable<VoteMedia> CreateFilteredQuery(PagedVoteMediaResultRequestDto input)
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
