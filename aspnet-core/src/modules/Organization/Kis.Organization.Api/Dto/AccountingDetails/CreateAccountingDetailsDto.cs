using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.Base.Entity;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Api.Dto
{
    public class CreateAccountingDetailsDto : IShouldNormalize
    {
        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// ОГРН
        /// </summary>
        public string Ogrn { get; set; }

        public void Normalize()
        {
        }
    }
}
