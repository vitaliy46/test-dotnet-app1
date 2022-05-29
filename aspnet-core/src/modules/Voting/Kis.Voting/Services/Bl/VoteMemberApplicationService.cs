using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using JetBrains.Annotations;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Services.Bl
{
    public class VoteMemberApplicationService : ApplicationService, IVoteMemberApplicationService
    {
        private readonly IVoteMemberRepository _voteMemberRepository;

        public VoteMemberApplicationService([NotNull] IVoteMemberRepository voteMemberRepository)
        {
            _voteMemberRepository = voteMemberRepository ?? throw new ArgumentNullException(nameof(voteMemberRepository));
        }

        /// <summary>
        /// Для текущего пользователя определяет VoteMember в указаном голосовании
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        public async Task<VoteMemberDto> GetMemberForVote(Guid voteId)
        {
            var userId = AbpSession.UserId;

            // TODO для целей тетстирования пока не начнем работать с аутентификацией
#region
            if (userId == null)
            {
                var members = await _voteMemberRepository.GetAllListAsync(x => x.VoteId == voteId);
                //У любого из членов указанного голосования берем пользователя
                if (!members.Any())
                {
                    return null;
                }
                userId = members[new Random().Next(0, members.Count - 1)].UserId;
            }
#endregion


            var member = (await _voteMemberRepository.GetAllListAsync(x => x.VoteId == voteId && x.UserId == userId)).FirstOrDefault();

            return member.MapTo<VoteMemberDto>();
        }
    }
}
