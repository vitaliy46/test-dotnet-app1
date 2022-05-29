using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Entity;

namespace Kis.Investors.Api.Dto
{
    /// <summary>
    /// Член инвестиционного товарищества
    /// </summary>
    public class CreatePartnershipMemberDto : IShouldNormalize
    {
        public string Name { get; set; }

        public string Inn { get; set; }

        public string Ogrn { get; set; }

        public string Address { get; set; }

        public string HeaderFio { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public string Login { get; set; }

        public string ContactorFio { get; set; }

        public bool IsAllowSmsNotification { get; set; }
        public void Normalize()
        {
        }
    }
}
