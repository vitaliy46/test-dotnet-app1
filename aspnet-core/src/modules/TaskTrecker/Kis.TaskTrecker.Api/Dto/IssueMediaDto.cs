using System;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    public class IssueMediaDto : BaseDto<Guid>
    {
       public Guid MediaId { get; set; }

        public Guid IssueId { get; set; }
    }
}
