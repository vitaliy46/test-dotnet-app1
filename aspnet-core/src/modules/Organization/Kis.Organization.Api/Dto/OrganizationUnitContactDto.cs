using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Organization.Api.Entity
{
    /// <summary>
    /// Сонтактные данные структурного подразделения
    /// </summary>
    public class OrganizationUnitContactDto : BaseDto<Guid>
    {
        public Guid OrganizationUnitId { get; set; }

        public ContactDto Contact { get; set; }
        public Guid ContactId { get; set; }
    }
}
