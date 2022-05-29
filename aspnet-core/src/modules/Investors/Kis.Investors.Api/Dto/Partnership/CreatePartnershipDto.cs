using System;
using System.Collections.Generic;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;

namespace Kis.Investors.Api.Dto
{
    public class CreatePartnershipDto : IShouldNormalize
    {
        public string OrganizationName { get; set; }

        public  Guid ManagerId { get; set; }

        public void Normalize()
        {
        }
    }
}
