using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Organization.Api.Dto
{
    /// <summary>
    /// Адрес структурного подразделения
    /// </summary>
    public class CreateOrganizationUnitAddressDto : IShouldNormalize
    {
        /// <summary>
        /// Адрес.
        /// </summary>
        public CreateAddressDto Address { get; set; }

        public void Normalize()
        {
        }
    }
}
