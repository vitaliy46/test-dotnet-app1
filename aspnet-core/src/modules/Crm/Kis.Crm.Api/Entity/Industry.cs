using System;
using Kis.Base.Entity;

namespace Kis.Crm.Api.Entity
{
    /// <summary>
    /// Отрасль (сфера деятельности), в которой работает юр. лицо.
    /// </summary>
    public class Industry : EntityBase<Guid>
    {
        public string  Name { get; set; }

        public virtual ushort OrderIndex { get; set; }
    }
}
