using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary> Контактные данные персоны
    /// </summary>
    public class PersonContact : EntityBase<Guid>
    {
        public virtual Person Person { get; set; }
        public Guid PersonId { get; set; }
        public virtual Contact Contact { get; set; }
        public Guid ContactId { get; set; }
    }
}
