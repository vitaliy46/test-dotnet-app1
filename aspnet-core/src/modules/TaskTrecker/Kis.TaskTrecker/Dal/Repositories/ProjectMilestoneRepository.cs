using Abp.EntityFrameworkCore;
using Kis.TaskTrecker.Api.Dao.Repositories;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker.Dal.Repositories
{
    public class ProjectMilestoneRepository : TaskTreckerRepositoryBase<ProjectMilestone>, IProjectMilestoneRepository
    {
        public ProjectMilestoneRepository(IDbContextProvider<TaskTreckerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}