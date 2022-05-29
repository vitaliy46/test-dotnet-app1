using System;
using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Criterias
{
    public class InReleaseCriteria : ReferenceCriteria<ReferenceEntity> //CriteriaBase<ReferenceEntity>
    {
        public InReleaseCriteria(DateTime releaseDate)
        {
            ReleaseDate = releaseDate/*.Date*/;
        }

        public DateTime ReleaseDate { get; }
        public override Expression<Criterion<ReferenceEntity>> Criterion
        {
            get
            {
                return entity => entity.ReleaseDateBegin <= ReleaseDate &&
                                 entity.ReleaseDateEnd >= ReleaseDate;
            }
        }
    }
}