using System;
using System.Collections.Generic;
using Kis.Base.Entity;

namespace Kis.Inventory.Api.Entity
{
    public class Product : EntityBase<Guid>
    {
        public string Name { get; set; }

        /**
         * Кол-во
         */
        public ulong Amount { get; set; }

        /**
         * Цена.
         */

        public decimal Price { get; set; }

        /**
         * Ставка НДС.
         */

        public Single Nds { get; set; }

        /**
         * Признак основного средства.
         * true - основное средство.
         * false - малоценное.
         */
        public bool Expensive { get; set; }

        /**
         * Категория продукта из каталога.
         */
        public ProductCategory Category { get; set; }
    }
}
