using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Указанный контакт для уведомления о голосовании участника
    /// </summary>
    public class VoteMemberContactDto : BaseDto<Guid>
    {
        public ContactDto Contact { get; set; }
        public Guid ContactId { get; set; }
    }
}
