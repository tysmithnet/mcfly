// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-26-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="IBreakpoint.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.WinDbg
{
    /// <summary>
    ///     Represents a windows breakpoint set in the debugging engine
    /// </summary>
    public interface IBreakpoint
    {
        /// <summary>
        ///     Sets the breakpoint.
        /// </summary>
        /// <param name="breakpointFacade">The breakpoint facade to use to set the breakpoint.</param>
        void SetBreakpoint(IBreakpointFacade breakpointFacade);
    }
}