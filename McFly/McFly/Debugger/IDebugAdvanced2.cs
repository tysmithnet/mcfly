// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugAdvanced2.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace McFly.Debugger
{
    /// <summary>
    ///     Interface IDebugAdvanced2
    /// </summary>
    /// <seealso cref="McFly.Debugger.IDebugAdvanced" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("716d14c9-119b-4ba5-af1f-0890e672416a")]
    public interface IDebugAdvanced2 : IDebugAdvanced
    {
        /* IDebugAdvanced */

        /// <summary>
        ///     Gets the thread context.
        /// </summary>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Sets the thread context.
        /// </summary>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        /* IDebugAdvanced2 */

        /// <summary>
        ///     Requests the specified request.
        /// </summary>
        /// <param name="Request">The request.</param>
        /// <param name="inBuffer">The in buffer.</param>
        /// <param name="InBufferSize">Size of the in buffer.</param>
        /// <param name="outBuffer">The out buffer.</param>
        /// <param name="OutBufferSize">Size of the out buffer.</param>
        /// <param name="OutSize">Size of the out.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Request(
            [In] DEBUG_REQUEST Request,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] inBuffer,
            [In] int InBufferSize,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)]
            byte[] outBuffer,
            [In] int OutBufferSize,
            [Out] out int OutSize);

        /// <summary>
        ///     Gets the source file information.
        /// </summary>
        /// <param name="Which">The which.</param>
        /// <param name="SourceFile">The source file.</param>
        /// <param name="Arg64">The arg64.</param>
        /// <param name="Arg32">The arg32.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="InfoSize">Size of the information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSourceFileInformation(
            [In] DEBUG_SRCFILE Which,
            [In] [MarshalAs(UnmanagedType.LPStr)] string SourceFile,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        /// <summary>
        ///     Finds the source file and token.
        /// </summary>
        /// <param name="StartElement">The start element.</param>
        /// <param name="ModAddr">The mod addr.</param>
        /// <param name="File">The file.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="FileTokenSize">Size of the file token.</param>
        /// <param name="FoundElement">The found element.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="FoundSize">Size of the found.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int FindSourceFileAndToken(
            [In] uint StartElement,
            [In] ulong ModAddr,
            [In] [MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] int FileTokenSize,
            [Out] out int FoundElement,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);

        /// <summary>
        ///     Gets the symbol information.
        /// </summary>
        /// <param name="Which">The which.</param>
        /// <param name="Arg64">The arg64.</param>
        /// <param name="Arg32">The arg32.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="InfoSize">Size of the information.</param>
        /// <param name="StringBuffer">The string buffer.</param>
        /// <param name="StringBufferSize">Size of the string buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolInformation(
            [In] DEBUG_SYMINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)]
            byte[] buffer,
            [In] int BufferSize,
            [Out] out int InfoSize,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder StringBuffer,
            [In] int StringBufferSize,
            [Out] out int StringSize);

        /// <summary>
        ///     Gets the system object information.
        /// </summary>
        /// <param name="Which">The which.</param>
        /// <param name="Arg64">The arg64.</param>
        /// <param name="Arg32">The arg32.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="InfoSize">Size of the information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSystemObjectInformation(
            [In] DEBUG_SYSOBJINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)]
            byte[] buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);
    }
}