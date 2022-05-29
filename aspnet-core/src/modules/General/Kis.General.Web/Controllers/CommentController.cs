using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.Controllers;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;
using Kis.General.Api.Services.Crud;
using Microsoft.AspNetCore.Mvc;


namespace Kis.General.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class CommentController : KisControllerBase<ICommentCrudAppService>
    {

        public CommentController([NotNull] ICommentCrudAppService crudService) : base (crudService)
        {}

        //[HttpGet]
        //public async Task<PagedResultDto<CommentDto>> Get()
        //{
        //    var result = await CrudService.GetAll(new PagedCommentResultRequestDto());
        //    var pageResultDto = new PagedResultDto<CommentDto>()
        //    {
        //        TotalCount = result.TotalCount,
        //        Items = result.Items.ToList().Select(x => Mapper.Map<CommentDto>(x)).ToList()
        //    };

        //    return pageResultDto;
        //}

        //[HttpGet("{id}")]
        //public async Task<CommentDto> Get([FromRoute]Guid id)
        //{
        //    var dto = await CrudService.Get(new CommentDto{Id=id});

        //    return dto;
        //}

        //[HttpPut("{id}")]
        //public async Task<CommentDto> Put([FromRoute]Guid id, [FromBody] CommentDto value)
        //{
        //    var dto = await CrudService.Update(value);

        //    return dto;
        //}

        //[HttpPost]
        //public virtual async Task<CommentDto> Post([FromBody] CreateCommentDto value)
        //{
        //    var dto = await CrudService.Create(value);

        //    return dto;
        //}

        //[HttpDelete("{id}")]
        //public virtual async Task<ActionResult> Delete([FromRoute]Guid id)
        //{
        //    await CrudService.Delete(new CommentDto(){Id = id});

        //    return new OkResult();
        //}
    }
}
