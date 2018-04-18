// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="ISearchPlanFactory.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Search
{
    /// <summary>
    ///     Interface ISearchPlanFactory
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface ISearchPlanFactory : IInjectable
    {
        /// <summary>
        ///     Creates the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>ISearchPlan.</returns>
        ISearchPlan Create(string[] args);
    }
}