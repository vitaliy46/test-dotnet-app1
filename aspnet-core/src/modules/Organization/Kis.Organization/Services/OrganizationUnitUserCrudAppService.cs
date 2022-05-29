using Abp.Domain.Repositories;
using Hangfire.Annotations;
using Kis.Base.Services.Bl;
using Kis.Organization.Api.Entity;
using Kis.Organization.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kis.Organization.Services
{
    class OrganizationUnitUserCrudAppService : AsyncCrudAppServiceBase<OrganizationUnitUser, OrganizationUnitUserDto, Guid?>, IOrganizationUnitUserCrudAppService
    {
        public OrganizationUnitUserCrudAppService([NotNull]IRepository<OrganizationUnitUser, Guid?> repository) : base(repository)
        {
        }
    }
}
