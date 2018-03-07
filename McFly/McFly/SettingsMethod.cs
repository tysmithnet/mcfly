// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-06-2018
//
// Last Modified By : master
// Last Modified On : 03-06-2018
// ***********************************************************************
// <copyright file="SettingsMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Threading.Tasks;
using CommandLine;

namespace McFly
{
    /// <summary>
    ///     Class SettingsMethod.
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    public class SettingsMethod : IMcFlyMethod
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; } = "settings";

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            Parser.Default.ParseArguments<ReloadOptions>(args).WithParsed(r => { McFlyExtension.PopulateSettings(); });
        }
    }

    /// <summary>
    ///     Class ReloadOptions.
    /// </summary>
    [Verb("reload", HelpText = "Reload the settings from the settings file")]
    public class ReloadOptions
    {
    }
}