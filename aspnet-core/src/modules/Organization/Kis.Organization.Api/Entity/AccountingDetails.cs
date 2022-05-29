using System;
using System.Collections.Generic;
using System.Text;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Organization.Api.Entity
{
    /// <summary>
    /// Банковские реквизиты организации
    /// </summary>
    public class AccountingDetails : EntityBase<Guid>
    {
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// ОГРН
        /// </summary>
        public string Ogrn { get; set; }
    }
}
