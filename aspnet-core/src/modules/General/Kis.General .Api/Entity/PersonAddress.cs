using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary> Контактные данные персоны
    /// </summary>
    public class PersonAddress : EntityBase<Guid>
    {
        public Guid PersonId { get; set; }
        public virtual Address Address { get; set; }
        public Guid AddressId { get; set; }
    }
}
