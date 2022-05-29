using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.Organization.Api.Entity;


namespace Kis.Crm.Api.Entity
{
    public class Client : EntityBase<Guid>
    {
        public OrganizationUnit Organization { get; set; }
        public Guid OrganizationId { get; set; }

        //<summary>
        //Сфера деятельности
        //</summary>
        public virtual Industry Industry { get; set; }

        /// <summary>
        /// Все сделки с склиентом
        /// </summary>
        public virtual IList<Deal> Deals { get; set; }


        public  ushort CountOpenDeals { get; set; }

        /// <summary>
        /// Сотрудники, которые контактируют в сделках
        /// </summary>
        public virtual IList<Contactor> Contactors { get; set; }

    }
}
