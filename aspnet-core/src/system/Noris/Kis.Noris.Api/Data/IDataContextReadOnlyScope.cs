/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System;

namespace Kis.Noris.Api.Data
{
    /// <summary>
    /// A read-only DbContextScope. Refer to the comments for IDbContextScope
    /// for more details.
    /// </summary>
    public interface IDataContextReadOnlyScope : IDisposable
    {
        /// <summary>
        /// The DbContext instances that this DbContextScope manages.
        /// </summary>
        IDataContextCollection DataContexts { get; }
    }
}