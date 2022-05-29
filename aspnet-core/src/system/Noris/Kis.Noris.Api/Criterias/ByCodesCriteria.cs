using System.Linq;
using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Criterias
{
    public class ByCodesCriteria : ReferenceCriteria<ReferenceEntity> //CriteriaBase<ReferenceEntity>
    {
        public ByCodesCriteria(params string[] codes)
        {
            Codes = codes;
        }

        public string[] Codes { get; }
        public override Expression<Criterion<ReferenceEntity>> Criterion
        {
            get { return entity => Codes.Contains(entity.Code); }
        }
    }
}