using System;
using Kis.Base.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Dto.Vote;

namespace Kis.Voting.Api.Services.Crud
{
    public interface IBulletinCrudAppService : IAsyncCrudAppServiceBase<BulletinDto, Guid, PagedBulletinResultRequestDto, BulletinDto, BulletinDto, BulletinDto, BulletinDto>
    {
    }


}
