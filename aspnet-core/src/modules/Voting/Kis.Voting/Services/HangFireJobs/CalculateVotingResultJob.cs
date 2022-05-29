using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Uow;
using JetBrains.Annotations;
using Kis.Voting.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kis.Voting.Api.Services.Bl;
using Nito.AsyncEx.Synchronous;

namespace Kis.Voting.Services.HangFireJobs
{
    public class CalculateVotingResultJob : BackgroundJob<Guid>, ITransientDependency
    {
        private readonly IVotingApplicationService _votingApplicationService;

        public CalculateVotingResultJob([NotNull] IVotingApplicationService votingApplicationService)
        {
            _votingApplicationService = votingApplicationService ?? throw new ArgumentNullException(nameof(votingApplicationService));
        }

        [UnitOfWork]
        public override void Execute(Guid voteId)
        {
           _votingApplicationService.CalculateAndSaveResult(voteId).WaitAndUnwrapException();
         
            Logger.Debug("Задача на подсчет результатов поставлена");
        }
    }
    
    
}
