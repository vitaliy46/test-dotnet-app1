using System;
using System.Collections.Generic;
using System.Text;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Crm.Api.Entity
{
    /// <summary>
    /// Контактные данные персоны, причастные к конкретной бизнес тематике
    /// В данном случае эти контакты причастны к сделкам
    /// </summary>
    public class BusinessContact : EntityBase<Guid>
    {
        public virtual Contactor Contactor { get; set; }
        public Guid ContactorId { get; set; }

        public Contact Contact { get; set; }
        public Guid ContactId { get; set; }
    }
}
