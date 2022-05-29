using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace Kis.Base.Services.Crud
{

    public interface IAsyncCrudAppServiceBase<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, TUpdateInput, TGetInput, TDeleteInput> :
        IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        Task<TEntityDto> Get(TPrimaryKey id);

        Task Delete(TPrimaryKey id);
    }
    public interface IAsyncCrudAppService<TDto, TKey> :
        IAsyncCrudAppServiceBase<TDto, TKey, PagedAndSortedResultRequestDto, TDto, TDto, TDto, TDto>
        where  TDto : IEntityDto<TKey>
    {
    }
}
