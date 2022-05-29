using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Voting.Api.Dto.Bulletin;

namespace Kis.Voting.Api.Services.Bl
{
    public interface IBulletinApplicationService : IApplicationService
    {
        /// <summary>
        /// По указанному голосованию и для текущего пользователя находится бюллетень
        /// голосования
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        Task<BulletinDto> GetForVote(Guid voteId);
    }
}