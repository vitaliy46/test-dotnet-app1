using System;
using System.Linq;
using System.Threading.Tasks;
using Kis.General.Api.Services.Crud;
using Kis.Staff.Api.Services;
using Kis.Web.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Staff.Web.Controllers
{
    public class EmployeesController : KisControllerBase
    {
        private readonly IPersonCrudAppService _personCrudCrudAppService;
        private readonly IEmployeeAsyncAppService _employeeAppService;
        private readonly IPositionAsyncCrudAppService _positionCrudAppService;

        public EmployeesController(
            IPersonCrudAppService personCrudCrudAppService,
            IPositionAsyncCrudAppService positionCrudAppService,
            IEmployeeAsyncAppService employeeAppService) 
        {
            _personCrudCrudAppService = personCrudCrudAppService;
            _positionCrudAppService = positionCrudAppService;
            _employeeAppService = employeeAppService;
        }

        /// <summary>
        /// Принятие сотрудника на работу.
        /// </summary>
        /// <param name="personId">Идентификатор устраиваемого лица</param>
        /// <param name="organizationUnitId">Идентификатор организации</param>
        /// <param name="positionId">Идентификатор должности</param>
        /// <param name="employmentDate">Дата принятия на работу</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RecruitPerson(Guid personId, Guid positionId, DateTime employmentDate)
        {
            
                var personDto = _personCrudCrudAppService.GetAll(null)
                                .Result.Items.FirstOrDefault(x=>x.Id == personId);
                if (personDto == null) return NotFound();

                var positionDto = await _positionCrudAppService.Get(positionId);
                if (positionDto == null) return NotFound();

                var employeeDto = _employeeAppService.RecruitPerson(personDto, positionDto, employmentDate);

            return  Ok(employeeDto);
           
        }

       

        /// <summary>
        /// Увольнение сотрудника.
        /// </summary>
        /// <param name="employeeId">Идентификатор увольняемого сотрудника</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Dismiss(Guid employeeId)
        {
           
                var employeeDto = await _employeeAppService.Get(employeeId);
                if (employeeDto == null)
                    return NotFound();

                _employeeAppService.Dismiss(employeeDto);
                return NoContent();
           
        }

        /// <summary>
        /// Перевод сотрудника с одной должности на другую.
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="positionId">Идентификатор новой должности</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Reassignment(Guid employeeId, Guid positionId)
        {
           
                var employeeDto = await _employeeAppService.Get(employeeId);
                if (employeeDto == null) return NotFound();

                var positionDto = await _positionCrudAppService.Get(positionId);
                if (positionDto == null) return NotFound();

                var updateEmployeeDto = _employeeAppService.Reassignment(employeeDto, positionDto);
                return Ok(updateEmployeeDto);
        }

        /// <summary>
        /// Задание даты устройства сотрудника на работу.
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="employmentDate">Строка содержащая значение устанавливаемой даты</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SetEmploymentDate(Guid employeeId, string employmentDate)
        {
                if (!DateTime.TryParse(employmentDate, out DateTime dateParce))
                    return BadRequest();

                var employeeDto = await _employeeAppService.Get(employeeId);
                if (employeeDto == null) return NotFound();

                var updateEmployeeDto = _employeeAppService.SetEmploymentDate(employeeDto, dateParce);
                return new ObjectResult(updateEmployeeDto);
        }
    }
}
