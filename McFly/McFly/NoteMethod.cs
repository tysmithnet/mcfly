// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-11-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-25-2018
// ***********************************************************************
// <copyright file="NoteMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("note")
            .SetDescription("Take notes on the trace")
            .AddSubcommand(new HelpInfoBuilder()
                .SetName("add")
                .SetDescription("Add notes")
                .AddExample("!mf note add \"Encryption begin\"", "Adds a note to the current frame")
                .Build())
            .AddExample("!mf note", "Shows all notes on the current frame")
            .Build();

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            if (args == null)
                throw new NullReferenceException(nameof(args));
            if (!args.Any())
            {
                // list notes
            }
            else
            {
                var command = args[0];
                switch (command)
                {
                    case "add":
                        var addOptions = ExtractAddOptions(args.Skip(1));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown subcommand {command}");
                }
            }
        }

        protected internal AddNoteOptions ExtractAddOptions(IEnumerable<string> args)
        {
            var options = new AddNoteOptions();
            var arr = args.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                var ptr = arr[i];

                switch (ptr)
                {
                    case "-a":
                    case "--all":
                        options.IsAllThreadsAtPosition = true;
                        break;
                    default:
                        if (options.Text == null)
                            options.Text = ptr;
                        else
                            throw new ArgumentException("Found more than 1 note body");
                        break;
                }
            }
            return options;
        }
    }

    /// <summary>
    ///     Class AddNoteOptions.
    /// </summary>
    internal class AddNoteOptions
    {
        public bool IsAllThreadsAtPosition { get; set; }
        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Text { get; set; }
    }
}