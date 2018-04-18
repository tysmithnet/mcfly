using McFly.Core;
using McFly.Debugger;

namespace McFly
{
    public interface IRegisterEngine
    {
        byte[] GetRegisterValue(int threadId, Register register, IDebugRegisters2 registers);
    }
}