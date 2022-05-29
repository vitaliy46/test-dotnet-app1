using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dal.Repositories;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.General.Api.Services.Crud;
using Kis.Organization.Api.Dao.Repositories;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Entity;
using Kis.Organization.Api.Services;

namespace Kis.Organization.Services
{
    public class OrganizationUnitCrudAppService : AsyncCrudAppServiceBase<OrganizationUnit, OrganizationUnitDto, Guid>, IOrganizationUnitCrudAppService
    {
        private readonly IPersonRepository personRepository;
        private readonly IPersonCrudAppService _personCrudAppService;
        private readonly IOrganizationUnitAddressCrudAppService _organizationUnitAddressCrudAppService;

        public OrganizationUnitCrudAppService(
            [NotNull]IOrganizationUnitRepository repository,
            IPersonRepository personRepository,
            IPersonCrudAppService personCrudAppService,
            [NotNull] IOrganizationUnitAddressCrudAppService organizationUnitAddressCrudAppService) : base(repository)
        {
            this.personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            this._personCrudAppService = personCrudAppService ?? throw new ArgumentNullException(nameof(personCrudAppService));
            _organizationUnitAddressCrudAppService = organizationUnitAddressCrudAppService ?? throw new ArgumentNullException(nameof(organizationUnitAddressCrudAppService));
        }

        public override async Task<OrganizationUnitDto> Get(Guid id)
        {
            var dto = await base.Get(id);

            if (dto.HeaderId != null)
            {
                dto.Header = await _personCrudAppService.Get((Guid) dto.HeaderId);
            }

            if (dto.OrganizationUnitAddress != null)
            {
                dto.OrganizationUnitAddress =
                    await _organizationUnitAddressCrudAppService.Get(dto.OrganizationUnitAddress.Id);
            }

            return dto;
        }

        /// <summary>
        /// Добавляет новую организационную единицу и добавляет нового руководителя,
        /// если он указан
        /// </summary>
        public override async Task<OrganizationUnitDto> Create(OrganizationUnitDto input)
        {
            PersonDto headerDto = null;
             
            if (input.Header != null )
            {
                headerDto = await _personCrudAppService.Create(input.Header);
                input.HeaderId = headerDto.Id;
            }

            var output = await base.Create(input);

            if (input.OrganizationUnitAddress != null)
            {
                input.OrganizationUnitAddress.OrganizationUnitId = output.Id;

                output.OrganizationUnitAddress =
                    await _organizationUnitAddressCrudAppService.Create(input.OrganizationUnitAddress);
            }

            output.Header = headerDto;

            return output;
        }

        /// <summary>
        /// Обновляет организационную единицу по её id и обновляет руководителя,
        /// если он указан
        /// (работа с несколькими контекстами)
        /// </summary>
        public override async Task<OrganizationUnitDto> Update(OrganizationUnitDto input)
        {
            OrganizationUnitAddressDto address = null;
            if (input.OrganizationUnitAddress != null)
            {
                input.OrganizationUnitAddress.OrganizationUnitId = input.Id;
                address =
                    await _organizationUnitAddressCrudAppService.Update(input.OrganizationUnitAddress);
            }

            var output = await base.Update(input);

            if (input.Header != null)
            {
                output.Header = await _personCrudAppService.Update(input.Header);
            }
            output.OrganizationUnitAddress = address;

            return output;
        }
    }
}
