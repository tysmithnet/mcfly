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

namespace McFly.WinDbg.Search
{
    /// <summary>
    ///     Something that can transform command line arguments into a search request
    /// </summary>
    /// <seealso cref="IInjectable" />
    public interface ISearchRequestFactory : IInjectable
    {
        /// <summary>
        ///     Creates a search request from command line arguments
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>ISearchPlan.</returns>
        ISearchRequest Create(string[] args);
    }
}