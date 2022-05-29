using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Organization.Api.Entity
{
    /// <summary>
    /// Организационная единица.
    /// </summary>
    public class OrganizationUnit : EntityBase<Guid>
    {
        /// <summary>
        /// Название подразделения (организации).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Родительская организационная единица, 
        /// чьим структурным подразделением является текущий <see cref="OrganizationUnit"/>. 
        /// Если <see langword="null"/>, то является высшей формой организационной единицы - юр.лицом.
        /// </summary>
        public virtual OrganizationUnit Parent { get; set; }
        public virtual Guid? ParentId { get; set; }

        /// <summary>
        /// Руководитель.
        /// TODO если потребуется для руководителя больше свойств, но можно будет 
        /// выделить в отдельную сущность
        /// </summary>
        public Person Header { get; set; }
        public Guid? HeaderId { get; set; }
        

        public virtual IList<OrganizationUnitContact> Contacts { get; set; }

        /// <summary>
        /// Адреса компании.
        /// </summary>
        public virtual OrganizationUnitAddress OrganizationUnitAddress { get; set; }

        /// <summary>
        /// Чаще всего сканкопии каких либо документов, но не исключается и другое.
        /// Выбор из этих медиа файлов осуществляется по типам
        /// </summary>
        public virtual IList<OrganizationUnitMedia> Medias { get; set; }

        /// <summary>
        /// Бухгалтерские реквизиты
        /// </summary>
        public virtual AccountingDetails AccountingDetails { get; set; }
    }
}
