using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="CommentMedia"/>
    /// </summary>
    public class CommentMediaRepository : GeneralRepositoryBase<CommentMedia>, ICommentMediaRepository
    {
        public CommentMediaRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}