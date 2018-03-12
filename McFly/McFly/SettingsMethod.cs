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
using CommandLine;
using Newtonsoft.Json;

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

        [ImportMany]
        public ISettings[] AllSettings { get; set; }

        [Import]
        public IDbgEngProxy DbgEngProxy { get; set; }

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            Parser.Default.ParseArguments<ReloadOptions, ListOptions>(args)
                .WithParsed<ReloadOptions>(r =>
                {
                    McFlyExtension.PopulateSettings();
                })
                .WithParsed<ListOptions>(l =>
                {
                    foreach (var settings in AllSettings)
                    {            
                        DbgEngProxy.WriteLine(settings.GetType().FullName);
                        DbgEngProxy.WriteLine(JsonConvert.SerializeObject(settings, Formatting.Indented));
                    }
                });
        }
    }

    /// <summary>
    ///     Class ReloadOptions.
    /// </summary>
    [Verb("reload", HelpText = "Reload the settings from the settings file")]
    public class ReloadOptions
    {
    }

    [Verb("list", HelpText = "List the current settings and their values")]
    public class ListOptions
    {
        
    }
}