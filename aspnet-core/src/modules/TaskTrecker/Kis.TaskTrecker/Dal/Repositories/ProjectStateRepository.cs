using Abp.EntityFrameworkCore;
using Kis.TaskTrecker.Api.Dao.Repositories;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker.Dal.Repositories
{
    public class ProjectStateRepository : TaskTreckerRepositoryBase<ProjectState>, IProjectStateRepository
    {
        public ProjectStateRepository(IDbContextProvider<TaskTreckerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}