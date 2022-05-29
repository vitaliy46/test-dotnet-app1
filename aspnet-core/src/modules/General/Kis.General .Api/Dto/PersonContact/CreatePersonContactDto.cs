using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Персона - физическое лицо
    /// </summary>
    public class CreatePersonContactDto : IShouldNormalize
    {
        public CreateContactDto Contact { get; set; }

        public void Normalize()
        {
        }
    }

}
