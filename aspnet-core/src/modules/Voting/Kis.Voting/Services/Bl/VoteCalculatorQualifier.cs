using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Dependency;
using JetBrains.Annotations;
using Kis.Voting.Api.Constant;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Bl;

namespace Kis.Voting.Services.Bl
{
    /// <summary>
    /// Определитель калькулятора результатов голосования
    /// </summary>
    public class VoteCalculatorQualifier : IVoteCalculatorQualifier
    {
        private readonly IIocResolver _iocResolver;

        public VoteCalculatorQualifier([NotNull] IIocResolver iocResolver)
        {
            _iocResolver = iocResolver ?? throw new ArgumentNullException(nameof(iocResolver));
        }

        /// <summary>
        /// Выбирает подходящий для голосования механизм подведения итогов
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IVoteCalculator Define(VotingCalculationTypes type)
        {
            //По умолчанию используем простейший калькулятор
            var calculator = (IVoteCalculator)_iocResolver.Resolve(typeof(MajorityVoteCalculator));

            switch (type)
            {
                case VotingCalculationTypes.Alternavive:
                    ///TODO Реализовать, когда появятся альтернативный калькулятор
                    break;
                case VotingCalculationTypes.Rating:
                    ///TODO Реализовать, когда появятся калькулятор на основе рейтингов
                    break;
            }

            return calculator;
        }
        
    }

}
