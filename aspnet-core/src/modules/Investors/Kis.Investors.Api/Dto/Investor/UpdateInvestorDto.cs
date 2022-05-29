using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;

namespace Kis.Investors.Api.Dto
{
    public class UpdateInvestorDto : IShouldNormalize
    {
        /// <summary>
        /// Доля в инвестируемом проекте
        /// </summary>
        public double InvestmentShare { get; set; }

        public void Normalize()
        {
        }
    }
}
