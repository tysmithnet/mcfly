// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-25-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-06-2018
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
        [Option('n', "name", HelpText = "Name of the project to create", Required = true)]
        public string ProjectName { get; set; }

        /// <summary>
        ///     Gets or sets the start frame.
        /// </summary>
        /// <value>The start frame.</value>
        [Option('s', "start", HelpText = "Lowest possible frame to consider during execution")]
        public string StartFrame { get; set; }

        /// <summary>
        ///     Gets or sets the end frame.
        /// </summary>
        /// <value>The end frame.</value>
        [Option('e', "end", HelpText = "Highest possible frame to consider during execution")]
        public string EndFrame { get; set; }
    }
}