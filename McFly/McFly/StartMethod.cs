// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-06-2018
//
// Last Modified By : master
// Last Modified On : 03-07-2018
// ***********************************************************************
// <copyright file="StartMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;

namespace McFly
{
    /// <summary>
    ///     Class StartMethod.
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    public class StartMethod : IMcFlyMethod
    {
        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import(typeof(Settings))]
        private Settings Settings { get; set; }

        /// <summary>
        ///     Gets or sets the log.
        /// </summary>
        /// <value>The log.</value>
        [Import(typeof(ILog))]
        private ILog Log { get; set; }

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import(typeof(IDbgEngProxy))]
        private IDbgEngProxy DbgEngProxy { get; set; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; } = "start";

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            if (string.IsNullOrWhiteSpace(Settings.LauncherPath))
            {
                Log.Error("Start called but no launcher path was set. Check the settings file.");
                return;
            }
            if (!File.Exists(Settings.LauncherPath))
            {
                Log.Error($"Start called but could not find file: {Settings.LauncherPath}");
                return;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = Settings.LauncherPath,
                CreateNoWindow = false,
                Environment = {{"ConnectionString", Settings.ConnectionString}},
                UseShellExecute = false
            };
            var p = System.Diagnostics.Process.Start(startInfo);
        }
    }
}