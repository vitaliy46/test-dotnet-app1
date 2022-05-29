using System;
using Kis.Staff.Api.Services;
using Kis.Web.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Staff.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с кармой
    /// </summary>
    public class KarmaController : KisControllerBase
    {
        private IKarmaAsyncCrudAppService _karmaCrudAppService;

        public KarmaController(IKarmaAsyncCrudAppService karmaCrudAppService)
        {
            _karmaCrudAppService = karmaCrudAppService;
        }

        /// <summary>
        /// Получить список карм определенного сотрудника по заданным критериям выборки
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="skip">Пропустить первые skip элементов списка</param>
        /// <param name="top">Вывести top элементов списка</param>        
        [HttpGet]
        //GET: /api/v1/karma/?employeeId=98a5d943-ee2e-40fb-8889-7766f893b5da&skip=0&top=10
        public IActionResult GetEmployeeKarms(Guid employeeId, int skip = 0, int top = 10)
        {
                var responseModel = _karmaCrudAppService.GetEmployeeKarms(employeeId, skip, top);

                return Ok(responseModel);
        }
        
    }
}
