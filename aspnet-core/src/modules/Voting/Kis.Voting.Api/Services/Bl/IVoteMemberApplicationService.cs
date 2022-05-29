using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Voting.Api.Dto;

namespace Kis.Voting.Api.Services.Bl
{
    public interface IVoteMemberApplicationService : IApplicationService
    {
        /// <summary>
        /// Для текущего пользователя определяет VoteMember в указаном голосовании
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        Task<VoteMemberDto> GetMemberForVote(Guid voteId);
    }
}