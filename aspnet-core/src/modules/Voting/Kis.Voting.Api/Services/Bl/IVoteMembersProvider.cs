using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Api.Services.Bl
{
    /// <summary>
    /// Предоставляет участников голосования по указанному голосованию
    /// Может быть реализован разными способами в зависимости от специфики работы приложения
    /// </summary>
    public interface IVoteMembersProvider : IApplicationService
    {
        Task<IList<VoteMemberDto>> GetVoteMembers(Guid voteId);
    }
}
