// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="ISearchCriterionConversionFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Server.Core;
using McFly.Server.Data.Search;

namespace McFly.Server.Search
{
    /// <summary>
    ///     Facade of search criteria
    /// </summary>
    public interface ISearchCriterionConversionFacade
    {
        /// <summary>
        ///     Converts the specified search dto.
        /// </summary>
        /// <param name="searchDto">The search dto.</param>
        /// <returns>ICriterion.</returns>
        ICriterion Convert(SearchCriterionDto searchDto);
    }
}