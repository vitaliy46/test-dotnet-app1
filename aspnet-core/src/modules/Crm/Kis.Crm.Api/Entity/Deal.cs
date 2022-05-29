using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.Core.Authorization.Users;
using Kis.General.Api.Entity;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.Crm.Api.Entity
{
    /// <summary>
    /// Сделка с клиентом, на основе которй возникает проект
    /// </summary>
    public class Deal : EntityBase<Guid>
    {
        /// <summary>
        /// Заголовок проекта
        /// </summary>
        public string Title { get; set; }

        public virtual DealState State { get; set; }

        public Project Project { get; set; }
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Сотрудник Компании продавший Сделку
        /// </summary>
        public User Dealer { get; set; }
        public Guid DealerId { get; set; }

        /// <summary>
        /// Бюджет сделки
        /// </summary>
        public decimal Budget { get; set; }

        /// <summary>
        /// Клиент заключивший сделку
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Контактное лицо со стороны Клиента заключившего сделку
        /// </summary>
        public virtual Contactor Contactor { get; set; }
       
        /// <summary>
        /// Дата подачи заявки на сделку
        /// </summary>
        public virtual DateTime? OrderDate { get; set; }

        /// <summary>
        /// Дата завершения сделки (на форме - "Сделка решена")
        /// </summary>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Дата предварительной проверки готовности проекта планируемая
        /// </summary>
        public virtual DateTime? Redline { get; set; }

        /// <summary>
        /// Дата сдачи проекта планируемая
        /// </summary>
        public virtual DateTime? Deadline { get; set; }

        // <summary>
        /// Проектная группа пользователей по сделке.
        /// </summary>
        public IList<User> Members { get; set; }

        /// <summary>
        /// Платежи по Сделке
        /// </summary>
        public virtual IList<DealPayment> Payments { get; set; }

        /// <summary>
        /// События произошедшие по Сделке.
        /// </summary>
        //public virtual IList<DealEvent> Events { get; set; }

        /// <summary>
        /// Файлы связанные со Сделкой.
        /// </summary>
        public virtual IList<DealMedia> Medias { get; set; }

        /// <summary>
        /// Статьи расходов по рассчету продажи Сделки.
        /// </summary>
        //public virtual IList<DealCalculation> Calculations { get; set; }
    }
}
