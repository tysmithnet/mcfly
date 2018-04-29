// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer.Test
// Author           : @tysmithnet
// Created          : 04-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="TestDbAsyncEnumerator.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    /// <summary>
    ///     Test class for DbAsyncEnumerator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerator{T}" />
    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TestDbAsyncEnumerator{T}" /> class.
        /// </summary>
        /// <param name="inner">The inner.</param>
        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        /// <summary>
        ///     The inner enumerator
        /// </summary>
        private readonly IEnumerator<T> _inner;

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _inner.Dispose();
        }

        /// <summary>
        ///     Advances the enumerator to the next element in the sequence, returning the result asynchronously.
        /// </summary>
        /// <param name="cancellationToken">
        ///     A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the
        ///     task to complete.
        /// </param>
        /// <returns>
        ///     A task that represents the asynchronous operation.
        ///     The task result contains true if the enumerator was successfully advanced to the next element; false if the
        ///     enumerator has passed the end of the sequence.
        /// </returns>
        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        /// <summary>
        ///     Gets the current element in the iteration.
        /// </summary>
        /// <value>The current.</value>
        public T Current => _inner.Current;

        /// <summary>
        ///     Gets the current element in the iteration.
        /// </summary>
        /// <value>The current.</value>
        object IDbAsyncEnumerator.Current => Current;
    }
}