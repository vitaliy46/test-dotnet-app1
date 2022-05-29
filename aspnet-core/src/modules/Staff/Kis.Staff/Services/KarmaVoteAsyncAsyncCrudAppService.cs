using System;
using Kis.Base.Services.Bl;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;
using Kis.Staff.Api.Services;

namespace Kis.Staff.Services
{
    public class KarmaVoteAsyncAsyncCrudAppService: AsyncCrudAppServiceBase<KarmaVote, KarmaVoteDto, Guid>, IKarmaVoteAsyncCrudAppService
    {
        private readonly IKarmaVoteRepository _karmaVoteRepository;

        public KarmaVoteAsyncAsyncCrudAppService(IKarmaVoteRepository karmaVoteRepository) : base(karmaVoteRepository)
        {
            _karmaVoteRepository = karmaVoteRepository;
        }
    }
}