// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugInputCallbacks.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.Debugger
{
    /// <summary>
    ///     Interface IDebugInputCallbacks
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9f50e42c-f136-499e-9a97-73036c94ed2d")]
    public interface IDebugInputCallbacks
    {
        /// <summary>
        ///     Starts the input.
        /// </summary>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int StartInput(
            [In] uint BufferSize);

        /// <summary>
        ///     Ends the input.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int EndInput();
    }
}