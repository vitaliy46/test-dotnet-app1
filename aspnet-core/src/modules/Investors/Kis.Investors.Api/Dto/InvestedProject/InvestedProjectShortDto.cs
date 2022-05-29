using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;
using Kis.TaskTrecker.Api.Dto;

namespace Kis.Investors.Api.Dto
{
    public class InvestedProjectShortDto : BaseDto<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string StateName { get; set; }
    }
}
