using System;
using Abp.Runtime.Validation;
using Kis.Users.Dto;

namespace Kis.General.Api.Dto.PersonUser
{
    /// <summary> 
    /// Учетная запись для персоны
    /// </summary>
    public class CreatePersonUserDto : IShouldNormalize
    {
        public CreateUserDto User { get; set; }

        public void Normalize()
        {
        }
    }
}
