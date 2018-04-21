using System;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Core;
using McFly.Debugger;

namespace McFly
{
    [Export(typeof(IMemoryEngine))]
    public class MemoryEngine : IMemoryEngine
    {
        public byte[] ReadMemory(ulong start, ulong end, IDebugDataSpaces dataSpaces, bool is32Bit)
        {
            var length = start < end ? end - start : start - end;
            var buffer = new byte[length];
            if (is32Bit)
                start = start < end ? start : end;
            else
                start = start < end ? end : start;
            var hr = dataSpaces.ReadVirtual(start, buffer, buffer.Length.ToUInt(), out var bytesRead);
            if (hr != 0)
                throw new ApplicationException($"Unable to read virtual memory at {start:X16}, error code: {hr}");

            return buffer.Take(bytesRead.ToInt()).ToArray(); // todo: bounds checking
        }
    }
}