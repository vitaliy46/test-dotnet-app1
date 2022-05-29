using System;
using System.Collections.Generic;
using Kis.Base.Entity;

namespace Kis.Inventory.Api.Entity
{
    public class Inventory : EntityBase<Guid>
    {
        public  string Name { get; set; }

        /// <summary>
        /// Составные ТМЦ
        /// </summary>
        private IList<Inventory> Inventories;

        public ReceiptOrder ReceiptOrder { get; set; }
    }
}
