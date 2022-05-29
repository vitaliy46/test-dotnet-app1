using System;
using System.Collections.Generic;
using System.Text;
using Kis.Base.Entity;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.Crm.Api.Entity
{
    /// <summary>
    /// Платеж по Сделке
    /// </summary>
    public class DealPayment : EntityBase<Guid>
    {
        /// <summary>
        /// привязка Платежа к Сделке
        /// </summary>
        public virtual Deal Deal { get; set; }

        /// <summary>
        /// вид платежа:Приход, Внутренний расход нал., Внутренний расход безнал, Внешний расход.
        /// </summary>
        public virtual DealPaymentForm DealPaymentForm { get; set; }

        /// <summary>
        /// Объем Платежа
        /// </summary>
        public  decimal Amount { get; set; }

        /// <summary>
        /// Дата совершения платежа
        /// </summary>
        public  DateTime Date { get; set; }

        /// <summary>
        /// TODO выпилить после 15.12.2013
        /// Указатель на Задачу по которой был рассчитан внутренний расход. 
        /// Это свойство присуще только для внутреннего расхода.
        /// </summary>
        public virtual Issue Issue { get; set; }

        /// <summary>
        /// Указатель на комментарий по которому был рассчитан внутренний расход. 
        /// Это свойство присуще только для внутреннего расхода.
        /// </summary>
        public  IssueComment IssueComment { get; set; }
        public Guid IssueCommentId { get; set; }

        public  DateTime? Sent { get; set; }
    }
}
