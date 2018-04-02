// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugOutputCallbacksWide.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.Native
{
    /// <summary>
    ///     Interface IDebugOutputCallbacksWide
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4c7fd663-c394-4e26-8ef1-34ad5ed3764c")]
    public interface IDebugOutputCallbacksWide
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
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Text);
    }
}