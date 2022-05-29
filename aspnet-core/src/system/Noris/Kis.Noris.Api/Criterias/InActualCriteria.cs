using System.Linq.Expressions;
using Kis.Noris.Api.Constants;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Criterias
{
    public class InActualCriteria : ReferenceCriteria<ReferenceEntity> //CriteriaBase<ReferenceEntity>
    {
        public override Expression<Criterion<ReferenceEntity>> Criterion
        {
            get { return entity => entity.ReleaseDateEnd == ReferenceBookConstants.ActualReleaseEndDate; }
        }
    }
}