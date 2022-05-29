using System;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Участник голосования
    /// </summary>
    public class VoteMemberDto : BaseDto<Guid>
    {
        /// <summary>
        /// Как правило указывается ФИО участника
        /// </summary>
        public string Name { get; set; }
        
        public long UserId { get; set; }

        public Guid VoteId { get; set; }

        public VoteMemberContactDto VoteMemberContact { get; set; }
        public Guid VoteMemberContactId { get; set; }
    }
}
