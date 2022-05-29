using System;
using Abp.Application.Services;
using Kis.Voting.Api.Constant;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Api.Services.Bl
{
    /// <summary>
    /// Определитель калькулятора результатов голосования
    /// </summary>
    public interface IVoteCalculatorQualifier : IApplicationService
    {
        /// <summary>
        /// Выбирает подходящий для голосования механизм подведения итогов
        /// </summary>
        /// <param name="vote"></param>
        /// <returns></returns>
        IVoteCalculator Define(VotingCalculationTypes type);
    }
}
