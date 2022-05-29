using System;
using Abp.Domain.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Api.Dao.Repositories
{
    public interface IPositionAppointmentRepository : IRepository<PositionAppointment, Guid>
    {
    }
}
