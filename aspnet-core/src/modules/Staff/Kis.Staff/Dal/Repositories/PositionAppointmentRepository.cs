using System;
using Abp.EntityFrameworkCore;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories
{
    public class PositionAppointmentRepository : StaffRepositoryBase<PositionAppointment, Guid>, IPositionAppointmentRepository
    {
        public PositionAppointmentRepository(IDbContextProvider<StaffDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
