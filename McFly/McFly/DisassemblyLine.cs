using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly
{
    internal class DisassemblyLine
    {
        public ulong InstructionAddress { get; }
        public byte[] OpCode { get; }
        public string OpCodeMnemonic { get;  }
        public string DisassemblyNote { get;}

        public DisassemblyLine(ulong instructionAddress, byte[] opCode, string opCodeMnemonic, string disassemblyNote)
        {
            InstructionAddress = instructionAddress;
            OpCode = opCode ?? throw new ArgumentNullException(nameof(opCode));
            OpCodeMnemonic = opCodeMnemonic ?? throw new ArgumentNullException(nameof(opCodeMnemonic));
            DisassemblyNote = disassemblyNote ?? throw new ArgumentNullException(nameof(disassemblyNote));
        }
    }
}
