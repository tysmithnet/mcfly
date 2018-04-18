// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="BreakpointFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace McFly
{
    /// <summary>
    ///     Default breakpoint facade implementation
    /// </summary>
    /// <seealso cref="McFly.IBreakpointFacade" />
    [Export(typeof(IBreakpointFacade))]
    public class BreakpointFacade : IBreakpointFacade
    {
        /// <summary>
        ///     The valid lengths for data access breakpoints
        /// </summary>
        private static readonly int[] ValidDataAccessLength = {1, 2, 4, 8};

        /// <summary>
        ///     Gets or sets the debug engine proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        public IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        ///     Sets the breakpoint by mask.
        /// </summary>
        /// <param name="moduleMask">The module mask.</param>
        /// <param name="functionMask">The function mask.</param>
        public void SetBreakpointByMask(string moduleMask, string functionMask)
        {
            DebugEngineProxy.Execute($"bm {moduleMask}!{functionMask}");
        }

        /// <summary>
        ///     Sets the read access breakpoint.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="address">The address.</param>
        public void SetReadAccessBreakpoint(int length, ulong address)
        {
            ValidateLength(length);
            DebugEngineProxy.Execute($"ba r{length} {address:X}");
        }

        /// <summary>
        ///     Sets the write access breakpoint.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="address">The address.</param>
        public void SetWriteAccessBreakpoint(int length, ulong address)
        {
            ValidateLength(length);
            DebugEngineProxy.Execute($"ba w{length} {address:X}");
        }

        /// <summary>
        ///     Clears the breakpoints.
        /// </summary>
        public void ClearBreakpoints()
        {
            DebugEngineProxy.Execute($"bc *");
        }

        /// <summary>
        ///     Validates the length of the requested data access breakpoint
        /// </summary>
        /// <param name="length">The length.</param>
        /// <exception cref="ArgumentOutOfRangeException">Access breakpoints can only have lengths of 1, 2, 4, or 8 bytes</exception>
        private static void ValidateLength(int length)
        {
            if (!ValidDataAccessLength.Contains(length))
                throw new ArgumentOutOfRangeException(
                    "Access breakpoints can only have lengths of 1, 2, 4, or 8 bytes");
        }
    }
}