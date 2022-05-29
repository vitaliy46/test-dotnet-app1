using Abp.EntityFrameworkCore;
using Kis.TaskTrecker.Api.Dao.Repositories;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker.Dal.Repositories
{
    public class ProjectMilestoneIssueRelRepository : TaskTreckerRepositoryBase<ProjectMilestoneIssueRel>, IProjectMilestoneIssueRelRepository
    {
        public ProjectMilestoneIssueRelRepository(IDbContextProvider<TaskTreckerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}