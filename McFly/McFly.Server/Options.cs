using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;

namespace McFly.Server
{
    public class Options
    {
        [Option('c', "connectionstring", HelpText = "Connection string for the database to use", Required = true)]
        public string ConnectionString { get; set; }
    }
}
