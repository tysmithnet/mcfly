// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugEventCallbacks.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.Native
{
    /// <summary>
    ///     Interface IDebugEventCallbacks
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("337be28b-5036-4d72-b6bf-c45fbb9f2eaa")]
    public interface IDebugEventCallbacks
    {
        /// <summary>
        ///     Gets the interest mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetInterestMask(
            [Out] out DEBUG_EVENT Mask);

        /// <summary>
        ///     Breakpoints the specified bp.
        /// </summary>
        /// <param name="Bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Breakpoint(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugBreakpoint Bp);

        /// <summary>
        ///     Exceptions the specified exception.
        /// </summary>
        /// <param name="Exception">The exception.</param>
        /// <param name="FirstChance">The first chance.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Exception(
            [In] ref EXCEPTION_RECORD64 Exception,
            [In] uint FirstChance);

        /// <summary>
        ///     Creates the thread.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="DataOffset">The data offset.</param>
        /// <param name="StartOffset">The start offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateThread(
            [In] ulong Handle,
            [In] ulong DataOffset,
            [In] ulong StartOffset);

        /// <summary>
        ///     Exits the thread.
        /// </summary>
        /// <param name="ExitCode">The exit code.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ExitThread(
            [In] uint ExitCode);

        /// <summary>
        ///     Creates the process.
        /// </summary>
        /// <param name="ImageFileHandle">The image file handle.</param>
        /// <param name="Handle">The handle.</param>
        /// <param name="BaseOffset">The base offset.</param>
        /// <param name="ModuleSize">Size of the module.</param>
        /// <param name="ModuleName">Name of the module.</param>
        /// <param name="ImageName">Name of the image.</param>
        /// <param name="CheckSum">The check sum.</param>
        /// <param name="TimeDateStamp">The time date stamp.</param>
        /// <param name="InitialThreadHandle">The initial thread handle.</param>
        /// <param name="ThreadDataOffset">The thread data offset.</param>
        /// <param name="StartOffset">The start offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateProcess(
            [In] ulong ImageFileHandle,
            [In] ulong Handle,
            [In] ulong BaseOffset,
            [In] uint ModuleSize,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ModuleName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ImageName,
            [In] uint CheckSum,
            [In] uint TimeDateStamp,
            [In] ulong InitialThreadHandle,
            [In] ulong ThreadDataOffset,
            [In] ulong StartOffset);

        /// <summary>
        ///     Exits the process.
        /// </summary>
        /// <param name="ExitCode">The exit code.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ExitProcess(
            [In] uint ExitCode);

        /// <summary>
        ///     Loads the module.
        /// </summary>
        /// <param name="ImageFileHandle">The image file handle.</param>
        /// <param name="BaseOffset">The base offset.</param>
        /// <param name="ModuleSize">Size of the module.</param>
        /// <param name="ModuleName">Name of the module.</param>
        /// <param name="ImageName">Name of the image.</param>
        /// <param name="CheckSum">The check sum.</param>
        /// <param name="TimeDateStamp">The time date stamp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int LoadModule(
            [In] ulong ImageFileHandle,
            [In] ulong BaseOffset,
            [In] uint ModuleSize,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ModuleName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ImageName,
            [In] uint CheckSum,
            [In] uint TimeDateStamp);

        /// <summary>
        ///     Unloads the module.
        /// </summary>
        /// <param name="ImageBaseName">Name of the image base.</param>
        /// <param name="BaseOffset">The base offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int UnloadModule(
            [In] [MarshalAs(UnmanagedType.LPStr)] string ImageBaseName,
            [In] ulong BaseOffset);

        /// <summary>
        ///     Systems the error.
        /// </summary>
        /// <param name="Error">The error.</param>
        /// <param name="Level">The level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SystemError(
            [In] uint Error,
            [In] uint Level);

        /// <summary>
        ///     Sessions the status.
        /// </summary>
        /// <param name="Status">The status.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SessionStatus(
            [In] DEBUG_SESSION Status);

        /// <summary>
        ///     Changes the state of the debuggee.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Argument">The argument.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ChangeDebuggeeState(
            [In] DEBUG_CDS Flags,
            [In] ulong Argument);

        /// <summary>
        ///     Changes the state of the engine.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Argument">The argument.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ChangeEngineState(
            [In] DEBUG_CES Flags,
            [In] ulong Argument);

        /// <summary>
        ///     Changes the state of the symbol.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Argument">The argument.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ChangeSymbolState(
            [In] DEBUG_CSS Flags,
            [In] ulong Argument);
    }
}