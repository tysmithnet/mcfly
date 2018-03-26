// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-19-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="IndexOptions.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using CommandLine;

namespace McFly
{
    /// <summary>
    ///     Class IndexOptions.
    /// </summary>
    public class IndexOptions
    {
        /// <summary>
        ///     Gets or sets the memory ranges.
        /// </summary>
        /// <value>The memory ranges.</value>
        [Option('m', "memory", HelpText = "Memory to index", Required = false)]
        public IEnumerable<string> MemoryRanges { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        /// <value>The start.</value>
        [Option('s', "start", HelpText = "Starting frame", Required = false)]
        public string Start { get; set; }

        /// <summary>
        ///     Gets or sets the end.
        /// </summary>
        /// <value>The end.</value>
        [Option('e', "end", HelpText = "Ending frame", Required = false)]
        public string End { get; set; }

        /// <summary>
        ///     Gets or sets the breakpoint masks.
        /// </summary>
        /// <value>The breakpoint masks.</value>
        [Option("bm",
            HelpText = "Breakpoint masks, e.g. -bm kerne32!createprocess* user32!* mycustommodule!myfancyfunction",
            Required = false)]
        public IEnumerable<string> BreakpointMasks { get; set; }

        /// <summary>
        ///     Gets or sets the access breakpoints.
        /// </summary>
        /// <value>The access breakpoints.</value>
        [Option("ba", HelpText = "Access breakpoints, e.g -ba rw:abc123 r:def345 w:ababa", Required = false)]
        public IEnumerable<string> AccessBreakpoints { get; set; }

        /// <summary>
        ///     Gets or sets the step.
        /// </summary>
        /// <value>The step.</value>
        [Option("step", HelpText = "Number of instructions to record after a break", Required = false)]
        public int Step { get; set; }
    }
}