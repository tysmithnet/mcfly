// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="SearchPlan.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;

namespace McFly.WinDbg.Search
{
    /// <summary>
    ///     Default implementation of search request.
    /// </summary>
    /// <seealso cref="ISearchRequest" />
    /// <seealso cref="ISearchRequest" />
    public class SearchRequest : ISearchRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SearchRequest" /> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="searchFilters">The search filters.</param>
        public SearchRequest(string index, IEnumerable<SearchFilter> searchFilters)
        {
            Index = index;
            _searchFilters = searchFilters.ToList();
        }

        /// <summary>
        ///     The search filters
        /// </summary>
        private readonly List<SearchFilter> _searchFilters;

        /// <summary>
        ///     Adds a search filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public void AddSearchFilter(SearchFilter filter)
        {
            _searchFilters.Add(filter);
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
    }
}