using System;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    public class IssueStateDto : BaseDto<Guid>
    {
        public Guid IssueId { get; set; }

        public Guid StateId { get; set; }
    }
}
