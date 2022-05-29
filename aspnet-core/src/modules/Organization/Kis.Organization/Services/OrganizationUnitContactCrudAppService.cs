using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Organization.Api.Entity;
using Kis.Organization.Api.Services;

namespace Kis.Organization.Services
{
    public class OrganizationUnitContactCrudAppService : AsyncCrudAppServiceBase<OrganizationUnitContact, OrganizationUnitContactDto, Guid>, IOrganizationUnitContactCrudAppService
    {
        public OrganizationUnitContactCrudAppService([NotNull]IRepository<OrganizationUnitContact, Guid> repository) : base(repository)
        {
        }
    }
}
