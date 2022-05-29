using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JetBrains.Annotations;
using Kis.Base.Dto;
using Kis.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Base.Web.Controller
{
    public abstract class KisControllerBase<TCrudService> : KisControllerBase
        where TCrudService : class, IApplicationService
    {
        protected readonly TCrudService CrudService;

        public KisControllerBase([NotNull] TCrudService crudService)
        {
            CrudService = crudService ?? throw new ArgumentNullException(nameof(crudService));
        }
    }

    public abstract class KisControllerBase<TDto, TKey> : KisControllerBase
        where TKey : struct
        where TDto : BaseDto<TKey>, new()
    {
        protected Services.Crud.IAsyncCrudAppService<TDto, TKey> CrudAppService;
        //protected IAsyncCrudAppService<TDto, TKey, PagedAndSortedResultRequestDto,  TDto,  TDto, TDto, TDto> CrudAppService;

        protected KisControllerBase([NotNull] Services.Crud.IAsyncCrudAppService<TDto, TKey> crudAppService)
        {
            if (crudAppService == null) throw new ArgumentNullException(nameof(crudAppService));
            CrudAppService = crudAppService;
            
        }
        // GET api/values
        [HttpGet]
        public virtual async Task<PagedResultDto<TDto>> Get()
        {
            var pageResultDto = await CrudAppService.GetAll(new PagedAndSortedResultRequestDto());

            //if (pageResultDto == null)
            //{
            //    return NotFound();
            //}

            return pageResultDto;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public virtual async Task<TDto> Get(TKey id)
        {
            var dto = await CrudAppService.Get(id);

            //if (dto == null)
            //{
            //    return NotFound();
            //}

            return dto;
        }

        // POST api/values
        [HttpPost]
        public virtual async Task<TDto> Post([FromBody] TDto value)
        {
            var dto = await CrudAppService.Create(value);
           
            return dto;
        }

        [HttpPut("{id}")]
        public virtual async Task<TDto> Put([FromRoute]TKey id, [FromBody] TDto value)
        {
            var dto = await CrudAppService.Update(value);
           
            return dto;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute]TKey id)
        {
            await CrudAppService.Delete(id);

            return NoContent();
        }

    }
}
