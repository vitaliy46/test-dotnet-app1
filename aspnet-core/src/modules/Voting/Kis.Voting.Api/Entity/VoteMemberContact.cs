using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Контакт участника, указанный для уведомления о голосовании 
    /// </summary>
    public class VoteMemberContact : EntityBase<Guid>
    {
        public Contact Contact { get; set; }
        public Guid ContactId { get; set; }
    }
}
