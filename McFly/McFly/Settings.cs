// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-25-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="Settings.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;

namespace McFly
{
    /// <summary>
    ///     Class Settings.
    /// </summary>
    /// <seealso cref="McFly.ISettings" />
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
        public string ServerExePath { get; set; }

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