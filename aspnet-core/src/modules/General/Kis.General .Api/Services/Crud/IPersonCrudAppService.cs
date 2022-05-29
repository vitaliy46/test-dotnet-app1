using System;
using Kis.Base.Services.Crud;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;

namespace Kis.General.Api.Services.Crud
{
    public interface IPersonCrudAppService : IAsyncCrudAppServiceBase<PersonDto, Guid, PagedPersonResultRequestDto, PersonDto, PersonDto, PersonDto, PersonDto>
    {
    }
}
