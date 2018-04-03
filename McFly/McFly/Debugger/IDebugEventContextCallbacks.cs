// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugEventContextCallbacks.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.Debugger
{
    /// <summary>
    ///     Interface IDebugEventContextCallbacks
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61a4905b-23f9-4247-b3c5-53d087529ab7")]
    public unsafe interface IDebugEventContextCallbacks
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
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Breakpoint(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugBreakpoint2 Bp,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Exceptions the specified exception.
        /// </summary>
        /// <param name="Exception">The exception.</param>
        /// <param name="FirstChance">The first chance.</param>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Exception(
            [In] ref EXCEPTION_RECORD64 Exception,
            [In] uint FirstChance,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Creates the thread.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="DataOffset">The data offset.</param>
        /// <param name="StartOffset">The start offset.</param>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateThread(
            [In] ulong Handle,
            [In] ulong DataOffset,
            [In] ulong StartOffset,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Exits the thread.
        /// </summary>
        /// <param name="ExitCode">The exit code.</param>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ExitThread(
            [In] uint ExitCode,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

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
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateProcess(
            [In] ulong ImageFileHandle,
            [In] ulong Handle,
            [In] ulong BaseOffset,
            [In] uint ModuleSize,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ImageName,
            [In] uint CheckSum,
            [In] uint TimeDateStamp,
            [In] ulong InitialThreadHandle,
            [In] ulong ThreadDataOffset,
            [In] ulong StartOffset,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Exits the process.
        /// </summary>
        /// <param name="ExitCode">The exit code.</param>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ExitProcess(
            [In] uint ExitCode,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

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
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int LoadModule(
            [In] ulong ImageFileHandle,
            [In] ulong BaseOffset,
            [In] uint ModuleSize,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ImageName,
            [In] uint CheckSum,
            [In] uint TimeDateStamp,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Unloads the module.
        /// </summary>
        /// <param name="ImageBaseName">Name of the image base.</param>
        /// <param name="BaseOffset">The base offset.</param>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int UnloadModule(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ImageBaseName,
            [In] ulong BaseOffset,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Systems the error.
        /// </summary>
        /// <param name="Error">The error.</param>
        /// <param name="Level">The level.</param>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SystemError(
            [In] uint Error,
            [In] uint Level,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

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
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ChangeDebuggeeState(
            [In] DEBUG_CDS Flags,
            [In] ulong Argument,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

        /// <summary>
        ///     Changes the state of the engine.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Argument">The argument.</param>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ChangeEngineState(
            [In] DEBUG_CES Flags,
            [In] ulong Argument,
            [In] DEBUG_EVENT_CONTEXT* Context,
            [In] uint ContextSize);

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