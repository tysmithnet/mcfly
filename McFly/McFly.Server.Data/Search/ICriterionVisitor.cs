// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="ICriterionVisitor.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Represents an object capable of visiting types of <see cref="ICriterion" /> and performing
    ///     some useful function
    /// </summary>
    public interface ICriterionVisitor
    {
        /// <summary>
        ///     Visits the specified criterion.
        /// </summary>
        /// <param name="criterion">The criterion.</param>
        /// <returns>System.Object.</returns>
        object Visit(ICriterion criterion);
    }
}