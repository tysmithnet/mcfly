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

namespace McFly.WinDbg
{
    /// <summary>
    ///     Interface for all McFly extension commands
    /// </summary>
    /// <seealso cref="IInjectable" />
    public interface IMcFlyMethod : IInjectable
    {
        /// <summary>
        ///     Perform the actions of the method using the provided arguments from the client
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        void Process(string[] args);

        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        HelpInfo HelpInfo { get; }
    }
}