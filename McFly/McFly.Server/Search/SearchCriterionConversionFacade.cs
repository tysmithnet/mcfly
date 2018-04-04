// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="SearchCriterionConversionFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Server.Contract;
using McFly.Server.Data.Search;

namespace McFly.Server.Search
{
    /// <summary>
    ///     Class SearchCriterionConversionFacade.
    /// </summary>
    /// <seealso cref="McFly.Server.Search.ISearchCriterionConversionFacade" />
    [Export(typeof(ISearchCriterionConversionFacade))]
    public class SearchCriterionConversionFacade : ISearchCriterionConversionFacade
    {
        /// <summary>
        ///     Gets or sets the converters.
        /// </summary>
        /// <value>The converters.</value>
        [ImportMany]
        internal ISearchCriterionConverter[] Converters { get; set; }

        /// <summary>
        ///     Converts the specified search dto.
        /// </summary>
        /// <param name="searchDto">The search dto.</param>
        /// <returns>ICriterion.</returns>
        /// <exception cref="Exception">aslkasldknasdklnas change me!</exception>
        public ICriterion Convert(SearchCriterionDto searchDto)
        {
            var first = Converters.FirstOrDefault(c => c.CanConvert(searchDto));
            if (first == null)
                throw new Exception("aslkasldknasdklnas change me!");

            return first.Convert(searchDto);
        }
    }
}