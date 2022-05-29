using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    public class NoticeReceiptConfirmationRepository: VotingRepositoryBase<NoticeReceiptConfimation>, INoticeReceiptConfirmationRepository
    {
        public NoticeReceiptConfirmationRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
