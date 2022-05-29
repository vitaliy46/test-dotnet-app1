using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Материалы для отчета по голосованию
    /// </summary>
    public class VoteReportMediaDto : BaseDto<Guid>
    {
        public Guid VoteReportId { get; set; }

        public MediaDto Media { get; set; }
        public Guid MediaId { get; set; }
    }
}
