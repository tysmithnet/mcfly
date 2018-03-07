// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugOutputCallbacks.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.Debugger
{
    /// <summary>
    ///     Interface IDebugOutputCallbacks
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4bf58045-d654-4c40-b0af-683090f356dc")]
    public interface IDebugOutputCallbacks
    {
        /// <summary>
        ///     Outputs the specified mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <param name="Text">The text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Output(
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Text);
    }
}