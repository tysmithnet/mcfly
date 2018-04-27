// ***********************************************************************
// Assembly         : McFly.Server.Contract
// Author           : @tysmithnet
// Created          : 04-26-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="ISearchRequestVisitor.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Contract
{
    /// <summary>
    ///     Represents an object that is capable of processing the various kinds of search request criteria
    /// </summary>
    public interface ISearchRequestVisitor
    {
        /// <summary>
        ///     Visits the specified search criterion dto.
        /// </summary>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns>System.Object.</returns>
        object Visit(SearchCriterionDto searchCriterionDto);
    }
}