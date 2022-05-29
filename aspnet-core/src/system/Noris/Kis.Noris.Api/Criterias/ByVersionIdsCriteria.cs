using System;
using System.Linq;
using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Criterias
{
    public class ByVersionIdsCriteria : ReferenceCriteria<ReferenceEntity> //CriteriaBase<ReferenceEntity>
    {
        public ByVersionIdsCriteria(params Guid[] versionIds)
        {
            VersionIds = versionIds;
        }

        public Guid[] VersionIds { get; }
        public override Expression<Criterion<ReferenceEntity>> Criterion
        {
            get { return entity => VersionIds.Contains(entity.VersionId); }
        }
    }
}