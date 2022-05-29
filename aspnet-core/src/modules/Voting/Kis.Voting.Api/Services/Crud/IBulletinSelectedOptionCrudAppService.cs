using System;
using Kis.Base.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.BulletinSelectedOption;

namespace Kis.Voting.Api.Services.Crud
{
    public interface IBulletinSelectedOptionCrudAppService : IAsyncCrudAppService<BulletinSelectedOptionDto, Guid>
    {
    }


}
