using System;
using Abp.Runtime.Validation;

namespace Kis.Investors.Api.Dto.InvestedProject
{
    public class PlaneCreateInvestedProjectDto : IShouldNormalize
    {
        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }

        public string CompanyName { get; set; }

        public string Inn { get; set; }

        public string Ogrn { get; set; }

        public string Address { get; set; }

        public string HeaderFio { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public Guid ProjectStateId { get; set; }

        public void Normalize()
        {
        }
    }
}
