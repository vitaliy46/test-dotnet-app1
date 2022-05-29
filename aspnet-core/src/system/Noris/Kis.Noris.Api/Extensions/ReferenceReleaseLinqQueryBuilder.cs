using System.Linq;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Extensions
{
    public class ReferenceReleaseLinqQueryBuilder<TReferenceEntity> : LinqProjectionQueryBuilder<ReferenceRelease<TReferenceEntity>, TReferenceEntity> where TReferenceEntity : ReferenceEntity
    {
        protected override void ApplyProjection(IQueryable<TReferenceEntity> queryable)
        {
            Query = queryable.Select(o => new ReferenceRelease<TReferenceEntity>
            {
                ReleaseDate = o.ReleaseDateBegin
            });
        }
    }

    public static class EFDataContextMapBuilderExtensions
    {
        public static void RegisterReferenceQueryBuilderFor<TReferenceEntity>(this EFDataContext.MapBuilder builder) where TReferenceEntity : ReferenceEntity
        {
            builder.RegisterQueryBuilder<ReferenceRelease<TReferenceEntity>, TReferenceEntity, ReferenceReleaseLinqQueryBuilder<TReferenceEntity>>();
        }
    }
}
