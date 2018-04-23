using McFly.Core.Registers;
using McFly.Debugger;

namespace McFly
{
    public interface IRegisterEngine
    {
        byte[] GetRegisterValue(int threadId, Register register, IDebugRegisters2 registers,
            IDebugEngineProxy debugEngine);
    }
}