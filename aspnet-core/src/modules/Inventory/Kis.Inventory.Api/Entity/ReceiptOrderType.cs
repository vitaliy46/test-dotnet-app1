
using System;
using System.Collections.Generic;
using Kis.Base.Entity;

namespace Kis.Inventory.Api.Entity
{
    /// <summary>
    /// Тип приходного ордера.
    /// </summary>
    public class ReceiptOrderType : EntityBase<Guid>
    {
        public String Name { get; set; }
    }
}
