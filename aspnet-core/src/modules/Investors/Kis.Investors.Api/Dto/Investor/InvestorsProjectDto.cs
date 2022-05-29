using System;
using Kis.Base.Dto;

namespace Kis.Investors.Api.Dto
{
    public class InvestorsProjectDto : BaseDto<Guid>
    {
        public string InvestedProjectName { get; set; }
        public Guid InvestedProjectId { get; set; }

        /// <summary>
        /// Сканкопия ИНН
        /// </summary>
        public Guid? OrganizationUnitMediaId { get; set; }
        
        /// <summary>
        /// Доля в инвестируемом проекте
        /// </summary>
        public double InvestmentShare { get; set; }
    }
}
