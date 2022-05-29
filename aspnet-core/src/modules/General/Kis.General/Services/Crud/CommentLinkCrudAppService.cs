using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;

namespace Kis.General.Services.Crud
{
    public class CommentLinkCrudAppService : AsyncCrudAppServiceBase<CommentLink, CommentLinkDto, Guid>, ICommentLinkCrudAppService
    {
        private readonly ILinkCrudAppService _linkCrudService;

        public CommentLinkCrudAppService(
            [NotNull]IRepository<CommentLink, Guid> repository,
            [NotNull]ILinkCrudAppService linkCrudService) : base(repository)
        {
            _linkCrudService = linkCrudService ?? throw new ArgumentNullException(nameof(linkCrudService));
        }

        public override async Task<CommentLinkDto> Get(CommentLinkDto input)
        {
            var dto = await base.Get(input);

            dto.Link = await _linkCrudService.Get(dto.LinkId);

            return dto;
        }

        public override async Task<CommentLinkDto> Get(Guid id)
        {
            return await this.Get(new CommentLinkDto() { Id = id });
        }

        public override async Task<PagedResultDto<CommentLinkDto>> GetAll(PagedAndSortedResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<CommentLinkDto>();

            foreach (var item in result.Items)
            {
                item.Link = await _linkCrudService.Get(item.LinkId);
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<CommentLinkDto> Create(CommentLinkDto input)
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

        public override async Task<CommentLinkDto> Update(CommentLinkDto input)
        {
            var commentLinkDto = await base.Update(input);
            commentLinkDto.Link = await _linkCrudService.Update(input.Link);

            return commentLinkDto;
        }

        public override async Task Delete(CommentLinkDto input)
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
