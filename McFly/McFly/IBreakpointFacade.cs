namespace McFly
{
    public interface IBreakpointFacade
    {
        void SetBreakpointByMask(string breakpointMask);
        void SetReadAccessBreakpoint(int length, ulong address);
        void SetWriteAccessBreakpoint(int length, ulong address);
        void ClearBreakpoints();
    }
}