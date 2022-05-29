using System;
using System.Threading.Tasks;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.General.Api.Dto.Comment;
using Kis.Investors.Api.Dto;

namespace Kis.Investors.Api.Services
{
    public interface IMemberContactorCrudAppService : IAsyncCrudAppServiceBase<MemberContactorDto, Guid, PagedMemberContactorResultRequestDto, MemberContactorDto, MemberContactorDto, MemberContactorDto, MemberContactorDto>
    {
    }
}
