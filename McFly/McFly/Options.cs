using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace McFly
{   
    public class InitOptions
    {   
        public string ProjectName { get; set; }
    }

    public class StartOptions
    {
        [Option('l', "launcher", HelpText = "Location on disk of launch.bat", Required = true)]
        public string LauncherPath { get; set; }
    }

    public class ConfigOptions
    {
        [Option('l', "list", HelpText = "List the current settings and their values", SetName = "list")]
        public bool ShouldList { get; set; }

        [Option('k', "key", HelpText = "Key for the config setting", SetName = "set")]
        public string Key { get; set; }

        [Option('v', "value", HelpText = "Value for the config setting", SetName = "set")]
        public string Value { get; set; }
    }
}
