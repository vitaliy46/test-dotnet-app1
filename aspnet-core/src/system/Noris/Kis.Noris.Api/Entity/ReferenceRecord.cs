using System;
using System.Collections.Generic;

namespace Kis.Noris.Api.Entity
{
    public class ReferenceRecord
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<string> Headers { get; set; }
        public string[,] Values { get; set; }

        public DateTime[] Releases { get; set; }

        public DateTime SelectedRelease { get; set; }
    }
}
