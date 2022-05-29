using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Entity;
using Kis.Investors.Api.Services;
using Kis.Organization.Api.Services;

namespace Kis.Investors.Service.Crud
 {
    public class PartnershipCrudAppService : AsyncCrudAppServiceBase<Partnership, PartnershipDto, Guid>, IPartnershipCrudAppService
    {
        private readonly IOrganizationUnitCrudAppService _organizationUnitCrudApp;
        public PartnershipCrudAppService([NotNull] IPartnershipRepository partnershipRepository,
            [NotNull] IOrganizationUnitCrudAppService organizationUnitCrudApp) : base(
            partnershipRepository)
        {
            _organizationUnitCrudApp = organizationUnitCrudApp ?? throw new ArgumentNullException(nameof(organizationUnitCrudApp));
        }

        public override async Task<PartnershipDto> Get(Guid id)
        {
            var dto = await base.Get(id);

            dto.Organization = await _organizationUnitCrudApp.Get(dto.OrganizationId);

            return dto;
        }

        public override async Task<PartnershipDto> Update(PartnershipDto input)
        {
            var dto = await base.Update(input);

            dto.Organization = await _organizationUnitCrudApp.Update(dto.Organization);

            return dto;
        }
    }

}
