// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="ICriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Represents a singular facet of a search request
    ///     <remarks>
    ///         This could be a register has some value or a stack trace contains a frame or any other
    ///         primitive search component
    ///     </remarks>
    /// </summary>
    public interface ICriterion
    {
        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        object Accept(ICriterionVisitor visitor);
    }
}