using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;
using Kis.TaskTrecker.Api.Dto;

namespace Kis.Investors.Api.Dto
{
    public class PlaneInvestedProjectDto : BaseDto<Guid>
    {
        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }

        public Guid ManagingCompanyId { get; set; }

        public string CompanyName { get; set; }

        public string Inn { get; set; }

        public string Ogrn { get; set; }

        public string Address { get; set; }

        public string HeaderFio { get; set; }

        public string Phone { get; set; }
        public Guid PhoneId { get; set; }

        public string Mail { get; set; }
        public Guid MailId { get; set; }

        public Guid ProjectStateId { get; set; }

    }
}
