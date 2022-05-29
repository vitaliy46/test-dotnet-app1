using System;
using System.Collections.Generic;
using Abp.Runtime.Validation;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto.PersonUser;

namespace Kis.General.Api.Dto.Person
{
    /// <summary>
    /// Персона - физическое лицо
    /// </summary>
    public class CreatePersonDto : IShouldNormalize
    {
        public string FullName { get; set; }
  
        /// <summary>
        /// Всевозможные контакты: email, тел., факс, skype и др.
        /// </summary>
        public IList<CreatePersonContactDto> Contacts { get; set; }

        /// <summary>
        /// Связь меджу перcоной и его учетной записью
        /// </summary>
        public  CreatePersonUserDto PersonUser { get; set; }

        public void Normalize()
        {
        }
    }

}
