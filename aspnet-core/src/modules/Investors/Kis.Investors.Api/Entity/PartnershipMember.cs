using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.Organization.Api.Entity;

namespace Kis.Investors.Api.Entity
{
    /// <summary>
    /// Член инвестиционного товарищества
    /// </summary>
    public class PartnershipMember : EntityBase<Guid>
    {

        public OrganizationUnit Organization { get; set; }
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Контактное лицо члена товарищества
        /// </summary>
        public virtual MemberContactor Contactor { get; set; }

        /// <summary>
        /// Разрешение уведомлений по Sms
        /// </summary>
        public bool IsAllowSmsNotification { get; set; }

        /// <summary>
        /// Список участий в инвестированиях каких либо проектов
        /// </summary>
        public virtual  IList<Investor> Investors { get; set; }
    }
}
