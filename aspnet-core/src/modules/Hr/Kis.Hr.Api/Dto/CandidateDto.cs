using System;
using System.Collections.Generic;
using Abp.AutoMapper;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Organization.Api.Entity;

namespace Kis.Hr.Api.Dto
{
    /// <summary>
    /// Представляет кандидата на рабочее место.
    /// </summary>
    [AutoMapTo(typeof(Candidate))]
    public class CandidateDto : BaseDto<Guid>
    {
        /// <summary>
        /// Физическое лицо, представляющее кандидата.
        /// </summary>
        public PersonDto Person { get; set; }

        /// <summary>
        /// Вакансия на которую претендует кандидат.
        /// </summary>
        public VacancyDto Vacancy { get; set; }

        /// <summary>
        /// Источник поступления информации о кандидате.
        /// </summary>
        public InformationSourceDto InformationSource { get; set; }

        /// <summary>
        /// Структурное подразделение, для которого подбирается кандидат.
        /// </summary>
        public OrganizationUnit OrganizationUnit { get; set; }

        /// <summary>
        /// Состояния, в которых пребывал кандидат.
        /// </summary>
        public IList<CandidateStateDto> States { get; set; }

        /// <summary>
        /// Прикрепленные медиа файлы.
        /// </summary>
        public IList<CandidateMediaDto> MediaFiles { get; set; }

        /// <summary>
        /// Ссылки на внешние интернет ресурсы.
        /// </summary>
        public IList<CandidateLinkDto> Links { get; set; }

        /// <summary>
        /// Комментарии оставленные о кандидате.
        /// </summary>
        public IList<CandidateCommentDto> Comments { get; set; }

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
    }
}
