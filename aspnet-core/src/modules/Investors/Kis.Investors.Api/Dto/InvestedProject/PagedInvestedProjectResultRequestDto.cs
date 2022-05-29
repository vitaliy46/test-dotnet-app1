using System;
using Abp.Application.Services.Dto;

namespace Kis.General.Api.Dto.Comment
{
    public class PagedInvestedProjectResultRequestDto : PagedResultRequestDto
    {
       public Guid? PartnershipMemberId { get; set; }
    }
}
