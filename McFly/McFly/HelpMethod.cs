using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace McFly
{
    public class HelpMethod : IMcFlyMethod      // todo: rename to command
    {
        public HelpInfo HelpInfo { get; } = new HelpInfo
        {
            Name = "help",
            Description = "Get help and find commands",
            Switches = new Dictionary<string, string>()
            {
                ["-c, --command command"] = "Get help on a specific command",
                ["-s, --search searchterm"] = "Search for commands that match the given term"
            },
            Examples = new Dictionary<string, string>()
            {
                ["!mf help"] = "Get listing of commands",
                ["!mf help -c index"] = "Get help for the index command",
                ["!mf help -s breakpoint"] = "Find commands that match \"breakpoint\""
            }
        };

        [ImportMany]
        protected internal IMcFlyMethod[] Methods { get; set; }

        [Import]
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }

        

        public void Process(string[] args)
        {
            if (IsEmptyArgs(args))
            {
                string commandListing = GetCommandListing();
                DebugEngineProxy.WriteLine(commandListing);
            }
        }

        private string GetCommandListing()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Methods.Length} Available commands:");

            foreach (var mcFlyMethod in Methods)
            {
                sb.AppendLine($"{mcFlyMethod.HelpInfo.Name.PadRight(24)} {mcFlyMethod.HelpInfo.Description}");
            }

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
