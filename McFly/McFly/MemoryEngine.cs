using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;
using McFly.Debugger;

namespace McFly
{

    public class MemoryEngine
    {
        public byte[] ReadMemory(ulong start, ulong end, IDebugDataSpaces dataSpaces, bool is32Bit)
        {
            var length = start < end ? end - start : start - end;
            var buffer = new byte[length];
            if (is32Bit)
            {
                start = start < end ? start : end;
                
            }
            else
            {
                start = start < end ? end : start;
            }
            int hr = dataSpaces.ReadVirtual(start, buffer, buffer.Length.ToUInt(), out var bytesRead);
            if (hr != 0)
                throw new ApplicationException($"Unable to read virtual memory at {start:X16}, error code: {hr}");

            return buffer.Take(bytesRead.ToInt()).ToArray(); // todo: bounds checking
        }
    }
}
