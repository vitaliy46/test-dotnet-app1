using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Crm.Api.Entity
{
    /// <summary>
    /// Вид платежа:
    /// Приход, Внутренний расход нал., Внутренний расход безнал, Внешний расход.
    /// </summary>
    public class DealPaymentForm : EntityBase<Guid>
    {
        public string  Neme { get; set; }

       }
}
