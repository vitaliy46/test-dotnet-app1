using System;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.General.Api.Dto.Comment;
using Kis.Investors.Api.Dto;

namespace Kis.Investors.Api.Services.Crud
{
    public interface IInvestedProjectCrudAppService : 
        IAsyncCrudAppServiceBase<InvestedProjectDto, Guid, 
            PagedInvestedProjectResultRequestDto, InvestedProjectDto, 
            InvestedProjectDto, InvestedProjectDto, InvestedProjectDto>
    {
    }
}
