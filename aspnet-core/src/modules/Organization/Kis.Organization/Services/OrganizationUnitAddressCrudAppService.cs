using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Entity;
using Kis.Organization.Api.Services;

namespace Kis.Organization.Services
{
    public class OrganizationUnitAddressCrudAppService : AsyncCrudAppServiceBase<OrganizationUnitAddress, OrganizationUnitAddressDto, Guid>, IOrganizationUnitAddressCrudAppService
    {
        private readonly IAddressCrudAppService _addressCrudService;
        public OrganizationUnitAddressCrudAppService([NotNull]IRepository<OrganizationUnitAddress, Guid> repository,
            IAddressCrudAppService addressCrudService) : base(repository)
        {
            _addressCrudService = addressCrudService ?? throw new ArgumentNullException(nameof(addressCrudService));
        }

        public override async Task<OrganizationUnitAddressDto> Create(OrganizationUnitAddressDto input)
        {
            var address = await _addressCrudService.Create(input.Address);

            input.AddressId = address.Id;

            var dto = await base.Create(input);

            dto.Address = address;

            return dto;
        }

        public override async Task<OrganizationUnitAddressDto> Get(OrganizationUnitAddressDto input)
        {
            var dto = await base.Get(input);

            dto.Address = await _addressCrudService.Get(dto.AddressId);

            return dto;
        }

        public override async Task<OrganizationUnitAddressDto> Update(OrganizationUnitAddressDto input)
        {
            var organizationUnitAddressDto = await base.Update(input);

            organizationUnitAddressDto.Address = await _addressCrudService.Update(input.Address);

            return organizationUnitAddressDto;
        }

        public override Task<OrganizationUnitAddressDto> Get(Guid id)
        {
            return this.Get(new OrganizationUnitAddressDto {Id=id});
        }
    }
}
