using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteLinkCrudAppService : AsyncCrudAppServiceBase<VoteLink, VoteLinkDto, Guid>, IVoteLinkCrudAppService
    {
        private readonly ILinkCrudAppService _linkCrudService;

        public VoteLinkCrudAppService(
            [NotNull]IRepository<VoteLink, Guid> repository,
            [NotNull] ILinkCrudAppService linkCrudService) : base(repository)
        {
            _linkCrudService = linkCrudService ?? throw new ArgumentNullException(nameof(linkCrudService));
        }

        public override async Task<VoteLinkDto> Get(VoteLinkDto input)
        {
            var dto = await base.Get(input);

            dto.Link = await _linkCrudService.Get(dto.LinkId);

            return dto;
        }

        public override async Task<VoteLinkDto> Get(Guid id)
        {
            return await this.Get(new VoteLinkDto() { Id = id });
        }

        public override async Task<PagedResultDto<VoteLinkDto>> GetAll(PagedAndSortedResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<VoteLinkDto>();

            foreach (var item in result.Items)
            {
                item.Link = await _linkCrudService.Get(item.LinkId);
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<VoteLinkDto> Create(VoteLinkDto input)
        {
            CheckCreatePermission();

            //Выделяется из данных input часть, которая соответсвует Link
            //и сохраняется с помощью linkCrudService
            input.LinkId = (await _linkCrudService.Create(input.Link)).Id;

            var entity = MapToEntity(input);

            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public override async Task<VoteLinkDto> Update(VoteLinkDto input)
        {
            var personAddressDto = await base.Update(input);
            personAddressDto.Link = await _linkCrudService.Update(input.Link);

            return personAddressDto;
        }

        public override async Task Delete(VoteLinkDto input)
        {
            await base.Delete(input.Id);

            await _linkCrudService.Delete(input.Link.Id);
        }

        public override async Task Delete(Guid id)
        {
            var dto = await base.Get(id);

            if (dto == null)
            {
                throw new Exception("Попытка удалить несуществующую запись");
            }
            await base.Delete(id);

            await _linkCrudService.Delete(dto.LinkId);
        }
    }
    
}
