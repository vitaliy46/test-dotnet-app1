using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Отчет по результатам голосования голосованании
    /// Отчет формируется только на основании VoteReport
    /// </summary>
    public class VoteReport : EntityBase<Guid>
    {
        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }

        /// <summary>
        /// Ссылка на документ с отчетом
        /// </summary>
        public VoteReportMedia ReportFile { get; set; }
        public Guid? ReportFileId { get; set; }

        /// <summary>
        /// Любые медийные материалы для отчета. Это могут быть графики для наглядности.
        /// </summary>
        public virtual IList<VoteReportMedia> Medias { get; set; }
    }
}
