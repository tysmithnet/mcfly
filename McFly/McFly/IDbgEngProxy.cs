using System.Collections.Generic;
using McFly.Core;

namespace McFly
{
    public interface IDbgEngProxy : IInjectable
    {
        void RunUntilBreak();
        string Execute(string command);
        RegisterSet GetRegisters(int threadId, IEnumerable<Register> registers);
    }
}