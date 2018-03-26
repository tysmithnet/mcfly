using System;
using System.Collections.Generic;

namespace McFly
{
    public class HelpInfo
    {
        public HelpInfo(string name, string description, Dictionary<string, string> switches,
            Dictionary<string, string> examples, HelpInfo[] subcommands)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Switches = switches ?? new Dictionary<string, string>();
            Examples = examples ?? new Dictionary<string, string>();
            Subcommands = subcommands ?? new HelpInfo[0];
        }

        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, string> Switches { get; }
        public Dictionary<string, string> Examples { get; }
        public HelpInfo[] Subcommands { get; }
    }
}