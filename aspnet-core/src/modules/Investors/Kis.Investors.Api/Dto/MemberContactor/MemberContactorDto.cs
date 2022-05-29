using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Person;
using Kis.Users.Dto;

namespace Kis.Investors.Api.Dto
{
    /// <summary>
    /// Представитель члена товарищества, с которым осуществляется контакт
    /// </summary>
    public class MemberContactorDto : BaseDto<Guid>
    {
        public PersonDto Person { get; set; }
        public Guid PersonId { get; set; }

        /// <summary>
        /// Контакт, по кторому система будет производить оповещение контактных лиц
        /// </summary>
        public PersonContactDto PersonContact { get; set; }
        public Guid PersonContactId { get; set; }

        /// <summary>
        /// Указывает на члена товарищества к которому относится контактное лицо
        /// </summary>
        public Guid PartnershipMemberId { get; set; }
    }
}
