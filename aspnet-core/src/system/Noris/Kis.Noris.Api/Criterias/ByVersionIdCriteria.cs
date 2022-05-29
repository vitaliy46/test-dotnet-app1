using System;
using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Criterias
{
    public class ByVersionIdCriteria : ReferenceCriteria<ReferenceEntity> //CriteriaBase<ReferenceEntity>
    {
        public ByVersionIdCriteria(Guid versionId)
        {
            VersionId = versionId;
        }

        public Guid VersionId { get; }
        public override Expression<Criterion<ReferenceEntity>> Criterion
        {
            get { return entity => entity.VersionId == VersionId; }
        }
    }
}