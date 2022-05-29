using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kis.Noris.Api.Data.CriteriaApi;

namespace Kis.Noris.Api.Data
{
    public interface IDataSet
    {
        void Add(object entity);

        void Remove(object entity);

        object Get(Guid id);
    }

    public interface IDataSet<TEntity> : IFetchableQuery<TEntity>, IFilterableQuery<TEntity>,
        IOrderableQuery<TEntity>, ISelectableQuery<TEntity> where TEntity : class
    {
        TEntity Get(Guid id);

        void Add(TEntity entity);

        void Remove(TEntity entity);
        bool IsProjectionSet { get; }
    }

    #region Generic query interfaces
    public interface IFetchedQuery<TEntity> : IFilterableQuery<TEntity>, IOrderableQuery<TEntity>, ISelectableQuery<TEntity>
        where TEntity : class
    { }

    public interface ISelectableQuery<TEntity>
    {
        int SelectCount();
        TEntity SelectFirst();
        IReadOnlyList<TEntity> SelectAll();
        TResult SelectMax<TResult>(Expression<Func<TEntity, TResult>> selector);
        TResult SelectMin<TResult>(Expression<Func<TEntity, TResult>> selector);
        int SelectSum(Expression<Func<TEntity, int>> selector);
        long SelectSum(Expression<Func<TEntity, long>> selector);
        float SelectSum(Expression<Func<TEntity, float>> selector);
        double SelectSum(Expression<Func<TEntity, double>> selector);
        decimal SelectSum(Expression<Func<TEntity, decimal>> selector);
        int? SelectSum(Expression<Func<TEntity, int?>> selector);
        long? SelectSum(Expression<Func<TEntity, long?>> selector);
        float? SelectSum(Expression<Func<TEntity, float?>> selector);
        double? SelectSum(Expression<Func<TEntity, double?>> selector);
        decimal? SelectSum(Expression<Func<TEntity, decimal?>> selector);
    }

    public interface IFilteredQuery<TEntity> : IOrderableQuery<TEntity>, ISelectableQuery<TEntity> where TEntity : class
    { }

    public interface IOrderedQuery<TEntity> : IOrderableQuery<TEntity>, ILimitableQuery<TEntity>, ISelectableQuery<TEntity> where TEntity : class
    { }

    public interface ILimitedQuery<TEntity> : ISelectableQuery<TEntity> where TEntity : class
    { }

    public interface IFetchableQuery<TEntity> where TEntity : class
    {
        IFetchedQuery<TEntity> Fetch();
    }

    public interface IFilterableQuery<TEntity>
        where TEntity : class
    {
        IFilteredQuery<TEntity> Filter(ICriteria<TEntity> criteria);
    }

    public interface IOrderableQuery<TEntity> where TEntity : class
    {
        IOrderedQuery<TEntity> OrderAsc<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        IOrderedQuery<TEntity> OrderDesc<TKey>(Expression<Func<TEntity, TKey>> keySelector);
    }

    public interface ILimitableQuery<TEntity> where TEntity : class
    {
        ILimitedQuery<TEntity> Limit(int limitToCount, int? offsetCount = null);
    }
    #endregion
}