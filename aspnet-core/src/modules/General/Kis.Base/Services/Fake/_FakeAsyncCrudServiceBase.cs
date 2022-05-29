using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace Kis.Base.Services.Fake
{
    public class FakeAsyncCrudAppServiceBase<TEntity, TDto, TKey> :
        AsyncCrudAppService<TEntity, TDto, TKey, PagedAndSortedResultRequestDto, TDto, TDto, TDto, TDto>, Crud.IAsyncCrudAppService<TDto, TKey>
        where TEntity : class, IEntity<TKey>
        where TDto : IEntityDto<TKey>, new()
    {
        public FakeAsyncCrudAppServiceBase(IRepository<TEntity, TKey> repository) : base(repository)
        { }

        public Task<TDto> Get(EntityDto<TKey> input)
        {
            var task = Task.Run(() =>new TDto());

            return task;
        }
        public Task<TDto> Get(TKey id)
        {
            var task = Task.Run(() => new TDto());

            return task;
        }

        public Task<PagedResultDto<TDto>> GetAll(PagedAndSortedResultRequestDto input)
        {
            var task = Task.Run(() => new PagedResultDto<TDto>());

            return task;
        }

        public Task<TDto> Create(TDto input)
        {
            var task = Task.Run(() => input);

            return task;
        }

        public Task<TDto> Update(TDto input)
        {
            var task = Task.Run(() => input);

            return task;
        }

        public Task Delete(EntityDto<TKey> input)
        {
            var task = Task.Run(() => { });

            return task;
        }

      

        public Task Delete(TKey id)
        {
            var task = Task.Run(() => { });

            return task;
        }
    }
}
