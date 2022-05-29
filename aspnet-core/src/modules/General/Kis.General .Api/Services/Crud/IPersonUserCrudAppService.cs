using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.PersonUser;

namespace Kis.General.Api.Services.Crud
{
    public interface IPersonUserCrudAppService : IAsyncCrudAppService<PersonUserDto, Guid, PagedPersonUserResultRequestDto, PersonUserDto, PersonUserDto>
    {
        Task<PersonUserDto> GetByPersonId(Guid personId);
    }
}
