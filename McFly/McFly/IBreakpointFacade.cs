// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-18-2018
// ***********************************************************************
// <copyright file="IBreakpointFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly
{
    /// <summary>
    ///     Facade over managing breakpoints
    /// </summary>
    public interface IBreakpointFacade : IInjectable
    {
        /// <summary>
        ///     Sets the breakpoint by mask.
        /// </summary>
        /// <param name="breakpointMask">The breakpoint mask.</param>
        void SetBreakpointByMask(string breakpointMask);

        /// <summary>
        ///     Sets the read access breakpoint.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="address">The address.</param>
        void SetReadAccessBreakpoint(int length, ulong address);

        /// <summary>
        ///     Sets the write access breakpoint.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="address">The address.</param>
        void SetWriteAccessBreakpoint(int length, ulong address);

        /// <summary>
        ///     Clears the breakpoints.
        /// </summary>
        void ClearBreakpoints();
    }
}