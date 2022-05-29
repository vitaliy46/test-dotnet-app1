using System;
using System.Collections.Generic;

namespace Kis.Noris.Api.Entity
{
    public class ReferenceScript
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CurrentVersion { get; set; }
        public IEnumerable<DateTime> Releases { get; set; }
    }
}
