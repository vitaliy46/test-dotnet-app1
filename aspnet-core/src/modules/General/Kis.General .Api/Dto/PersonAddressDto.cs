using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Персона - физическое лицо
    /// </summary>
    public class PersonAddressDto : BaseDto<Guid>
    {
        public Guid PersonId { get; set; }

        public AddressDto Address { get; set; }
        public Guid AddressId { get; set; }
    }

}
