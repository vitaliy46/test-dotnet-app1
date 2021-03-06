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
    /// Maintains a list of lazily-created DbContext instances.
    /// </summary>
    public interface IDataContextCollection : IDisposable
    {
        /// <summary>
        /// Get or create a DbContext instance of the specified type. 
        /// </summary>
		TDataContext Get<TDataContext>() where TDataContext : class, IDataContext;
    }
}