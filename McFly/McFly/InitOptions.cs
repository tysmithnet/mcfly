// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-25-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="InitOptions.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using CommandLine;

namespace McFly
{
    /// <summary>
    ///     Class InitOptions.
    /// </summary>
    public class InitOptions
    {
        /// <summary>
        ///     Gets or sets the name of the project.
        /// </summary>
        /// <value>The name of the project.</value>
        [Option('n', "name", Required = true)]
        public string ProjectName { get; set; }
    }
}