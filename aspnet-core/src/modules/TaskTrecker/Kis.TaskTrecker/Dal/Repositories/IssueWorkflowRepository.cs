using Abp.EntityFrameworkCore;
using Kis.TaskTrecker.Api.Dao.Repositories;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker.Dal.Repositories
{
    public class IssueWorkflowRepository : TaskTreckerRepositoryBase<IssueWorkflow>, IIssueWorkflowRepository
    {
        public IssueWorkflowRepository(IDbContextProvider<TaskTreckerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}