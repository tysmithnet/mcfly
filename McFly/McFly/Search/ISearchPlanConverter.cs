// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="ISearchPlanConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using McFly.Server.Contract;

namespace McFly.Search
{
    /// <summary>
    /// Interface ISearchPlanConverter
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    internal interface ISearchPlanConverter : IInjectable
    {
        /// <summary>
        /// Converts the specified search plan.
        /// </summary>
        /// <param name="searchPlan">The search plan.</param>
        /// <returns>SearchCriterionDto.</returns>
        SearchCriterionDto Convert(ISearchPlan searchPlan);
    }
}