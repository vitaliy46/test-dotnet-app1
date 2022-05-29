using System;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Api.Services
{
    public interface IOrganizationUnitContactCrudAppService : IAsyncCrudAppService<OrganizationUnitContactDto, Guid>
    {
    }
}
