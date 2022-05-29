using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.Users.Dto;

namespace Kis.Investors.Api.Dto
{
    /// <summary>
    /// Представитель члена товарищества, с которым осуществляется контакт
    /// </summary>
    public class UpdateMemberContactorDto : IShouldNormalize
    {
        public UpdatePersonDto Person { get; set; }

        /// <summary>
        /// Контакт, по которому система будет производить оповещение контактных лиц
        /// </summary>
        public UpdateContactDto Mail { get; set; }

        public void Normalize()
        {
        }
    }
}
