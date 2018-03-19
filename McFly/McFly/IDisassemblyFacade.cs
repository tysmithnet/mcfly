using System.Collections.Generic;

namespace McFly
{
    public interface IDisassemblyFacade
    {
        IEnumerable<DisassemblyLine> GetDisassemblyLines(int numInstructions);
        IEnumerable<DisassemblyLine> GetDisassemblyLines(int threadId, int numInstructions);
    }
}