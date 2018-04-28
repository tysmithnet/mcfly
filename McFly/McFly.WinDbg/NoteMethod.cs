// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-11-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="NoteMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Class NoteMethod.
    /// </summary>
    /// <seealso cref="IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    internal class NoteMethod : IMcFlyMethod
    {
        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NullReferenceException">args</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
                        AddNote(addOptions);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown subcommand {command}");
                }
            }
        }

        /// <summary>
        ///     Adds the note.
        /// </summary>
        /// <param name="addOptions">The add options.</param>
        protected internal void AddNote(AddNoteOptions addOptions)
        {
            var positions = TimeTravelFacade.Positions();
            var current = positions.CurrentThreadResult;
            if (addOptions.IsAllThreadsAtPosition) // todo: extract methods
            {
                var threadIds = positions.Select(x => x.ThreadId);
                ServerClient.AddNote(current.Position, threadIds, addOptions.Text);
            }
            else
            {
                ServerClient.AddNote(current.Position, new[] {current.ThreadId}, addOptions.Text);
            }
        }

        /// <summary>
        ///     Extracts the add options.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>AddNoteOptions.</returns>
        /// <exception cref="ArgumentException">Found more than 1 note body</exception>
        protected internal AddNoteOptions ExtractAddOptions(IEnumerable<string> args)
        {
            var options = new AddNoteOptions();
            var arr = args.ToArray();

            for (var i = 0; i < arr.Length; i++)
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
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        public Settings Settings { get; set; }

        /// <summary>
        ///     Gets or sets the server client.
        /// </summary>
        /// <value>The server client.</value>
        [Import]
        protected internal IServerClient ServerClient { get; set; }

        /// <summary>
        ///     Gets or sets the time travel facade.
        /// </summary>
        /// <value>The time travel facade.</value>
        [Import]
        protected internal ITimeTravelFacade TimeTravelFacade { get; set; }
    }
}