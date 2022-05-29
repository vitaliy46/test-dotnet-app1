using System;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.Staff.Api.Dto;

namespace Kis.Staff.Api.Services
{
    public interface IKarmaAsyncCrudAppService : IAsyncCrudAppService<KarmaDto, Guid>
    {
        /// <summary>
        /// Список карм определенного сотрудника 
        /// </summary>
        /// <param name="employeeId">Id сотрудника</param>
        /// <param name="skip">skip = n - пропустить первые n элементов списка</param>
        /// <param name="top">top = m - вывести m элементов</param>
        /// <returns>Список DTO моделей кармы одного сотрудника</returns>
        PagedCollectionDto<KarmaDto> GetEmployeeKarms(Guid employeeId, int skip, int top);

        /// <summary>
        /// Число карм определенного сотрудника 
        /// </summary>
        /// <param name="employeeId">>Идентификатор сотрудника</param>
        /// <returns>Колличество карм сотрудника</returns>
        int CountEmployeeKarm(Guid employeeId);
    }

}