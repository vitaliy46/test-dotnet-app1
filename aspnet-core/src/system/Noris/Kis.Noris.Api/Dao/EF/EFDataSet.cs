using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using Kis.Noris.Api.Data;
using Kis.Noris.Api.Data.CriteriaApi;

namespace Kis.Noris.Api.Dao.EF
{
    internal class EFDataSet : IDataSet
    {
        protected readonly EFDataContext UnderlyingContext;
        private readonly Type _entityType;
        
        public EFDataSet(EFDataContext underlyingContext, Type entityType)
        {
            if (underlyingContext == null) throw new ArgumentNullException(nameof(underlyingContext));
            if (entityType == null) throw new ArgumentNullException(nameof(entityType));

            UnderlyingContext = underlyingContext;
            _entityType = entityType;
        }

        public void Add(object entity)
        {
            if(UnderlyingContext.IsReadOnly)
                throw new InvalidOperationException("Can not add entity to readonly data context");
            UnderlyingContext.DbContext.Set(_entityType).Add(entity);
        }

        public void Remove(object entity)
        {
            if (UnderlyingContext.IsReadOnly)
                throw new InvalidOperationException("Can not remove entity from readonly data context");
            UnderlyingContext.DbContext.Set(_entityType).Remove(entity);
        }

        public object Get(Guid id)
        {
            return UnderlyingContext.DbContext.Set(_entityType).Find(id);
        }
    }

    internal class EFDataSet<TEntity> : EFDataSet, IDataSet<TEntity>, IFilteredQuery<TEntity>, IOrderedQuery<TEntity>, ILimitedQuery<TEntity>, IFetchedQuery<TEntity> where TEntity : class
    {
        private readonly Func<LinqQueryBuilder<TEntity>> _queryBuilderFactory;
        private readonly EFDataSet<TEntity> _innerSet;
        private readonly Action<LinqQueryBuilder<TEntity>> _applyAction;

        public EFDataSet(EFDataContext underlyingContext, Func<LinqQueryBuilder<TEntity>> queryBuilderFactoryFactory)
            : base(underlyingContext, typeof (TEntity))
        {
            if (underlyingContext == null) throw new ArgumentNullException(nameof(underlyingContext));
            if (queryBuilderFactoryFactory == null) throw new ArgumentNullException(nameof(queryBuilderFactoryFactory));

            _queryBuilderFactory = queryBuilderFactoryFactory;
            IsProjectionSet = IsProjectionQueryBuilder(queryBuilderFactoryFactory);
        }

        public bool IsProjectionSet { get; }

        private bool IsProjectionQueryBuilder(Func<LinqQueryBuilder<TEntity>> queryBuilderFactory)
        {
            var type = queryBuilderFactory.GetType();
            while (type != null)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (LinqProjectionQueryBuilder<,>))
                    return true;
                type = type.BaseType;
            }
            return false;
        }

        public EFDataSet(EFDataContext underlyingContext, EFDataSet<TEntity> innerSet, Action<LinqQueryBuilder<TEntity>> applyAction)
            : base(underlyingContext, typeof(TEntity))
        {
            if (innerSet == null) throw new ArgumentNullException(nameof(innerSet));
            if (applyAction == null) throw new ArgumentNullException(nameof(applyAction));

            _innerSet = innerSet;
            _applyAction = applyAction;
        }

        public void Add(TEntity entity)
        {
            if (UnderlyingContext.IsReadOnly)
                throw new InvalidOperationException("Can not perform DML operations on data set from readonly data context.");
            if(IsProjectionSet)
                throw new NotSupportedException("Can not perform DML operations on projection data set.");
            if(_innerSet != null)
                throw new NotSupportedException("Can not perform DML operations on data set, when it used in query building chain.");
            UnderlyingContext.DbContext.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            if (UnderlyingContext.IsReadOnly)
                throw new InvalidOperationException("Can not perform DML operations on data set from readonly data context.");
            if (IsProjectionSet)
                throw new NotSupportedException("Can not perform DML operations on projection data set.");
            if (_innerSet != null)
                throw new NotSupportedException("Can not perform DML operations on data set, when it used in query building chain.");
            UnderlyingContext.DbContext.Set<TEntity>().Remove(entity);
        }

        public new TEntity Get(Guid id)
        {
            if (IsProjectionSet)
                throw new NotSupportedException("Can not perform DML operations on projection data set.");
            if (_innerSet != null)
                throw new NotSupportedException("Can not perform DML operations on data set, when it used in query building chain.");
            return UnderlyingContext.DbContext.Set<TEntity>().Find(id);
        }


        public IFetchedQuery<TEntity> Fetch()
        {
            return new EFDataSet<TEntity>(UnderlyingContext, this, builder => { builder.ApplyFetching(); });
        }

        public IFilteredQuery<TEntity> Filter(ICriteria<TEntity> criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            return new EFDataSet<TEntity>(UnderlyingContext, this, builder => { builder.ApplyFiltering(criteria); });
        }

        public IOrderedQuery<TEntity> OrderAsc<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new EFDataSet<TEntity>(UnderlyingContext, this, builder => {builder.ApplyOrdering(keySelector, false);});
        }

        public IOrderedQuery<TEntity> OrderDesc<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new EFDataSet<TEntity>(UnderlyingContext, this, builder => {builder.ApplyOrdering(keySelector, true);});
        }

        public ILimitedQuery<TEntity> Limit(int limitToCount, int? offsetCount = null)
        {
            if (limitToCount < 0)
                throw new ArgumentOutOfRangeException(nameof(limitToCount), limitToCount, "The value must be non-negative");
            if (offsetCount.HasValue && offsetCount.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(offsetCount), offsetCount.Value,
                    "The value must be non-negative");

            return new EFDataSet<TEntity>(UnderlyingContext, this, builder => {builder.ApplyLimiting(limitToCount, offsetCount);});
        }

        private LinqQueryBuilder<TEntity> BuildQuery()
        {
            if (_innerSet == null)
            {
                return _queryBuilderFactory();
            }
            var builder = _innerSet.BuildQuery();
            _applyAction(builder);
            return builder;
        } 


        public int SelectCount()
        {
            return BuildQuery().GetQuery().Count();
        }

        public TEntity SelectFirst()
        {
            return BuildQuery().GetQuery().FirstOrDefault();
        }

        public IReadOnlyList<TEntity> SelectAll()
        {
            return new ReadOnlyCollection<TEntity>(BuildQuery().GetQuery().ToArray());
        }

        public TResult SelectMax<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return BuildQuery().GetQuery().Max(selector);
        }

        public TResult SelectMin<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return BuildQuery().GetQuery().Min(selector);
        }

        public int SelectSum(Expression<Func<TEntity, int>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public long SelectSum(Expression<Func<TEntity, long>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public float SelectSum(Expression<Func<TEntity, float>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public double SelectSum(Expression<Func<TEntity, double>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public decimal SelectSum(Expression<Func<TEntity, decimal>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public int? SelectSum(Expression<Func<TEntity, int?>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public long? SelectSum(Expression<Func<TEntity, long?>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public float? SelectSum(Expression<Func<TEntity, float?>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public double? SelectSum(Expression<Func<TEntity, double?>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }

        public decimal? SelectSum(Expression<Func<TEntity, decimal?>> selector)
        {
            return BuildQuery().GetQuery().Sum(selector);
        }
    }
}
