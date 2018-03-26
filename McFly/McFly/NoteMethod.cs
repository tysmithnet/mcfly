// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-11-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="NoteMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using CommandLine;

namespace McFly
{
    /// <summary>
    ///     Class NoteMethod.
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [ExcludeFromCodeCoverage]
    internal class NoteMethod : IMcFlyMethod
    {
        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        public Settings Settings { get; set; }

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        public IDebugEngineProxy DebugEngineProxy { get; set; }

        public HelpInfo HelpInfo { get; } = new HelpInfo
        (
            "note", "Take notes on the trace", null, null, null
        );

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            Parser.Default.ParseArguments<AddNoteOptions>(args)
                .WithParsed(options => { });
        }
    }

    /// <summary>
    ///     Class AddNoteOptions.
    /// </summary>
    [Verb("add", HelpText = "Add a note to the current position")]
    internal class AddNoteOptions
    {
        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
    }
}