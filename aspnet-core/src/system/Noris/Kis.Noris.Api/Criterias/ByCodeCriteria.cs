using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Criterias
{
    public class ByCodeCriteria : ReferenceCriteria<ReferenceEntity> //CriteriaBase<ReferenceEntity>
    {
        public ByCodeCriteria(string code)
        {
            Code = code;
        }

        public string Code { get; }
        public override Expression<Criterion<ReferenceEntity>> Criterion
        {
            get { return entity => entity.Code == Code; }
        }
    }
}