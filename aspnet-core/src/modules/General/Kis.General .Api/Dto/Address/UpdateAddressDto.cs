using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Constant;

namespace Kis.General.Api.Dto
{
    public class UpdateAddressDto : IShouldNormalize
    {
        public AddressTypes? AddressType { get; set; }

        public string FullAddress { get; set; }

        public void Normalize()
        {
        }
    }

   
}