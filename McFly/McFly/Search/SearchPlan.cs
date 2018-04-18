// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="SearchPlan.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;

namespace McFly.Search
{
    /// <summary>
    ///     Class SearchPlan.
    /// </summary>
    /// <seealso cref="McFly.Search.ISearchPlan" />
    public class SearchPlan : ISearchPlan
    {
        /// <summary>
        ///     The search filters
        /// </summary>
        private readonly List<SearchFilter> _searchFilters;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SearchPlan" /> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="searchFilters">The search filters.</param>
        public SearchPlan(string index, IEnumerable<SearchFilter> searchFilters)
        {
            Index = index;
            _searchFilters = searchFilters.ToList();
        }

        /// <summary>
        ///     Gets the index.
        /// </summary>
        /// <value>The index.</value>
        /// <inheritdoc />
        public string Index { get; }

        /// <summary>
        ///     Gets the search filters.
        /// </summary>
        /// <value>The search filters.</value>
        /// <inheritdoc />
        public IEnumerable<SearchFilter> SearchFilters => _searchFilters;

        /// <summary>
        ///     Adds the search filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public void AddSearchFilter(SearchFilter filter)
        {
            _searchFilters.Add(filter);
        }
    }
}