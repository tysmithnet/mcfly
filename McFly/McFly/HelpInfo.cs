using System;
using System.Collections.Generic;

namespace McFly
{
    public class HelpInfo
    {
        internal HelpInfo()
        {
            
        }

        public HelpInfo(string name, string description, Dictionary<string, string> switches,
            Dictionary<string, string> examples, HelpInfo[] subcommands)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Switches = switches ?? new Dictionary<string, string>();
            Examples = examples ?? new Dictionary<string, string>();
            Subcommands = subcommands ?? new HelpInfo[0];
        }

        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public Dictionary<string, string> Switches { get; internal set; }
        public Dictionary<string, string> Examples { get; internal set; }
        public HelpInfo[] Subcommands { get; internal set; }
    }
}