// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-25-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="Settings.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;

namespace McFly
{
    /// <summary>
    ///     Class Settings.
    /// </summary>
    [Export(typeof(ISettings))]
    [Export(typeof(Settings))]
    public class Settings : ISettings
    {
        /// <summary>
        ///     Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        ///     Gets or sets the launcher path.
        /// </summary>
        /// <value>The launcher path.</value>
        public string LauncherPath { get; set; }

        /// <summary>
        ///     Gets or sets the server URL.
        /// </summary>
        /// <value>The server URL.</value>
        public string ServerUrl { get; set; }

        /// <summary>
        ///     Gets or sets the name of the project.
        /// </summary>
        /// <value>The name of the project.</value>
        public string ProjectName { get; set; }
    }
}