// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-29-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="FrameDomainEntityConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Domain entity converter for frames and frameenities
    /// </summary>
    /// <seealso
    ///     cref="McFly.Server.Data.SqlServer.IDomainEntityConverter{McFly.Core.Frame, McFly.Server.Data.SqlServer.FrameEntity}" />
    internal class FrameDomainEntityConverter : IDomainEntityConverter<Frame, FrameEntity>
    {
        /// <summary>
        ///     Convert a frame entity to a frame domain object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding domain object for the provided entity</returns>
        /// <inheritdoc />
        public Frame ToDomain(FrameEntity entity, IMcFlyContext context)
        {
            return null;
        }

        /// <summary>
        ///     Convert a frame domain object to an entity
        /// </summary>
        /// <param name="domainObject">The domain object.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding database entity for the provided domain object</returns>
        /// <inheritdoc />
        public FrameEntity ToEntity(Frame domainObject, IMcFlyContext context)
        {
            return null;
        }
    }
}