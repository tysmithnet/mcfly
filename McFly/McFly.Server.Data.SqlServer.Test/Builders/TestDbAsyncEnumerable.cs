// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer.Test
// Author           : @tysmithnet
// Created          : 04-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="TestDbAsyncEnumerable.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    /// <summary>
    ///     Test class for DbAsyncEnumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Linq.EnumerableQuery{T}" />
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerable{T}" />
    /// <seealso cref="System.Linq.IQueryable{T}" />
    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TestDbAsyncEnumerable{T}" /> class.
        /// </summary>
        /// <param name="enumerable">The enumerable.</param>
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TestDbAsyncEnumerable{T}" /> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        /// <summary>
        ///     Gets an enumerator that can be used to asynchronously enumerate the sequence.
        /// </summary>
        /// <returns>Enumerator for asynchronous enumeration over the sequence.</returns>
        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        /// <summary>
        ///     Gets an enumerator that can be used to asynchronously enumerate the sequence.
        /// </summary>
        /// <returns>Enumerator for asynchronous enumeration over the sequence.</returns>
        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        /// <summary>
        ///     Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        IQueryProvider IQueryable.Provider => new TestDbAsyncQueryProvider<T>(this);
    }
}