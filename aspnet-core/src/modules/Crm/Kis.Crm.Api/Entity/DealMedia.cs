using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Crm.Api.Entity
{
    public class DealMedia : EntityBase<Guid>
    {
        public Deal Deal { get; set; }

        public Media Media { get; set; }
    }
}
