using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    public class HelpMethod : IMcFlyMethod // todo: rename to command
    {
        [ImportMany]
        protected internal IMcFlyMethod[] Methods { get; set; }

        [Import]
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }

        public HelpInfo HelpInfo { get; } = new HelpInfo
        (
            "help", "Get help and find commands", new Dictionary<string, string>
            {
                ["-c, --command command"] = "Get help on a specific command",
                ["-s, --search searchterm"] = "Search for commands that match the given term"
            },
            new Dictionary<string, string>
            {
                ["!mf help"] = "Get listing of commands",
                ["!mf help -c index"] = "Get help for the index command",
                ["!mf help -s breakpoint"] = "Find commands that match \"breakpoint\""
            },
            null);

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

        private string GetCommandHelp(string command)
        {
            var help = Methods.Single(x => x.HelpInfo.Name == command).HelpInfo;
            var sb = new StringBuilder();
            sb
                .AppendLine(help.Name)
                .AppendLine(help.Description)
                .AppendLine();

            if (help.Switches.Any() == true)
            {
                sb.AppendLine("Switches:");
                foreach (var keyValuePair in help.Switches)
                    sb.AppendLine($"\t{keyValuePair.Key.PadRight(32)} {keyValuePair.Value}");
            }
            if (help.Subcommands.Any() == true)
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
            if (help.Examples.Any() == true)
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

        private bool IsSingleCommand(string[] args)
        {
            return args.Length == 1 && Methods.Select(x => x.HelpInfo.Name).Contains(args[0]);
        }

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

        private bool IsEmptyArgs(string[] args)
        {
            return args == null || !args.Any() || args.All(string.IsNullOrWhiteSpace);
        }
    }
}