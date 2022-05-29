using System;
using System.Linq;
using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Criterias
{
    public class ByRecordIdsCriteria : ReferenceCriteria<ReferenceEntity> //CriteriaBase<ReferenceEntity>
    {
        public Guid[] RecordIds { get; }

        public ByRecordIdsCriteria(params Guid[] recordIds)
        {
            RecordIds = recordIds;
        }

        public override Expression<Criterion<ReferenceEntity>> Criterion
        {
            get { return entity => RecordIds.Contains(entity.RecordId); }
        }
    }
}