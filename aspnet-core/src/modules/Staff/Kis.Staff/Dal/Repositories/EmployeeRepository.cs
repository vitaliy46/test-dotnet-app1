using Abp.EntityFrameworkCore;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="Employee"/>
    /// </summary>
    public class EmployeeRepository : StaffRepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContextProvider<StaffDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
