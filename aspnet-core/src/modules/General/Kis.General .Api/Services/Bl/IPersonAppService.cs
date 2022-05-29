using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace Kis.General.Api.Services.Bl
{
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
        /// Если с персоной связан зарегистрированный в системе пользователь, то он деактивируется
        /// </summary>
        /// <param name="personId"></param>
        Task DeactivateUserFromPerson(Guid personId);
    }
}
