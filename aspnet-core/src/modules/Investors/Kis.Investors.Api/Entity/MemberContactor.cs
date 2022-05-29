using System;
using Kis.Authorization.Users;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Investors.Api.Entity
{
    /// <summary>
    /// Представитель члена товарищества, с которым осуществляется контакт
    /// </summary>
    public class MemberContactor  : EntityBase<Guid>
    {
        public Person Person { get; set; }
        public Guid PersonId { get; set; }

        /// <summary>
        /// Контакт, по кторому система будет производить оповещение контактных лиц
        /// </summary>
        public PersonContact PersonContact { get; set; }
        public Guid PersonContactId { get; set; }

        /// <summary>
        /// Указывает на члена товарищества к которому относится контактное лицо
        /// </summary>
        public virtual PartnershipMember PartnershipMember { get; set; }
        public Guid  PartnershipMemberId { get; set; }
    }
}
