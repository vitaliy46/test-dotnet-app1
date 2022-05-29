using System;
using System.Collections.Generic;
using Kis.Base.Entity;

namespace Kis.Inventory.Api.Entity
{
    public class ReceiptOrder : EntityBase<Guid>
    {
       
        /**
         * Список ТМЦ входящих в состав ордера
         */
       public  IList<Product> Products { get; set; }

        /**
         * Дата расходника на основе которого составлен приходник
         */
        public DateTime ExpenseDocumentDate { get; set; }

        /**
         * Номер расходника
         */
        public String ExpenseDocumentNumber { get; set; }

        /**
         * Организация поставщик
         */
        public Contractor ExpenseOrganization { get; set; }

        /**
         * Сущность-справочник с типом ордера.
         */

        public ReceiptOrderType OrderType { get; set; }
    }
}
