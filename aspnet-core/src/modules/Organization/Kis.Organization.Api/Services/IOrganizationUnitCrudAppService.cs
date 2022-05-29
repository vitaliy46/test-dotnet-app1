using System;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.Organization.Api.Dto;

namespace Kis.Organization.Api.Services
{
    /// <summary>
    /// Представляет сервис crud-операций для организационной единицы.
    /// </summary>
    public interface IOrganizationUnitCrudAppService : IAsyncCrudAppService<OrganizationUnitDto, Guid>
    {
    }
}
