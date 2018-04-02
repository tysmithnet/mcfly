// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 03-31-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="IContextFactory.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Interface IContextFactory
    /// </summary>
    internal interface IContextFactory
    {
        /// <summary>
        ///     Gets the context.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <returns>IMcFlyContext.</returns>
        IMcFlyContext GetContext(string projectName);
    }
}