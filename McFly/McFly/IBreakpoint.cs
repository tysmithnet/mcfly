// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-26-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="IBreakpoint.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace McFly
{
    /// <summary>
    /// Interface IBreakpoint
    /// </summary>
    public interface IBreakpoint
    {
        /// <summary>
        /// Sets the breakpoint.
        /// </summary>
        /// <param name="breakpointFacade">The breakpoint facade.</param>
        void SetBreakpoint(IBreakpointFacade breakpointFacade);
    }
}