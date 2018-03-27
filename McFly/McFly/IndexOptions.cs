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
using McFly.Core;

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
        public IEnumerable<MemoryRange> MemoryRanges { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        /// <value>The start.</value>
        public Position Start { get; set; }

        /// <summary>
        ///     Gets or sets the end.
        /// </summary>
        /// <value>The end.</value>
        public Position End { get; set; }

        /// <summary>
        ///     Gets or sets the breakpoint masks.
        /// </summary>
        /// <value>The breakpoint masks.</value>
        public IEnumerable<BreakpointMask> BreakpointMasks { get; set; }

        /// <summary>
        ///     Gets or sets the access breakpoints.
        /// </summary>
        /// <value>The access breakpoints.</value>
        public IEnumerable<AccessBreakpoint> AccessBreakpoints { get; set; }

        /// <summary>
        ///     Gets or sets the step.
        /// </summary>
        /// <value>The step.</value>
        public int Step { get; set; }
    }
}