using System;
using Kis.Base.Services.Crud;
using Kis.General.Api.Dto;

namespace Kis.General.Api.Services.Crud
{
    public interface IMediaCrudAppService : IAsyncCrudAppService<MediaDto, Guid>
    {
    }

    
}
