using System;
using Kis.Base.Dto;

namespace Kis.Investors.Api.Dto
{
    public class InvestorForProjectDto : BaseDto<Guid>
    {
        /// <summary>
        /// Наименование организации члена товарищества
        /// </summary>
        public string MemberName { get; set; }
        public Guid MemberId { get; set; }

        /// <summary>
        /// ФИО директора организации члена товарищества
        /// </summary>
        public string HeaderFullName { get; set; }
        
        /// <summary>
        /// Доля в инвестируемом проекте
        /// </summary>
        public double InvestmentShare { get; set; }
    }
}
