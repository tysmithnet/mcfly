// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="IMcFlyMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly
{
    /// <summary>
    ///     Interface IMcFlyMethod
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface IMcFlyMethod : IInjectable
    {
        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        HelpInfo HelpInfo { get; }

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        void Process(string[] args);
    }
}