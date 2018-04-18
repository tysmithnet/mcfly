// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="ICriterionVisitor.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Interface ICriterionVisitor
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