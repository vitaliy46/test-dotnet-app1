using System;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Kis.Base.Services.Bl;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;
using Kis.Staff.Api.Services;

namespace Kis.Staff.Services
{
    public class PositionAsyncAsyncCrudAppService : AsyncCrudAppServiceBase<Position, PositionDto, Guid>, IPositionAsyncCrudAppService
    {
        private readonly IKarmaRepository _karmaRepository;

        public PositionAsyncAsyncCrudAppService (IPositionRepository PositionsRepository,
                                            IKarmaRepository karmaRepository) : base(PositionsRepository)
        {
            _karmaRepository = karmaRepository;
        }

    }
}