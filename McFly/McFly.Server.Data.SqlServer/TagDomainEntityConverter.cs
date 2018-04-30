// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-29-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="TagDomainEntityConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Domain converter for tags
    /// </summary>
    /// <seealso
    ///     cref="McFly.Server.Data.SqlServer.IDomainEntityConverter{McFly.Core.Tag, McFly.Server.Data.SqlServer.TagEntity}" />
    internal class TagDomainEntityConverter : IDomainEntityConverter<Tag, TagEntity>
    {
        /// <summary>
        ///     Convert an entity to a domain object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding domain object for the provided entity</returns>
        /// <inheritdoc />
        public Tag ToDomain(TagEntity entity, IMcFlyContext context)
        {
            return new Tag
            {
                Body = entity.Body,
                Title = entity.Title,
                CreateDateUtc = entity.CreateDateUtc,
                Id = entity.Id
            };
        }

        /// <summary>
        ///     Convert a domain object to an entity
        /// </summary>
        /// <param name="domainObject">The domain object.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding database entity for the provided domain object</returns>
        /// <inheritdoc />
        public TagEntity ToEntity(Tag domainObject, IMcFlyContext context)
        {
            var first = context.TagEntities.FirstOrDefault(t => t.Id == domainObject.Id);
            if (first != null)
                return first;
            var newTag = context.TagEntities.Create();
            newTag.Body = domainObject.Body;
            newTag.Title = domainObject.Title;
            newTag.CreateDateUtc = domainObject.CreateDateUtc;
            return newTag;
        }
    }
}