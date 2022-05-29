using System;
using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Criterias
{
    public class ByRecordIdCriteria : Criteria<ReferenceEntity>
        // CriteriaBase<ReferenceEntity>
    {
        public ByRecordIdCriteria(Guid recordId)
        {
            RecordId = recordId;
        }

        public Guid RecordId { get; }
        public override Expression<Criterion<ReferenceEntity>> Criterion
        {
            get { return entity => entity.RecordId == RecordId; }
        }
    }
}