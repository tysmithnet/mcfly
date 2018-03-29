// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-24-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-25-2018
// ***********************************************************************
// <copyright file="HelpMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace McFly
{
    /// <summary>
    ///     Class HelpMethod.
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    public class HelpMethod : IMcFlyMethod // todo: rename to command
    {
        /// <summary>
        ///     Gets or sets the methods.
        /// </summary>
        /// <value>The methods.</value>
        [ImportMany]
        protected internal IMcFlyMethod[] Methods { get; set; }

        /// <summary>
        ///     Gets or sets the debug engine proxy.
        /// </summary>
        /// <value>The debug engine proxy.</value>
        [Import]
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("help")
            .SetDescription("Get help and find commands")
            .AddSwitch("-c, --command command", "Get help on a specific command")
            .AddSwitch("-s, --search searchterm", "Search for commands that match the given term")
            .AddExample("!mf help", "Get listing of commands")
            .AddExample("!mf help -c index", "Get help for the index command")
            .AddExample("!mf help -s breakpoint", "Find commands that match \"breakpoint\"")
            .Build();

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            if (IsEmptyArgs(args))
            {
                var commandListing = GetCommandListing();
                DebugEngineProxy.WriteLine(commandListing);
                return;
            }
            if (IsSingleCommand(args))
            {
                var commandHelp = GetCommandHelp(args[0]);
                DebugEngineProxy.WriteLine(commandHelp);
            }
        }

        /// <summary>
        ///     Gets the command help.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>System.String.</returns>
        private string GetCommandHelp(string command)
        {
            var help = Methods.Single(x => x.HelpInfo.Name == command).HelpInfo;
            var sb = new StringBuilder();
            sb
                .AppendLine(help.Name)
                .AppendLine(help.Description)
                .AppendLine();

            if (help.Switches.Any())
            {
                sb.AppendLine("Switches:");
                foreach (var keyValuePair in help.Switches)
                    sb.AppendLine($"\t{keyValuePair.Key.PadRight(32)} {keyValuePair.Value}");
            }
            if (help.Subcommands.Any())
            {
                sb
                    .AppendLine()
                    .AppendLine("Subcommands:");
                foreach (var helpSubcommand in help.Subcommands)
                {
                    var joint = $"{command} {helpSubcommand.Name}";
                    sb.AppendLine($"\t{joint.PadRight(32)} {helpSubcommand.Description}");
                }
            }
            if (help.Examples.Any())
            {
                sb
                    .AppendLine()
                    .AppendLine("Examples:");

                var i = 1;
                foreach (var kvp in help.Examples)
                    sb
                        .AppendLine($"\tExample {i++}")
                        .AppendLine($"\t{kvp.Key}")
                        .AppendLine($"\t{kvp.Value}");
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Determines whether [is single command] [the specified arguments].
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns><c>true</c> if [is single command] [the specified arguments]; otherwise, <c>false</c>.</returns>
        private bool IsSingleCommand(string[] args)
        {
            return args.Length == 1 && Methods.Select(x => x.HelpInfo.Name).Contains(args[0]);
        }

        /// <summary>
        ///     Gets the command listing.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetCommandListing()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Methods.Length} Available commands:");

            foreach (var mcFlyMethod in Methods)
                sb.AppendLine($"{mcFlyMethod.HelpInfo.Name.PadRight(24)} {mcFlyMethod.HelpInfo.Description}");

            sb
                .AppendLine("")
                .AppendLine("Get extended help:")
                .AppendLine("!mf help command");

            return sb.ToString();
        }

        /// <summary>
        ///     Determines whether [is empty arguments] [the specified arguments].
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns><c>true</c> if [is empty arguments] [the specified arguments]; otherwise, <c>false</c>.</returns>
        private bool IsEmptyArgs(string[] args)
        {
            return args == null || !args.Any() || args.All(string.IsNullOrWhiteSpace);
        }
    }
}