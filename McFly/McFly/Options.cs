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
}
