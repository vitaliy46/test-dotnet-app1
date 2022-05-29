using System;
using Kis.Base.Dto;
using Kis.Users.Dto;

namespace Kis.General.Api.Dto.PersonUser
{
    /// <summary> 
    /// Учетная запись для персоны
    /// </summary>
    public class PersonUserDto : BaseDto<Guid>
    {
        public Guid PersonId { get; set; }

        public UserDto User { get; set; }
        public long UserId { get; set; }
    }
}
