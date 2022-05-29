using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.General.Api.Entity;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Отчет по результатам голосования голосованании
    /// </summary>
    public class VoteReportDto : BaseDto<Guid>
    {
        public Guid VoteId { get; set; }

        /// <summary>
        /// Ссылка на документ с отчетом
        /// </summary>
        public VoteReportMediaDto ReportFile { get; set; }
        public Guid ReportFileId { get; set; }

        /// <summary>
        /// Xml документ установленного формата для предоставления результатов голососвания/
        /// Этот документ подписан эл. подписью.
        /// </summary>
        //public string ResultXml { get; set; }

        /// <summary>
        /// Любые медийные материалы для отчета. Это могут быть графики для наглядности.
        /// </summary>
        public IList<VoteReportMediaDto> Medias { get; set; }
    }
}
