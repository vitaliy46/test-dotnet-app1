using System;
using Abp.Application.Services.Dto;
using Kis.Base.Dto;

namespace Kis.Investors.Api.Dto
{
    public class PagedInvestorRequestDto : PagedResultRequestDto
    {
        public Guid? PartnershipMemberId { get; set; }

        public Guid? InvestedProjectId { get; set; }

        public bool? OrderByProjectNameDecending { get; set; }
    }

}
