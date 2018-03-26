using System.Collections.Generic;

namespace McFly
{
    public class HelpInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Switches { get; set; }
        public Dictionary<string, string> Examples { get; set; }
        public HelpInfo[] Subcommands { get; set; }
    }
}