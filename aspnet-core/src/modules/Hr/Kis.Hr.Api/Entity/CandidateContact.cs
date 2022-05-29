using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Hr.Api.Entity
{
    /// <summary>
    /// Сонтактные сведения о клиенте
    /// </summary>
    public class CandidateContact : EntityBase<Guid>
    {
        public Candidate Candidate { get; set; }

        public Contact Contact { get; set; }
    }
}
