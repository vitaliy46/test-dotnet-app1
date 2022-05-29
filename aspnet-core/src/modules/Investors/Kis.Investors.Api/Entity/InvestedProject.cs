using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.Organization.Api.Entity;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.Investors.Api.Entity
{
    /// <summary>
    /// Инвестируемый проект
    /// </summary>
    public class InvestedProject : EntityBase<Guid>
    {
        /// <summary>
        /// Инвестируемый проект
        /// </summary>
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Управляющая компания по реализации проекта
        /// </summary>
        public OrganizationUnit ManagingCompany { get; set; }
        public Guid ManagingCompanyId { get; set; }

        /// <summary>
        /// Состав инвесторов, котрые вкладывают средства, ресурсы (не обязательно финансовые) в проект
        /// </summary>
        public virtual IList<Investor> Investors { get; set; }


    }
}
