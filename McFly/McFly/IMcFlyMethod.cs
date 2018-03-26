// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-04-2018
//
// Last Modified By : master
// Last Modified On : 03-24-2018
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
        HelpInfo HelpInfo { get; }
        
        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        void Process(string[] args);
    }
}