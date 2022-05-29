using Abp.EntityFrameworkCore;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="State"/>.
    /// </summary>
    public class WorkflowRepository : GeneralRepositoryBase<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
