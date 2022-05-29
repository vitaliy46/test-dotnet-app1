using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Api.Services.Bl
{
    /// <summary>
    /// Калькулятор результатов голосования
    /// </summary>
    public interface IVoteCalculator 
    {
        /// <summary>
        ///Подводит результат голосования
        /// </summary>
        ///<param name="factQuorumPct">фактический процент проголосовавших</param>
        /// <returns></returns>
        VoteResultDto Calculate(VoteDto vote, float factQuorumPct);
    }
}
