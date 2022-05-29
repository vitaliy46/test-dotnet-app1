using System;
using Kis.Authorization.Users;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary> Учетная запись для персоны
    /// </summary>
    public class PersonUser : EntityBase<Guid>
    {
        public virtual Person Person { get; set; }
        public Guid PersonId { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }
    }
}
