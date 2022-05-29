using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.Users.Dto;

namespace Kis.General.Api.Dto.PersonUser
{
    /// <summary> 
    /// Учетная запись для персоны
    /// </summary>
    public class UpdatePersonUserDto : IShouldNormalize
    {
        public UserDto User { get; set; }

        public void Normalize()
        {
        }
    }
}
