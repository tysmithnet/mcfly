using CommandLine;

namespace McFly
{
    public class InitOptions
    {   
        [Option('n', "name", HelpText = "Name of the project to create", Required = true)]
        public string ProjectName { get; set; }
    }
}