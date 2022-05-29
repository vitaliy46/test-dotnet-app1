using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AutoMapper;
using Kis.Base.Web.Controller;
using Kis.Controllers;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Services.Crud;
using Microsoft.AspNetCore.Mvc;


namespace Kis.General.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class PersonController : KisControllerBase<IPersonCrudAppService>
    {
        public PersonController(IPersonCrudAppService crudAppService) : base(crudAppService)
        { }
      
        //[HttpGet("{id}")]
        //public async Task<PersonDto> Get([FromRoute]Guid id)
        //{
        //    var dto = await CrudService.Get(id);

        //    return dto;
        //}
    }
}
