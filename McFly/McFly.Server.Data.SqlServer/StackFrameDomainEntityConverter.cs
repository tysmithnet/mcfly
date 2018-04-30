// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-29-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="StackFrameDomainEntityConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Domain entity converter for <see cref="StackFrame" /> and <see cref="StackFrameEntity" />
    /// </summary>
    /// <seealso
    ///     cref="McFly.Server.Data.SqlServer.IDomainEntityConverter{McFly.Core.StackFrame, McFly.Server.Data.SqlServer.StackFrameEntity}" />
    internal class StackFrameDomainEntityConverter : IDomainEntityConverter<StackFrame, StackFrameEntity>
    {
        /// <summary>
        ///     Convert an entity to a domain object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding domain object for the provided entity</returns>
        /// <inheritdoc />
        public StackFrame ToDomain(StackFrameEntity entity, IMcFlyContext context)
        {
            return new StackFrame(entity.StackPointer.ToULong(), entity.ReturnAddress?.ToULong(), entity.ModuleName,
                entity.Function, entity.Offset?.ToULong());
        }

        /// <summary>
        ///     Convert a domain object to an entity
        /// </summary>
        /// <param name="domainObject">The domain object.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding database entity for the provided domain object</returns>
        /// <inheritdoc />
        public StackFrameEntity ToEntity(StackFrame domainObject, IMcFlyContext context)
        {
            return null;
        }
    }
}