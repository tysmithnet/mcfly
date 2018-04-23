using McFly.Debugger;

namespace McFly
{
    public interface IMemoryEngine
    {
        byte[] ReadMemory(ulong low, ulong high, IDebugDataSpaces dataSpaces, bool is32Bit);
    }
}