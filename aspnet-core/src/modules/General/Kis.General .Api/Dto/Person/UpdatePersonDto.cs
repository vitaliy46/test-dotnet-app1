using System;
using System.Collections.Generic;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto.PersonUser;

namespace Kis.General.Api.Dto.Person
{
    /// <summary>
    /// Персона - физическое лицо
    /// </summary>
    public class UpdatePersonDto : IShouldNormalize
    {
        public string FullName { get; set; }

        public void Normalize()
        {
        }
    }

}
