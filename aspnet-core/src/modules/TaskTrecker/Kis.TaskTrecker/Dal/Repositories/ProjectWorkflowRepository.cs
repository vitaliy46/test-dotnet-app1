using Abp.EntityFrameworkCore;
using Kis.TaskTrecker.Api.Dao.Repositories;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker.Dal.Repositories
{
    public class ProjectWorkflowRepository : TaskTreckerRepositoryBase<ProjectWorkflow>, IProjectWorkflowRepository
    {
        public ProjectWorkflowRepository(IDbContextProvider<TaskTreckerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}