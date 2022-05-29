using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Organization.Api.Dto
{
    /// <summary>
    /// Адрес структурного подразделения
    /// </summary>
    public class OrganizationUnitAddressDto : BaseDto<Guid>
    {
        /// <summary>
        /// Адрес.
        /// </summary>
        public AddressDto Address { get; set; }
        public Guid AddressId { get; set; }

        /// <summary>
        /// Организационная единица.
        /// </summary>
        public Guid OrganizationUnitId { get; set; }
    }
}
