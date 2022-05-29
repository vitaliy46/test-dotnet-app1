using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.Organization.Api.Entity;

namespace Kis.Investors.Api.Entity
{
    /// <summary>
    /// Инвестиционное товарищество
    /// </summary>
    public class Partnership : EntityBase<Guid>
    {
        /// <summary>
        /// Организация, 
        /// </summary>
        public OrganizationUnit Organization { get; set; }
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Управляющая компания из состава членов товарищества
        /// </summary>
        public virtual PartnershipMember Manager { get; set; }
        public Guid? ManagerId { get; set; }

        /// <summary>
        /// Члены товарищества, котрые вкладывают средства, ресурсы (не обязательно финансовые) в проект
        /// </summary>
        public virtual IList<PartnershipMember> Members { get; set; }

        /// <summary>
        /// Проекты, которые курирует товарищество
        /// </summary>
        public virtual IList<InvestedProject> Projects { get; set; }

    }
}
