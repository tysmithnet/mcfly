using CommandLine;

namespace McFly
{
    public class StartOptions
    {
        [Option('l', "launcher", HelpText = "Location on disk of launch.bat", Required = true)]
        public string LauncherPath { get; set; }
    }
}