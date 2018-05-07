// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 05-06-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-06-2018
// ***********************************************************************
// <copyright file="IExecuteWrapper.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.WinDbg
{
    /// <summary>
    ///     Represents an object that can run a command like you would in WinDbg
    /// </summary>
    internal interface IExecuteWrapper
    {
        /// <summary>
        ///     Executes the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>The output of the command</returns>
        string Execute(string cmd);
    }
}