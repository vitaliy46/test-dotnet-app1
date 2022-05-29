using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Criterias
{
    public class WithDeletedCriteria : ReferenceCriteria<ReferenceEntity> //CriteriaBase<ReferenceEntity>
    {
        public override Expression<Criterion<ReferenceEntity>> Criterion => null;
    }
}