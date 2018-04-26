// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-06-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-24-2018
// ***********************************************************************
// <copyright file="SettingsMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using CommandLine;
using Newtonsoft.Json;

namespace McFly
{
    /// <summary>
    /// Class SettingsMethod.
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    public class SettingsMethod : IMcFlyMethod
    {
        /// <summary>
        /// Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            if(args == null) throw new ArgumentNullException(nameof(args));
            if(args.Length != 1) throw new ArgumentOutOfRangeException(nameof(args), $"SettingsMethod expects exactly 1 argument, but was given {args.Length}");
            switch (args[0].ToLower())
            {
                case "list":
                    foreach (var settings in AllSettings)
                    {
                        DebugEngineProxy.WriteLine(settings.GetType().FullName);
                        DebugEngineProxy.WriteLine(JsonConvert.SerializeObject(settings, Formatting.Indented));
                    }

                    break;
                case "reload":
                    McFlyExtension.PopulateSettings();
                    break;
                case "open":
                    var p = System.Diagnostics.Process.Start(McFlyExtension.GetLogPath());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(args), $"Settings takes 3 commands: list, reload, or open. Found {args[0]}");
            }
        }

        /// <summary>
        /// Gets or sets all settings.
        /// </summary>
        /// <value>All settings.</value>
        [ImportMany]
        public ISettings[] AllSettings { get; set; }

        /// <summary>
        /// Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        public IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        /// Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("settings")
            .SetDescription("Manage application settings")
            .AddSubcommand(new HelpInfoBuilder()
                .SetName("list")
                .SetDescription("List the current settings and their values")
                .Build())
            .AddSubcommand(new HelpInfoBuilder()
                .SetName("open")
                .SetDescription("Opens the setting file with the default editor")
                .Build())
            .AddSubcommand(new HelpInfoBuilder()
                .SetName("reload")
                .SetDescription("Reload the settings from the settings file")
                .Build())
            .Build();
    }
}