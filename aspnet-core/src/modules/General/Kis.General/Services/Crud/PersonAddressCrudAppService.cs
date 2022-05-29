using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;

namespace Kis.General.Services.Crud
{
    public class PersonAddressCrudAppService : AsyncCrudAppServiceBase<PersonAddress, PersonAddressDto, Guid>, IPersonAddressCrudAppService
    {
        private readonly IAddressCrudAppService _addressCrudService;

        public PersonAddressCrudAppService(
            [NotNull]IRepository<PersonAddress, Guid> repository, 
            [NotNull]IAddressCrudAppService addressCrudService) : base(repository)
        {
            _addressCrudService = addressCrudService ?? throw new ArgumentNullException(nameof(addressCrudService));
        }

        public override async Task<PersonAddressDto> Get(PersonAddressDto input)
        {
            var dto = await base.Get(input);

            dto.Address = await _addressCrudService.Get(dto.AddressId);

            return dto;
        }

        public override async Task<PersonAddressDto> Get(Guid id)
        {
            return await this.Get(new PersonAddressDto() { Id = id });
        }

        public override async Task<PagedResultDto<PersonAddressDto>> GetAll(PagedAndSortedResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<PersonAddressDto>();

            foreach (var item in result.Items)
            {
                item.Address = await _addressCrudService.Get(item.AddressId);
                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<PersonAddressDto> Create(PersonAddressDto input)
        {
            CheckCreatePermission();

            //Выделяется из данных input часть, которая соответсвует Address
            //и сохраняется с помощью addressCrudService
            var addressDto = await _addressCrudService.Create(input.Address);

            input.AddressId = addressDto.Id;

            var entity = MapToEntity(input);

            await Repository.InsertAsync(entity);
           // await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public override async Task<PersonAddressDto> Update(PersonAddressDto input)
        {
            var personAddressDto = await base.Update(input);
            personAddressDto.Address = await _addressCrudService.Update(input.Address);

            return personAddressDto;
        }

        public override async Task Delete(PersonAddressDto input)
        {
            await base.Delete(input.Id);

            await _addressCrudService.Delete(input.Address.Id);
        }

        public override async Task Delete(Guid id)
        {
            var dto = await base.Get(id);

            if (dto == null)
            {
                throw new Exception("Попытка удалить несуществующую запись");
            }
            await base.Delete(id);

            await _addressCrudService.Delete(dto.AddressId);
        }
    }

}
