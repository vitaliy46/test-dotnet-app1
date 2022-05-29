using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Kis.Noris.Api.Data
{
    public interface IDataContext : IDisposable
    {
        IDataSet Set(Type entityType);

        IDataSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync();

        IDbTransaction BeginTransaction();

        IDbTransaction BeginTransaction(IsolationLevel isolationLevel);

        bool IsReadOnly { get; }

        void ToReadOnlyMode();
        
        bool TrySet<TEntity>(out IDataSet<TEntity> set) where TEntity : class;
        bool TrySet(Type entityType, out IDataSet set);
    }
}