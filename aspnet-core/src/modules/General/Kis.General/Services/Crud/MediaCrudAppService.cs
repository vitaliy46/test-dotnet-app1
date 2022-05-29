using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;

namespace Kis.General.Services.Crud
{
    public class MediaCrudAppService : AsyncCrudAppServiceBase<Media, MediaDto, Guid>, IMediaCrudAppService
    {
        public MediaCrudAppService([NotNull]IRepository<Media, Guid> repository) : base(repository)
        {
        }
    }
    
}
