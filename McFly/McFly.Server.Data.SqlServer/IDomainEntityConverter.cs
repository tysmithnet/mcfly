// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-29-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="IDomainEntityConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Represents an object that is capable of converting between domain objects and
    ///     database entities
    /// </summary>
    /// <typeparam name="TDomain">The type of the domain object.</typeparam>
    /// <typeparam name="TEntity">The type of the db entity.</typeparam>
    internal interface IDomainEntityConverter<TDomain, TEntity>
    {
        /// <summary>
        ///     Convert an entity to a domain object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding domain object for the provided entity</returns>
        TDomain ToDomain(TEntity entity, IMcFlyContext context);

        /// <summary>
        ///     Convert a domain object to an entity
        /// </summary>
        /// <param name="domainObject">The domain object.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding database entity for the provided domain object</returns>
        TEntity ToEntity(TDomain domainObject, IMcFlyContext context);
    }
}