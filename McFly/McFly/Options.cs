using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace McFly
{
    [Verb("start", HelpText = "Start the server")]
    public class InitOptions
    {
        public string ConnectionString { get; set; }
    }
}
