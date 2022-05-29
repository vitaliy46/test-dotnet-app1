using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using JetBrains.Annotations;
using Kis.Investors.Api.Services.Crud;
using Kis.Voting.Api.Services.Bl;

namespace Kis.Investors.Service.Bl
{
    public class VoteContextProvider : ApplicationService, IVoteContextProvider
    {
        private IInvestedProjectCrudAppService _investedProjectCrudService;

        public VoteContextProvider([NotNull] IInvestedProjectCrudAppService investedProjectCrudService)
        {
            _investedProjectCrudService = investedProjectCrudService ?? throw new ArgumentNullException(nameof(investedProjectCrudService));
        }

        public async Task<string> GetVoteContext(Guid contextId)
        {
            return (await _investedProjectCrudService.Get(contextId)).Project.Title;
        }
    }
}
