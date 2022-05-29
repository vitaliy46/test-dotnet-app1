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
    public class CommentMediaCrudAppService : AsyncCrudAppServiceBase<CommentMedia, CommentMediaDto, Guid>, ICommentMediaCrudAppService
    {
        private readonly IMediaCrudAppService _mediaCrudService;

        public CommentMediaCrudAppService(
            [NotNull]IRepository<CommentMedia, Guid> repository,
            [NotNull]IMediaCrudAppService mediaCrudService) : base(repository)
        {
            _mediaCrudService = mediaCrudService ?? throw new ArgumentNullException(nameof(mediaCrudService));
        }

        public override async Task<CommentMediaDto> Get(CommentMediaDto input)
        {
            var dto = await base.Get(input);

            dto.Media = await _mediaCrudService.Get(dto.MediaId);

            return dto;
        }

        public override async Task<CommentMediaDto> Get(Guid id)
        {
            return await this.Get(new CommentMediaDto() { Id = id });
        }

        public override async Task<PagedResultDto<CommentMediaDto>> GetAll(PagedAndSortedResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<CommentMediaDto>();

            foreach (var item in result.Items)
            {
                item.Media = await _mediaCrudService.Get(item.MediaId);
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<CommentMediaDto> Create(CommentMediaDto input)
        {
            CheckCreatePermission();

            //Выделяется из данных input часть, которая соответсвует Media
            //и сохраняется с помощью mediaCrudService
            input.MediaId = (await _mediaCrudService.Create(input.Media)).Id;

            var entity = MapToEntity(input);

            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public override async Task<CommentMediaDto> Update(CommentMediaDto input)
        {
            var commentMediaDto = await base.Update(input);
            commentMediaDto.Media = await _mediaCrudService.Update(input.Media);

            return commentMediaDto;
        }

        public override async Task Delete(CommentMediaDto input)
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
    }
}
