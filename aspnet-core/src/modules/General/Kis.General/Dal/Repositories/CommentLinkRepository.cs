using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="CommentLink"/>
    /// </summary>
    public class CommentLinkRepository : GeneralRepositoryBase<CommentLink>, ICommentLinkRepository
    {
        public CommentLinkRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}