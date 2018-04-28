// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="NoteCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Base abstraction for a search criterion that operates on notes
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.ICriterion" />
    public abstract class NoteCriterion : ICriterion
    {
        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public abstract object Accept(ICriterionVisitor visitor);
    }
}