using System;
using Kis.Base.Dto;

namespace Kis.Investors.Api.Dto
{
    public class InvestorDto : BaseDto<Guid>
    {
        /// <summary>
        /// Член товарищества
        /// </summary>
        public PartnershipMemberDto Member { get; set; }
        public Guid MemberId { get; set; }

        /// <summary>
        /// Проект в котором учавствует инвестор своими ресурсами 
        /// </summary>
        public InvestedProjectDto Project { get; set; }
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Доля в инвестируемом проекте
        /// </summary>
        public double InvestmentShare { get; set; }
    }
}
