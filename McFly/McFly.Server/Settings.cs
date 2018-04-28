// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-31-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="Settings.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;

namespace McFly.Server
{
    /// <summary>
    ///     Represents the settings for this application
    /// </summary>
    [Export]
    public sealed class Settings
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Settings" /> class.
        /// </summary>
        internal Settings()
        {
        }

        /// <summary>
        ///     Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; internal set; }
    }
}