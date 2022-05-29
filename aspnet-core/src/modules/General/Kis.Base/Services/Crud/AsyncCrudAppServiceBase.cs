using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Kis.Base.Services.Crud;

namespace Kis.Base.Services.Bl
{
    public class AsyncCrudAppServiceBase<TEntity, TDto, TKey> :
        AsyncCrudAppServiceBase<TEntity, TDto, TKey, PagedAndSortedResultRequestDto, TDto, TDto, TDto, TDto>, Crud.IAsyncCrudAppService<TDto, TKey>
        where TEntity : class, IEntity<TKey>
        where TDto : IEntityDto<TKey>, new()
    {
        /// <summary>
        /// Для ручной работы с контейнером и его зависимостями
        /// </summary>
        public  IIocManager IocManager { get; set; }

        public AsyncCrudAppServiceBase(IRepository<TEntity, TKey> repository) : base(repository)
        {}
    }

    public class AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput> :
        AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>,
        IAsyncCrudAppServiceBase<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>, new()
        where TDeleteInput : IEntityDto<TPrimaryKey>, new()
    {
        /// <summary>
        /// Для ручной работы с контейнером и его зависимостями
        /// </summary>
        public IIocManager IocManager { get; set; }

        public AsyncCrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        { }

        public virtual async Task<TEntityDto> Get(TPrimaryKey id)
        {
            return await Get(new TGetInput{Id = id});

        }

        public virtual async Task Delete(TPrimaryKey id)
        {
            await Delete(new TDeleteInput {Id = id});
        }

    }
}
