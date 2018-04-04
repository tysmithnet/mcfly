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

namespace McFly.Search
{
    /// <summary>
    /// Interface ISearchPlan
    /// </summary>
    public interface ISearchPlan
    {
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>The index.</value>
        string Index { get; }
        /// <summary>
        /// Gets the search filters.
        /// </summary>
        /// <value>The search filters.</value>
        IEnumerable<SearchFilter> SearchFilters { get; }
    }
}