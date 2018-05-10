// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="ISearchPlanConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Server.Core;

namespace McFly.WinDbg.Search
{
    /// <summary>
    ///     Represents something that can convert a search request into a DTO
    ///     to send to the server
    /// </summary>
    /// <seealso cref="IInjectable" />
    public interface ISearchRequestConverter : IInjectable
    {
        /// <summary>
        ///     Converts the specified search request.
        /// </summary>
        /// <param name="searchRequest">The search request.</param>
        /// <returns>SearchCriterionDto.</returns>
        SearchCriterionDto Convert(ISearchRequest searchRequest);
    }
}