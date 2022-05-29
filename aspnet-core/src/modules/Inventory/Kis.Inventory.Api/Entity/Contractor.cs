using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.Organization.Api.Entity;
using Kis.Staff.Api.Entity;

namespace Kis.Inventory.Api.Entity
{
    public class Contractor : OrganizationUnit
    {
        /// <summary>
        /// Дата начала действия.
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// Дата окончаний действия.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Сотрудники, которые контактируют по поставкам
        /// </summary>
        public virtual IList<Contactor> Contactors { get; set; }
        
        /// <summary>
        /// Все приходные ордера с склиентом
        /// </summary>
        public virtual IList<ReceiptOrder> ReceiptOrders { get; set; }
    }
}
