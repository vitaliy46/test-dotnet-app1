using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
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
    public class OrganizationUnitMediaCrudAppService : AsyncCrudAppServiceBase<OrganizationUnitMedia, OrganizationUnitMediaDto, Guid, 
                PagedOrganizationUnitMediaResultRequestDto, OrganizationUnitMediaDto,
                OrganizationUnitMediaDto, OrganizationUnitMediaDto, OrganizationUnitMediaDto>, IOrganizationUnitMediaCrudAppService
    {
        private IMediaCrudAppService _mediaCrudAppService;

        public OrganizationUnitMediaCrudAppService(
            [NotNull]IOrganizationUnitMediaRepository repository,
            [NotNull] IMediaCrudAppService mediaCrudAppService) : base(repository)
        {
            _mediaCrudAppService = mediaCrudAppService ?? throw new ArgumentNullException(nameof(mediaCrudAppService));
        }

        public override async Task<OrganizationUnitMediaDto> Create(OrganizationUnitMediaDto input)
        {
            input.Media = await _mediaCrudAppService.Create(input.Media);

            input.MediaId = input.Media.Id;

            var dto = await base.Create(input);

            return dto;
        }

        public override async  Task<PagedResultDto<OrganizationUnitMediaDto>> GetAll(PagedOrganizationUnitMediaResultRequestDto input)
        {
            var result = await base.GetAll(input);

            result.Items.ToList().ForEach(x => x.Media = _mediaCrudAppService.Get(x.MediaId).Result);

            result.Items = result.Items.Where(x => x.Media.Label == input.Label).ToList();

            return result;
        }

        protected override IQueryable<OrganizationUnitMedia> CreateFilteredQuery(PagedOrganizationUnitMediaResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);
            
            return query.Where(x => x.OrganizationUnitId == input.OrganizationId);
        }
      
    }
}
