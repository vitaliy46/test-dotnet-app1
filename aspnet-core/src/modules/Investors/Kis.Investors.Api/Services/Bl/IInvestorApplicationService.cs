using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Investors.Api.Dto;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;

namespace Kis.Investors.Api.Services.Bl
{
    public interface IInvestorApplicationService : IApplicationService
    {
        Task<IList<VoteMemberDto>> PrepareVoteMembers(Guid projectId);
        
        /// <summary>
        /// По идентификатору проекта выгружает  всех его инвесторов
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IList<InvestorDto>> GetByProjectId(Guid projectId);

        /// <summary>
        /// Возврашает проекты для указанного члена товарищества, в 
        /// которых он имеет долю собственности (является их инвестором)
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        Task<IList<InvestorsProjectDto>> GetProjects(Guid memberId);
    }
}
