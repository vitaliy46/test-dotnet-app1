using System;
using Kis.Base.Services.Crud;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;

namespace Kis.General.Api.Services.Crud
{
    public interface IOneTimePasswordCrudAppService : IAsyncCrudAppServiceBase<OneTimePasswordDto, Guid, PagedOneTimePasswordResultRequestDto, OneTimePasswordDto, OneTimePasswordDto, OneTimePasswordDto, OneTimePasswordDto>
    {
    }
}
