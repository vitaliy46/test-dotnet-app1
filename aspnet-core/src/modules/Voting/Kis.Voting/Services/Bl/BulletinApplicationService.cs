using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Services.Bl;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Services.Bl
{
    public class BulletinApplicationService : KisAppServiceBase, IBulletinApplicationService
    {
        private readonly IBulletinCrudAppService _bulletinCrudAppService;

        private readonly IVoteMemberCrudAppService _voteMemberCrudAppService;

        public BulletinApplicationService([NotNull] IBulletinCrudAppService bulletinCrudAppService,
            [NotNull] IVoteMemberCrudAppService voteMemberCrudAppService)
        {
            _voteMemberCrudAppService = voteMemberCrudAppService ?? throw new ArgumentNullException(nameof(voteMemberCrudAppService));
            _bulletinCrudAppService = bulletinCrudAppService ?? throw new ArgumentNullException(nameof(bulletinCrudAppService));
        }

        /// <summary>
        /// По указанному голосованию и для текущего пользователя находится бюллетень
        /// голосования
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        public async Task<BulletinDto> GetForVote(Guid voteId)
        {
            var bulletins = await _bulletinCrudAppService.GetAll(new PagedBulletinResultRequestDto
            {
                UserId = AbpSession.UserId,
                VoteId = voteId
            });

            return bulletins.Items.FirstOrDefault();
        }
    }
}
