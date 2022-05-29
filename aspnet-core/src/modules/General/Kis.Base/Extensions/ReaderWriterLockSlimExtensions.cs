using System;
using System.Diagnostics.Contracts;
using System.Threading;

namespace Kis.Base.Extensions
{
    /// <summary>
    /// Static helper class with usefull extensions methods for ReaderWriterLockSlim.
    /// This class introduces RAII idiom (with using statement) for reading and writing locking
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {
        /// <summary>
        /// Helper class that return IDisposable object for reading operations.
        /// Calling Dispose on return value will call ExitReadLock.
        /// </summary>
        public static IDisposable UseReadLock(this ReaderWriterLockSlim readerWriterLock)
        {
            Contract.Requires(readerWriterLock != null);
            Contract.Ensures(Contract.Result<IDisposable>() != null);

            if (readerWriterLock.IsReadLockHeld ||
                readerWriterLock.IsUpgradeableReadLockHeld ||
                readerWriterLock.IsWriteLockHeld)
                return null;

            readerWriterLock.EnterReadLock();
            return new DisposeActionWrapper(
                readerWriterLock.ExitReadLock);
        }

        /// <summary>
        /// Helper class that return IDisposable object for writing operations.
        /// Calling Dispose on return value will call ExitWriteLock.
        /// </summary>
        public static IDisposable UseWriteLock(this ReaderWriterLockSlim readerWriterLock)
        {
            Contract.Requires(readerWriterLock != null);
            Contract.Ensures(Contract.Result<IDisposable>() != null);

            if (readerWriterLock.IsWriteLockHeld)
                return null;

            readerWriterLock.EnterWriteLock();
            return new DisposeActionWrapper(
                readerWriterLock.ExitWriteLock);
        }

        /// <summary>
        /// Helper class that return IDisposable object for upgradeable operations.
        /// Calling Dispose on return value will call ExitUpgradeableLock.
        /// </summary>
        public static IDisposable UseUpgradeableLock(this ReaderWriterLockSlim readerWriterLock)
        {
            Contract.Requires(readerWriterLock != null);
            Contract.Ensures(Contract.Result<IDisposable>() != null);

            if (readerWriterLock.IsUpgradeableReadLockHeld ||
                readerWriterLock.IsWriteLockHeld)
                return null;

            readerWriterLock.EnterUpgradeableReadLock();
            return new DisposeActionWrapper(
                readerWriterLock.ExitUpgradeableReadLock);
        }

        /// <summary>
        /// Internal class that helps implement RAII behavior
        /// </summary>
        internal class DisposeActionWrapper : IDisposable
        {
            private readonly Action _action;

            public DisposeActionWrapper(Action action)
            {
                Contract.Requires(action != null);

                _action = action;
            }

            public void Dispose()
            {
                _action();
            }

        }
    }
}
