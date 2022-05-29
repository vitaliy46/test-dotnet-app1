using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.General.Api.Entity;
using Kis.Organization.Api.Entity;

namespace Kis.Hr.Api.Entity
{
    /// <summary>
    /// Кандидат на рабочее место.
    /// </summary>
    public class Candidate : EntityBase<Guid>
    {
        /// <summary>
        /// Физическое лицо, представляющее кандидата.
        /// </summary>
        public Person Person { get; set; }
        public Guid PersonId { get; set; }

        /// <summary>
        /// Вакансия, на котороую пертендует кандидат.
        /// </summary>
        public virtual Vacancy Vacancy { get; set; }
        public Guid VacancyId { get; set; }

        /// <summary>
        /// Источник поступления информации о кандидате.
        /// </summary>
        public virtual InfomationSource InfomationSource { get; set; }
        public Guid InfomationSourceId { get; set; }

        /// <summary>
        /// Структурное подразделение, для которого подбирается кандидат.
        /// Руководителям этих структурных подразделений проще будет фильтровать
        /// и работать со своими кандидатами.
        /// </summary>
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }

        /// <summary>
        /// Состояния, в котором находится кандидат.
        /// </summary>
        public virtual CandidateState State { get; set; }
        public virtual Guid StateId { get; set; }

        public virtual IList<CandidateContact> Contacts { get; set; }

        /// <summary>
        /// Прикрепленные медиа файлы.
        /// </summary>
        public virtual IList<CandidateMedia> MediaFiles { get; set; }

        /// <summary>
        /// Ссылки на внешние интернет ресурсы.
        /// </summary>
        public virtual IList<CandidateLink> Links { get; set; }

        /// <summary>
        /// Комментарии оставленные о кандидате.
        /// </summary>
        public virtual IList<CandidateComment> Comments { get; set; }

        /// <summary>
        /// Желаемая должность.
        /// </summary>
        public string DesiredPosition { get; set; }

        /// <summary>
        /// Окончательная должность предложенная кандидату и согласованная с ним.
        /// </summary>
        public string FinalPosition { get; set; }

        /// <summary>
        /// Желаемая зарплата.
        /// </summary>
        public decimal DesiredSalary { get; set; }

        /// <summary>
        /// Зарплата на испытательном сроке.
        /// </summary>
        public decimal ProbationSalary { get; set; }

        /// <summary>
        /// Окончательная зарплата (после испытательного срока).
        /// </summary>
        public decimal FinalSalary { get; set; }
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата появления кандидата.
        /// </summary>
        public DateTime AppearingDate { get; set; }

        /// <summary>
        /// Идентификатор внешней системы
        /// из которой получены сведения о кандидате.
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Резюме.
        /// TODO временно отключено
        /// </summary>
        // public virtual CandidateMedia Resume { get; set; }

        /// <summary>
        /// Тесты.
        /// </summary>
        // TODO: тесты должны содержать ссылку на сами тесты и результат прохождения
        // public virtual IList<Media> Tests { get; set; }
    }
}
