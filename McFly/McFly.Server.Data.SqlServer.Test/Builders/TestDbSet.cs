// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer.Test
// Author           : @tysmithnet
// Created          : 04-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="TestDbSet.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    /// <summary>
    ///     Test class for DbSet
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="System.Data.Entity.DbSet{TEntity}" />
    /// <seealso cref="System.Linq.IQueryable" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{TEntity}" />
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerable{TEntity}" />
    public class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>
        where TEntity : class
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TestDbSet{TEntity}" /> class.
        /// </summary>
        public TestDbSet()
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        /// <summary>
        ///     The data
        /// </summary>
        private readonly ObservableCollection<TEntity> _data;

        /// <summary>
        ///     The query
        /// </summary>
        private readonly IQueryable _query;

        /// <summary>
        ///     Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>TEntity.</returns>
        public override TEntity Add(TEntity item)
        {
            _data.Add(item);
            return item;
        }

        /// <summary>
        ///     Attaches the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>TEntity.</returns>
        public override TEntity Attach(TEntity item)
        {
            _data.Add(item);
            return item;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>TEntity.</returns>
        /// <inheritdoc />
        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <typeparam name="TDerivedEntity">The type of the t derived entity.</typeparam>
        /// <returns>TDerivedEntity.</returns>
        /// <inheritdoc />
        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        /// <summary>
        ///     Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>TEntity.</returns>
        public override TEntity Remove(TEntity item)
        {
            _data.Remove(item);
            return item;
        }

        /// <summary>
        ///     Gets an enumerator that can be used to asynchronously enumerate the sequence.
        /// </summary>
        /// <returns>Enumerator for asynchronous enumeration over the sequence.</returns>
        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }

        /// <summary>
        ///     Gets the enumerator.
        /// </summary>
        /// <returns>IEnumerator&lt;TEntity&gt;.</returns>
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        /// <summary>
        ///     Gets the enumerator.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        /// <summary>
        ///     Gets the local.
        /// </summary>
        /// <value>The local.</value>
        /// <inheritdoc />
        public override ObservableCollection<TEntity> Local => _data;

        /// <summary>
        ///     Gets the type of the element.
        /// </summary>
        /// <value>The type of the element.</value>
        Type IQueryable.ElementType => _query.ElementType;

        /// <summary>
        ///     Gets the expression.
        /// </summary>
        /// <value>The expression.</value>
        Expression IQueryable.Expression => _query.Expression;

        /// <summary>
        ///     Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        IQueryProvider IQueryable.Provider => new TestDbAsyncQueryProvider<TEntity>(_query.Provider);
    }
}