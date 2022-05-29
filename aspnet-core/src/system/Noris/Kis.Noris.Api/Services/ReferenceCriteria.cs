using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    public abstract class ReferenceCriteria<T> : Criteria<T> where T : ReferenceEntity
    {

    }
}
