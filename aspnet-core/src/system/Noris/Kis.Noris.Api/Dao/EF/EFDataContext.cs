using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kis.Noris.Api.Data;
using Kis.Noris.Api.Data.CriteriaApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kis.Noris.Api.Dao.EF
{
    public class EFDataContext : IDataContext
    {
        private readonly DbContext _context;
        private Dictionary<Type, Func<EFDataContext, object>> _queryBuildersMap;

        internal DbContext DbContext
        {
            get
            {
                if(IsDisposed)
                    throw new ObjectDisposedException(nameof(EFDataContext));
                return _context;
            }
        }

        public bool IsReadOnly { get; private set; }

        public EFDataContext(DbContext context, bool isReadOnly)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if(isReadOnly) ToReadOnlyMode();
            _context = context;
        }

        public EFDataContext(DbConnection connection, bool contextOwnsConnection, bool isReadOnly)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            if (isReadOnly) ToReadOnlyMode();
            _context = new InternalDbContext(connection, contextOwnsConnection, this);
        }

        protected virtual void OnModelCreating(DbModelBuilder modelBuilder)
        { }

        protected virtual void OnQueryBuilderMapCreating(MapBuilder mapBuilder)
        { }

        public class MapBuilder
        {
            private readonly Dictionary<Type, Func<EFDataContext, object>> _map = new Dictionary<Type, Func<EFDataContext, object>>();

            public void RegisterQueryBuilder<TEntity, TBuilder>() where TBuilder : LinqQueryBuilder<TEntity>, new()
                where TEntity : class
            {
                _map[typeof (TEntity)] = context =>
                {
                    if (!context.IsRegisteredEntity(typeof(TEntity)))
                        throw new NotRegisteredEntityException(
                            $"Entity with type \"{typeof(TEntity).FullName}\" not registered in context");
                    var builder = new TBuilder();
                    builder.SetSource(context.DbContext.Set<TEntity>());
                    return builder;
                };
            }

            public void RegisterQueryBuilder<TTargetEntity, TSourceEntity, TBuilder>() where TBuilder : LinqProjectionQueryBuilder<TTargetEntity, TSourceEntity>, new()
                where TTargetEntity : class 
                where TSourceEntity : class
            {
                _map[typeof (TTargetEntity)] = context =>
                {
                    if (!context.IsRegisteredEntity(typeof(TSourceEntity)))
                        throw new NotRegisteredEntityException(
                            $"Entity \"{typeof(TTargetEntity).FullName}\" has projection to type \"{typeof(TSourceEntity).FullName}\" that is not registered in context");
                    var builder = new TBuilder();
                    builder.SetSource(context.DbContext.Set<TSourceEntity>());
                    return builder;
                };
            }

            internal Dictionary<Type, Func<EFDataContext, object>> Build()
            {
                return _map;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction().UnderlyingTransaction;
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return DbContext.Database.BeginTransaction(isolationLevel).UnderlyingTransaction;
        }

        public bool IsDisposed { get; private set; }

        public virtual void Dispose()
        {
            if(IsDisposed) return;
            DbContext.Dispose();
            IsDisposed = true;
        }

        public IDataSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(EFDataContext));
            
            return new EFDataSet<TEntity>(this, CreateBuilderForType<TEntity>);
        }

        private bool IsRegisteredEntity(Type entityType)
        {
            return ((IObjectContextAdapter)DbContext).ObjectContext.MetadataWorkspace.GetItems<EntityType>(
                DataSpace.OSpace)
                .Any(e => e.Name == entityType.Name);
        }

        private LinqQueryBuilder<TTargetEntity> CreateBuilderForType<TTargetEntity>() where TTargetEntity : class
        {
            InitializeQueryBuilderMap();
            // найти в карте билдеров запись для сущности с типом TTargetEntity
            if (_queryBuildersMap.ContainsKey(typeof (TTargetEntity)))
                return _queryBuildersMap[typeof (TTargetEntity)](this) as LinqQueryBuilder<TTargetEntity>;

            // если её нет, создать билдер по умолчанию
            if (!IsRegisteredEntity(typeof (TTargetEntity)))
                throw new NotRegisteredEntityException(
                    $"Entity with type \"{typeof (TTargetEntity).FullName}\" not registered in context");
            var linqBuilderBase = new LinqQueryBuilder<TTargetEntity>();
            linqBuilderBase.SetSource(DbContext.Set<TTargetEntity>());
            return linqBuilderBase;
        }

        private void InitializeQueryBuilderMap()
        {
            if (_queryBuildersMap != null) return;
            var mapBuilder = new MapBuilder();
            OnQueryBuilderMapCreating(mapBuilder);
            _queryBuildersMap = mapBuilder.Build();
        }

        public bool TrySet<TEntity>(out IDataSet<TEntity> set) where TEntity : class
        {
            try
            {
                set = Set<TEntity>();
                return true;
            }
            catch (NotRegisteredEntityException)
            {
                set = null;
                return false;
            }
        }

        public int SaveChanges()
        {
            if(IsReadOnly)
                throw new InvalidOperationException("Cannot apply changes for readonly data context.");

            return DbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            if (IsReadOnly)
                throw new InvalidOperationException("Cannot apply changes for readonly data context.");

            return DbContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (IsReadOnly)
                throw new InvalidOperationException("Cannot apply changes for readonly data context.");

            return DbContext.SaveChangesAsync(cancellationToken);
        }

        public void ToReadOnlyMode()
        {
            if(IsReadOnly) return;

            DbContext.Configuration.AutoDetectChangesEnabled = false;
            IsReadOnly = true;
        }

        public IDataSet Set(Type entityType)
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(EFDataContext));

            return new EFDataSet(this, entityType);
        }

        public bool TrySet(Type entityType, out IDataSet set)
        {
            try
            {
                set = Set(entityType);
                return true;
            }
            catch (NotRegisteredEntityException)
            {
                set = null;
                return false;
            }
        }

        private class InternalDbContext : DbContext
        {
            private readonly EFDataContext _contextWrapper;

            public InternalDbContext(DbConnection connection, 
                bool contextOwnsConnection, EFDataContext contextWrapper)
                : base(connection, contextOwnsConnection)
            {
                _contextWrapper = contextWrapper;
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                _contextWrapper.OnModelCreating(modelBuilder);
            }
        }
    }

    public abstract class LinqProjectionQueryBuilder<TTargetEntity, TSourceEntity> : LinqQueryBuilder<TTargetEntity>
        where TTargetEntity : class 
        where TSourceEntity : class
    {
        internal void SetSource(IQueryable<TSourceEntity> queryable)
        {
            ApplyProjection(queryable);
        }

        protected virtual void ApplyProjection(IQueryable<TSourceEntity> queryable)
        {
            Query = queryable.Cast<TTargetEntity>();
        }
    }

    public class LinqQueryBuilder<TEntity> where TEntity : class
    {
        protected virtual IQueryable<TEntity> Query { get; set; }
        private bool _isOrdered;

        internal void SetSource(IQueryable<TEntity> queryable)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));
            Query = queryable;
        }

        public virtual void ApplyFetching()
        {
            throw new NotImplementedException();
        }

        public virtual void ApplyFiltering(ICriteria<TEntity> criteria)
        {
            var criteriaExpression = criteria.CriteriaExpression;
            var map = criteriaExpression.Parameters.Select((e, i) =>
            {
                if (i == 0)
                    return new {e, exp = Expression.Parameter(typeof (TEntity), "entity")};
                return new {e, exp = e};
            }).ToDictionary(p => p.e, p => p.exp);
            var expression = ParameterRebinder.ReplaceParameters(map, criteriaExpression.Body);
            var filter = Expression.Lambda<Func<TEntity, bool>>(expression, criteriaExpression.TailCall, map.Values);
            Query = Query.Where(filter);
        }

        public virtual void ApplyOrdering<TKey>(Expression<Func<TEntity, TKey>> keySelector, bool @descending)
        {
            if (!_isOrdered)
            {
                Query = !@descending ? Query.OrderBy(keySelector) : Query.OrderByDescending(keySelector);
                _isOrdered = true;
            }
            else
            {
                Query = !@descending
                    ? ((IOrderedQueryable<TEntity>) Query).ThenBy(keySelector)
                    : ((IOrderedQueryable<TEntity>) Query).ThenByDescending(keySelector);
            }
        }

        public virtual void ApplyLimiting(int limitToCount, int? offsetCount)
        {
            if (offsetCount != null)
                Query = Query.Skip(offsetCount.Value);
            Query = Query.Take(limitToCount);
        }

        internal IQueryable<TEntity> GetQuery()
        {
            return Query;
        }
    }
}
