using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace McFly
{
    public class IndexOptions
    {
        [Option('m', "memory", HelpText = "Memory to index", Required = false)]
        public IEnumerable<string> MemoryRanges { get; set; }

        [Option('s', "start", HelpText = "Starting frame", Required = false)]
        public string Start { get; set; }

        [Option('e', "end", HelpText = "Ending frame", Required = false)]
        public string End { get; set; }

        [Option("bm", HelpText = "Breakpoint masks", Required = false)]
        public IEnumerable<string> BreakpointMasks { get; set; }

        [Option("br", HelpText = "Read access breakpoints", Required = false)]
        public IEnumerable<string> ReadBreakpoints { get; set; }

        [Option("bw", HelpText = "Write access breakpoints", Required = false)]
        public IEnumerable<string> WriteBreakpoints { get; set; }

        [Option("step", HelpText = "Number of instructions to record after a break", Required = false)]
        public int Step { get; set; }
    }
}
