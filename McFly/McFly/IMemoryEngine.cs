using McFly.Debugger;

namespace McFly
{
    public interface IMemoryEngine
    {
        byte[] ReadMemory(ulong start, ulong end, IDebugDataSpaces dataSpaces, bool is32Bit);
    }
}