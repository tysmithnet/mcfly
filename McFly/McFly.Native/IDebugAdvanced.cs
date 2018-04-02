// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugAdvanced.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.Native
{
    /// <summary>
    ///     Interface IDebugAdvanced
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("f2df5f53-071f-47bd-9de6-5734c3fed689")]
    public interface IDebugAdvanced
    {
        /// <summary>
        ///     Gets the thread context.
        /// </summary>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Sets the thread context.
        /// </summary>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);
    }
}