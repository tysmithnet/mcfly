using System.ComponentModel.Composition;
using McFly.Core;

namespace McFly
{
    [Export(typeof(IBreakpointFacade))]
    public class BreakpointFacade : IBreakpointFacade
    {
        [Import]
        public IDbgEngProxy DbgEngProxy { get; set; }

        public void SetCurrentPosition(Position startingPosition)
        {
            DbgEngProxy.Execute($"!tt {startingPosition}");
        }

        public void SetBreakpointByMask(string breakpointMask)
        {
            DbgEngProxy.Execute($"bm {breakpointMask}");
        }

        public void SetReadAccessBreakpoint(int length, ulong address)
        {
            DbgEngProxy.Execute($"ba r{length} {address}");
        }

        public void SetWriteAccessBreakpoint(int length, ulong address)
        {
            DbgEngProxy.Execute($"ba w{length} {address}");
        }

        public void ClearBreakpoints()
        {
            DbgEngProxy.Execute($"bc *");
        }


    }
}