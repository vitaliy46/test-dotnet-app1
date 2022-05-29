using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Персона - физическое лицо
    /// </summary>
    public class PersonContactDto : BaseDto<Guid>
    {
        public Guid PersonId { get; set; }

        public ContactDto Contact { get; set; }
        public Guid ContactId { get; set; }
    }

}
