// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="ISearchCriterionConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Server.Contract;
using McFly.Server.Data.Search;

namespace McFly.Server.Search
{
    /// <summary>
    ///     Interface ISearchCriterionConverter
    /// </summary>
    internal interface ISearchCriterionConverter
    {
        /// <summary>
        ///     Determines whether this instance can convert the specified conversion type.
        /// </summary>
        /// <param name="conversionType">Type of the conversion.</param>
        /// <returns><c>true</c> if this instance can convert the specified conversion type; otherwise, <c>false</c>.</returns>
        bool CanConvert(SearchCriterionDto conversionType);

        /// <summary>
        ///     Converts the specified search criterion dto.
        /// </summary>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns>ICriterion.</returns>
        ICriterion Convert(SearchCriterionDto searchCriterionDto);
    }
}