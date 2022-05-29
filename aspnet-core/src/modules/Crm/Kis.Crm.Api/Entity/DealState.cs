using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Crm.Api.Entity
{
    public class DealState : EntityBase<Guid>
    {
        public Deal Deal { get; set; }

        public State State { get; set; }
    }
}
