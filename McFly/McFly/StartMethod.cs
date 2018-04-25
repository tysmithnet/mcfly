// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-06-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-24-2018
// ***********************************************************************
// <copyright file="StartMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace McFly
{
    /// <summary>
    /// Class StartMethod.
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    public class StartMethod : IMcFlyMethod
    {
        /// <summary>
        /// Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            if (string.IsNullOrWhiteSpace(Settings.ServerExePath))
            {
                Log.Error("Start called but no launcher path was set. Check the settings file.");
                return;
            }

            if (!File.Exists(Settings.ServerExePath))
            {
                Log.Error($"Start called but could not find file: {Settings.ServerExePath}");
                return;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = Settings.ServerExePath,
                CreateNoWindow = false,
                Environment = {{"ConnectionString", Settings.ConnectionString}},
                UseShellExecute = false
            };
            var p = System.Diagnostics.Process.Start(startInfo);
        }

        /// <summary>
        /// Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("start")
            .SetDescription("Start the local server")
            .Build();

        /// <summary>
        /// Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import(typeof(IDebugEngineProxy))]
        private IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>The log.</value>
        [Import(typeof(ILog))]
        private ILog Log { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import(typeof(Settings))]
        private Settings Settings { get; set; }
    }
}