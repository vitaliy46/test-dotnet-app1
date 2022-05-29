using System;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;

namespace Kis.General.Services.Crud
{
    public class CommentCrudAppService : AsyncCrudAppService<Comment, CommentDto, Guid, PagedCommentResultRequestDto, CreateCommentDto, CommentDto>, ICommentCrudAppService
    {
        public CommentCrudAppService([NotNull]IRepository<Comment, Guid> repository) : base(repository)
        {
        }
    }
    
}
