using CommandLine;

namespace McFly
{
    public class InitOptions
    {   
        [Option('n', "name", HelpText = "Name of the project to create", Required = true)]
        public string ProjectName { get; set; }

        [Option('s', "start", HelpText = "Lowest possible frame to consider during execution")]
        public string StartFrame { get; set; }

        [Option('e', "end", HelpText = "Highest possible frame to consider during execution")]
        public string EndFrame { get; set; }
    }
}