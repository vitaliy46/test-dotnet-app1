using System;
using Kis.Base.Dto;

namespace Kis.Hr.Api.Dto
{
    public class VacancyDto : BaseDto<Guid>
    {
        public string Description { get; set; }
    }
}
