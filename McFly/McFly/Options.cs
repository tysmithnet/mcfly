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
        [Option("serverdll", HelpText = "Location on disk of the McFly.Server.dll", Required = true)]
        public string ServerDll { get; set; }
    }

    public class ConfigOptions
    {
        [Option('k', "key", HelpText = "Key for the config setting", Required = true)]
        public string Key { get; set; }

        [Option('v', "value", HelpText = "Value for the config setting", Required = true)]
        public string Value { get; set; }
    }
}
