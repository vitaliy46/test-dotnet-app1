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
    public class VoteReportMediaCrudAppService : AsyncCrudAppServiceBase<VoteReportMedia, VoteReportMediaDto, Guid, PagedVoteReportMediaResultRequestDto, VoteReportMediaDto, VoteReportMediaDto, VoteReportMediaDto, VoteReportMediaDto>, IVoteReportMediaCrudAppService
    {
        private readonly IMediaCrudAppService _mediaCrudService;

        public VoteReportMediaCrudAppService(
            [NotNull] IRepository<VoteReportMedia, Guid> repository,
            [NotNull] IMediaCrudAppService mediaCrudService) : base(repository)
        {
            _mediaCrudService = mediaCrudService ?? throw new ArgumentNullException(nameof(mediaCrudService));
        }

        public override async Task<VoteReportMediaDto> Get(VoteReportMediaDto input)
        {
            var dto = await base.Get(input);

            dto.Media = await _mediaCrudService.Get(dto.MediaId);

            return dto;
        }

        public override async Task<VoteReportMediaDto> Get(Guid id)
        {
            return await this.Get(new VoteReportMediaDto() { Id = id });
        }

        public override async Task<PagedResultDto<VoteReportMediaDto>> GetAll(PagedVoteReportMediaResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<VoteReportMediaDto>();

            foreach (var item in result.Items)
            {
                item.Media = await _mediaCrudService.Get(item.MediaId);
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        //public override async Task<VoteReportMediaDto> Create(VoteReportMediaDto input)
        //{
        //    CheckCreatePermission();

        //    //Выделяется из данных input часть, которая соответсвует Media
        //    //и сохраняется с помощью mediaCrudService
        //    input.MediaId = (await _mediaCrudService.Create(input.Media)).Id;

        //    var entity = MapToEntity(input);

        //    await Repository.InsertAsync(entity);
        //    await CurrentUnitOfWork.SaveChangesAsync();

        //    return MapToEntityDto(entity);
        //}

        // закомментированный метод не сохранит VoteReportMedia 
        // т.к. необходим обязательный внешний ключ от VoteReport,
        // который в него не передается
        public override async Task<VoteReportMediaDto> Create(VoteReportMediaDto input)
        {
            return await base.Create(input);
        }

        public override async Task<VoteReportMediaDto> Update(VoteReportMediaDto input)
        {
            var personAddressDto = await base.Update(input);
            personAddressDto.Media = await _mediaCrudService.Update(input.Media);

            return personAddressDto;
        }

        public override async Task Delete(VoteReportMediaDto input)
        {
            await base.Delete(input.Id);

            await _mediaCrudService.Delete(input.Media.Id);
        }

        public override async Task Delete(Guid id)
        {
            var dto = await base.Get(id);

            if (dto == null)
            {
                throw new Exception("Попытка удалить несуществующую запись");
            }
            await base.Delete(id);

            await _mediaCrudService.Delete(dto.MediaId);
        }

        protected override IQueryable<VoteReportMedia> CreateFilteredQuery(PagedVoteReportMediaResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            if (input.VoteReportId != null)
            {
                query = query.Where(x => x.VoteReportId == input.VoteReportId);
            }

            return query;
        }
    }
}
