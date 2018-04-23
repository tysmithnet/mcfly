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
        public byte[] ReadMemory(ulong low, ulong high, IDebugDataSpaces dataSpaces, bool is32Bit)
        {
            var length = low < high ? high - low : low - high;
            var buffer = new byte[length];
            if (is32Bit)
                low = low < high ? low : high;
            else
                low = low < high ? high : low;
            var hr = dataSpaces.ReadVirtual(low, buffer, buffer.Length.ToUInt(), out var bytesRead);
            if (hr != 0)
                throw new ApplicationException($"Unable to read virtual memory at {low:X16}, error code: {hr}");

            return buffer.Take(bytesRead.ToInt()).ToArray(); // todo: bounds checking
        }
    }
}