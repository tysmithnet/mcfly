using System;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Core;

namespace McFly
{
    [Export(typeof(IBreakpointFacade))]
    public class BreakpointFacade : IBreakpointFacade
    {
        [Import]
        public IDbgEngProxy DbgEngProxy { get; set; }

        private static readonly int[] ValidLengths = {1, 2, 4, 8};

        public void SetBreakpointByMask(string breakpointMask)
        {
            DbgEngProxy.Execute($"bm {breakpointMask}");
        }

        public void SetReadAccessBreakpoint(int length, ulong address)
        {
            ValidateLength(length);
            DbgEngProxy.Execute($"ba r{length} {address:X}");
        }

        public void SetWriteAccessBreakpoint(int length, ulong address)
        {
            ValidateLength(length);
            DbgEngProxy.Execute($"ba w{length} {address:X}");
        }

        public void ClearBreakpoints()
        {
            DbgEngProxy.Execute($"bc *");
        }

        private static void ValidateLength(int length)
        {
            if(!ValidLengths.Contains(length))
                throw new ArgumentOutOfRangeException("Access breakpoints can only have lengths of 1, 2, 4, or 8 bytes");
        }
    }
}