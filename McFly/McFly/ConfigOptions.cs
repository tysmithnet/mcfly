// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-25-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="ConfigOptions.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using CommandLine;

namespace McFly
{
    /// <summary>
    ///     Class ConfigOptions.
    /// </summary>
    public class ConfigOptions
    {
        /// <summary>
        ///     Gets or sets a value indicating whether [should list].
        /// </summary>
        /// <value><c>true</c> if [should list]; otherwise, <c>false</c>.</value>
        [Option('l', "list", HelpText = "List the current settings and their values", SetName = "list")]
        public bool ShouldList { get; set; }

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        [Option('k', "key", HelpText = "Key for the config setting", SetName = "set")]
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Option('v', "value", HelpText = "Value for the config setting", SetName = "set")]
        public string Value { get; set; }
    }
}