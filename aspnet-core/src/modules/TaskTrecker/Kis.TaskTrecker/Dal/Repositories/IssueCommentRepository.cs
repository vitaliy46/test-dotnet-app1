using Abp.EntityFrameworkCore;
using Kis.TaskTrecker.Api.Dao.Repositories;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker.Dal.Repositories
{
    public class IssueCommentRepository : TaskTreckerRepositoryBase<IssueComment>, IIssueCommentRepository
    {
        public IssueCommentRepository(IDbContextProvider<TaskTreckerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}