using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.General.Api.Entity;


namespace Kis.Crm.Api.Entity
{
    /// <summary>
    /// Контактное лицо со стороны клиента, котрое заключает сделку
    /// Контактные лица со стороны клиента по сделке не обязательно будут сотрудниками
    /// клиента. Это могут быть любые люди
    /// </summary>
    public class Contactor : EntityBase<Guid>
    {
        public  Person Person { get; set; }
        public Guid PersonId { get; set; }

        public virtual IList<BusinessContact> BusinessContacts { get; set; }

        public virtual  Client Client { get; set; }

        public virtual IList<Deal> Deals { get; set; }
    }

    
}
