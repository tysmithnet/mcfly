using System;
using System.Collections.Generic;
using System.Text;

namespace McFly.Core
{
    public class StackFrame
    {
        public StackFrame(ulong stackPointer, ulong returnAddress, string module, string functionName, uint offset)
        {
            StackPointer = stackPointer;
            ReturnAddress = returnAddress;
            Module = module;
            FunctionName = functionName;
            Offset = offset;
        }

        public ulong StackPointer { get; set; }
        public ulong ReturnAddress { get; set; }
        public string Module { get; set; }
        public string FunctionName { get; set; }
        public uint Offset { get; set; }
    }
}
