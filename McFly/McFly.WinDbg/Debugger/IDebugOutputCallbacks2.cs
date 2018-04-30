// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugOutputCallbacks2.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.WinDbg.Debugger
{
    /// <summary>
    ///     Interface IDebugOutputCallbacks2
    /// </summary>
    /// <seealso cref="IDebugOutputCallbacks" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("67721fe9-56d2-4a44-a325-2b65513ce6eb")]
    public interface IDebugOutputCallbacks2 : IDebugOutputCallbacks
    {
        /* IDebugOutputCallbacks */

        /// <summary>
        ///     This method is not used.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <param name="Text">The text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int Output(
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Text);

        /* IDebugOutputCallbacks2 */

        /// <summary>
        ///     Gets the interest mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetInterestMask(
            [Out] out DEBUG_OUTCBI Mask);

        /// <summary>
        ///     Output2s the specified which.
        /// </summary>
        /// <param name="Which">The which.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Arg">The argument.</param>
        /// <param name="Text">The text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Output2(
            [In] DEBUG_OUTCB Which,
            [In] DEBUG_OUTCBF Flags,
            [In] ulong Arg,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Text);
    }
}