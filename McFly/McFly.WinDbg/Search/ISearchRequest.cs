// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="ISearchPlan.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace McFly.WinDbg.Search
{
    /// <summary>
    ///     Represents a request for search results from some index
    /// </summary>
    public interface ISearchRequest
    {
        /// <summary>
        ///     Gets the index to search in
        /// </summary>
        /// <example>frame</example>
        /// <value>The index.</value>
        string Index { get; }

        /// <summary>
        ///     Gets the search filters that make up the request. 
        /// </summary>
        /// <value>The search filters.</value>
        IEnumerable<SearchFilter> SearchFilters { get; }
    }
}