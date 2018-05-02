// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-11-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="TagMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using McFly.Core;

namespace McFly.WinDbg
{
    /// <summary>
    ///     McFly method for tagging frames with helpful information
    /// </summary>
    /// <seealso cref="McFly.WinDbg.IMcFlyMethod" />
    /// <seealso cref="IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    internal sealed class TagMethod : IMcFlyMethod
    {
        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        /// <exception cref="ArgumentNullException">args</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Process(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));
            if (!args.Any())
            {
                // list tags
                var tags = ServerClient.GetRecentTags(10);
                var output = FormatTagsForOutput(tags);
                DebugEngineProxy.WriteLine(output);
            }
            else
            {
                var command = args[0];
                switch (command)
                {
                    case "add":
                        var addOptions = ExtractAddOptions(args.Skip(1));
                        AddTag(addOptions);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown subcommand {command}");
                }
            }
        }

        /// <summary>
        ///     Adds a tag.
        /// </summary>
        /// <param name="addOptions">The add options.</param>
        internal void AddTag(AddTagOptions addOptions)
        {
            var positions = TimeTravelFacade.Positions();
            var current = positions.CurrentThreadResult;
            if (addOptions.IsAllThreadsAtPosition) // todo: extract methods
            {
                var threadIds = positions.Select(x => x.ThreadId);
                ServerClient.AddTag(current.Position, threadIds, addOptions.Text);
            }
            else
            {
                ServerClient.AddTag(current.Position, new[] {current.ThreadId}, addOptions.Text);
            }
        }

        /// <summary>
        ///     Extracts the add options.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>AddNoteOptions.</returns>
        /// <exception cref="ArgumentException">Found more than 1 tag body</exception>
        internal AddTagOptions ExtractAddOptions(IEnumerable<string> args)
        {
            var options = new AddTagOptions();
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
                            throw new ArgumentException("Found more than 1 tag body");
                        break;
                }
            }

            return options;
        }

        /// <summary>
        ///     Formats the tags for output.
        /// </summary>
        /// <param name="tags">The tags.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">tags</exception>
        internal string FormatTagsForOutput(IEnumerable<Tag> tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));
            var sb = new StringBuilder();
            var list = tags.OrderBy(x => x.CreateDateUtc).ToList();
            for (var i = 0; i < list.Count(); i++)
            {
                var tag = list[i];
                sb.AppendLine($"{i + 1}. {tag.Title} - {tag.Body}");
            }

            return sb.ToString();
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
            .SetName("tag")
            .SetDescription("Place tags on the trace")
            .AddSubcommand(new HelpInfoBuilder()
                .SetName("add")
                .SetDescription("Add tags")
                .AddExample("!mf tag add \"Encryption begin\"", "Adds a tag to the current frame")
                .Build())
            .AddExample("!mf tag", "Shows all tags on the current frame")
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
        internal IServerClient ServerClient { get; set; }

        /// <summary>
        ///     Gets or sets the time travel facade.
        /// </summary>
        /// <value>The time travel facade.</value>
        [Import]
        internal ITimeTravelFacade TimeTravelFacade { get; set; }
    }
}