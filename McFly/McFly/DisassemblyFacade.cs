// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="DisassemblyFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;

namespace McFly
{
    /// <summary>
    /// Default implementation of the disassembly facade
    /// </summary>
    /// <seealso cref="McFly.IDisassemblyFacade" />
    [Export(typeof(IDisassemblyFacade))]
    internal class DisassemblyFacade : IDisassemblyFacade
    {
        /// <summary>
        /// Gets or sets the debug engine proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        /// Di
        /// </summary>
        /// <param name="numInstructions">The number instructions.</param>
        /// <returns>IEnumerable&lt;DisassemblyLine&gt;.</returns>
        public IEnumerable<DisassemblyLine> GetDisassemblyLines(int numInstructions)
        {
            var threadId = DebugEngineProxy.GetCurrentThreadId();
            return GetDisassemblyLines(threadId, numInstructions);
        }

        /// <summary>
        /// Gets the disassembly lines.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="numInstructions">The number instructions.</param>
        /// <returns>IEnumerable&lt;DisassemblyLine&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Number of instructions must be &gt; 0</exception>
        public IEnumerable<DisassemblyLine> GetDisassemblyLines(int threadId, int numInstructions)
        {
            if (numInstructions <= 0)
                throw new ArgumentOutOfRangeException("Number of instructions must be > 0");
            var ipRegister = DebugEngineProxy.Is32Bit ? "eip" : "rip";
            var instructionText = DebugEngineProxy.Execute(threadId, $"u {ipRegister} L{numInstructions:X}");
            var matches = Regex.Matches(instructionText,
                @"(?<ip>[a-fA-F0-9`]+)\s+(?<opcode>[a-fA-F0-9]+)\s+(?<ins>\w+)\s+(?<extra>.+)?");
            var list = new List<DisassemblyLine>();
            foreach (var match in matches.Cast<Match>())
            {
                var ip = match.Groups["ip"].Success
                    ? Convert.ToUInt64(match.Groups["ip"].Value.Replace("`", ""), 16)
                    : 0;
                byte[] opcode = null;
                if (match.Groups["opcode"].Success)
                    opcode = ByteArrayBuilder.StringToByteArray(match.Groups["opcode"].Value);
                var instruction = match.Groups["ins"].Success ? match.Groups["ins"].Value : "";
                var note = match.Groups["extra"].Success ? match.Groups["extra"].Value : "";
                var newLine = new DisassemblyLine(ip, opcode, instruction, note);
                list.Add(newLine);
            }

            return list;
        }
    }
}