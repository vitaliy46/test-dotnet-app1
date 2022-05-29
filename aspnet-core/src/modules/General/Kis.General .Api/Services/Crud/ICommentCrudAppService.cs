using System;
using Abp.Application.Services;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;

namespace Kis.General.Api.Services.Crud
{
    public interface ICommentCrudAppService : IAsyncCrudAppService<CommentDto, Guid, PagedCommentResultRequestDto, CreateCommentDto, CommentDto>
    {
    }

    
}
