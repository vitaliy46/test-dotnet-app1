using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;

namespace Kis.Investors.Api.Dto
{
    public class CreateInvestorDto : IShouldNormalize
    {
        /// <summary>
        /// Член товарищества
        /// </summary>
        public Guid MemberId { get; set; }

        /// <summary>
        /// Проект в котором учавствует инвестор своими ресурсами 
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Доля в инвестируемом проекте
        /// </summary>
        public double InvestmentShare { get; set; }

        public void Normalize()
        {
        }
    }
}
