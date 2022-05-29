using System;
using Abp.Application.Services.Dto;

namespace Kis.General.Api.Dto.Comment
{
    public class PagedOneTimePasswordResultRequestDto : PagedResultRequestDto
    {
        public Guid? Id { get; set; }
        public long? UserId { get; set; }
        public bool? Confirmed { get; set; }
    }
}
