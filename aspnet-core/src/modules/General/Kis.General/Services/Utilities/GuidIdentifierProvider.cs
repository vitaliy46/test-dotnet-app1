using System;
using System.Collections.Generic;
using Kis.Base.Dao;

namespace Kis.General.Services.Utilities
{
    public class GuidIdentifierProvider : IIdentifierProvider<Guid>
    {
        private readonly SequentialGuidGenerator _generator = new SequentialGuidGenerator();
        public Guid NewIdentifier()
        {
            return _generator.NewGuid(SequentialGuidType.SequentialAsString);
        }

        public IEnumerable<Guid> NewIdentifiers(int count)
        {
            var guids = new HashSet<Guid>();
            for(var i = 0; i < count; i++)
            {
                guids.Add(_generator.NewGuid(SequentialGuidType.SequentialAsString));
            }
            return guids;
        }
    }
}
