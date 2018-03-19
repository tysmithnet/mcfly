using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;

namespace McFly
{
    internal class DisassemblyFacade : IDisassemblyFacade
    {
        [Import]
        private IDbgEngProxy DbgEngProxy { get; set; }

        public IEnumerable<DisassemblyLine> GetDisassemblyLines(int numInstructions)
        {
            var threadId = DbgEngProxy.GetCurrentThreadId();
            return GetDisassemblyLines(threadId, numInstructions);
        }

        public IEnumerable<DisassemblyLine> GetDisassemblyLines(int threadId, int numInstructions)
        {
            if (numInstructions <= 0)
                throw new ArgumentOutOfRangeException("Number of instructions must be > 0");
            var ipRegister = DbgEngProxy.Is32Bit ? "eip" : "rip";
            var instructionText = DbgEngProxy.Execute($"u {ipRegister} L{numInstructions}");
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