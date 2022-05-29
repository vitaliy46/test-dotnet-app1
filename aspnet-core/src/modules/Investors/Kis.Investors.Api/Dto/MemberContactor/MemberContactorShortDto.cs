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
    public class MemberContactorShortDto : BaseDto<Guid>
    {
        public PersonDto Person { get; set; }

        /// <summary>
        /// Контакт, по кторому система будет производить оповещение контактных лиц
        /// </summary>
        public PersonContactDto PersonContact { get; set; }

        /// <summary>
        /// Указывает на члена товарищества к которому относится контактное лицо
        /// </summary>
        public Guid PartnershipMemberId { get; set; }
    }
}
