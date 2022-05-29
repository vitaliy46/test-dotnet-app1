using System;
using Kis.Base.Entity;

namespace Kis.Noris.Api.Entity
{
    public class ReferenceBookInfo : EntityBase<Guid>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string CurrentVersion { get; set; }

        public string AvailableUpdates { get; set; }

        public bool HasSqlScriptUpdateProvider { get; set; }
    }
}
