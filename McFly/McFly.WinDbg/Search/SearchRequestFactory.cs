// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="SearchPlanFactory.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace McFly.WinDbg.Search
{
    /// <summary>
    ///     Default search request implementation
    ///     It will split the input on | and use the parts as inputs for search filters
    /// </summary>
    /// <seealso cref="ISearchRequestFactory" />
    [Export(typeof(ISearchRequestFactory))]
    internal class SearchRequestFactory : ISearchRequestFactory
    {
        /// <summary>
        ///     Creates a search request from command line arguments
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>ISearchPlan.</returns>
        /// <exception cref="ArgumentNullException">args</exception>
        /// <exception cref="ArgumentOutOfRangeException">You must at least specify the index to use</exception>
        public ISearchRequest Create(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (args.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(args), "You must at least specify the index to use");

            var index = args[0];

            var list = new List<SearchFilter>();

            // split the args on |
            // each arg in the ranges becomes filter args
            for (var i = 1; i < args.Length; i++)
            {
                var arg = args[i];

                if (arg == "|") continue;
                var filter = new SearchFilter
                {
                    Command = arg,
                    Args = new List<string>()
                };
                for (var j = i + 1; j < args.Length && args[j] != "|"; j++)
                {
                    filter.Args.Add(args[j]);
                    i++;
                }

                list.Add(filter);
            }

            return new SearchRequest(index, list);
        }
    }
}