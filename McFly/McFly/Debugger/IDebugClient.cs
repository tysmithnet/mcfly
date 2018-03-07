// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugClient.cs" company="">
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
    ///     Interface IDebugClient
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("27fe5639-8407-4f47-8364-ee118fb08ac8")]
    public interface IDebugClient
    {
        /* IDebugClient */

        /// <summary>
        ///     Attaches the kernel.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="ConnectOptions">The connect options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int AttachKernel(
            [In] DEBUG_ATTACH Flags,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ConnectOptions);

        /// <summary>
        ///     Gets the kernel connection options.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="OptionsSize">Size of the options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetKernelConnectionOptions(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint OptionsSize);

        /// <summary>
        ///     Sets the kernel connection options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetKernelConnectionOptions(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Options);

        /// <summary>
        ///     Starts the process server.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Options">The options.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int StartProcessServer(
            [In] DEBUG_CLASS Flags,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Options,
            [In] IntPtr Reserved);

        /// <summary>
        ///     Connects the process server.
        /// </summary>
        /// <param name="RemoteOptions">The remote options.</param>
        /// <param name="Server">The server.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ConnectProcessServer(
            [In] [MarshalAs(UnmanagedType.LPStr)] string RemoteOptions,
            [Out] out ulong Server);

        /// <summary>
        ///     Disconnects the process server.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int DisconnectProcessServer(
            [In] ulong Server);

        /// <summary>
        ///     Gets the running process system ids.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="Ids">The ids.</param>
        /// <param name="Count">The count.</param>
        /// <param name="ActualCount">The actual count.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetRunningProcessSystemIds(
            [In] ulong Server,
            [Out] [MarshalAs(UnmanagedType.LPArray)] uint[] Ids,
            [In] uint Count,
            [Out] out uint ActualCount);

        /// <summary>
        ///     Gets the name of the running process system identifier by executable.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="ExeName">Name of the executable.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetRunningProcessSystemIdByExecutableName(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ExeName,
            [In] DEBUG_GET_PROC Flags,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the running process description.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="SystemId">The system identifier.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="ExeName">Name of the executable.</param>
        /// <param name="ExeNameSize">Size of the executable name.</param>
        /// <param name="ActualExeNameSize">Actual size of the executable name.</param>
        /// <param name="Description">The description.</param>
        /// <param name="DescriptionSize">Size of the description.</param>
        /// <param name="ActualDescriptionSize">Actual size of the description.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetRunningProcessDescription(
            [In] ulong Server,
            [In] uint SystemId,
            [In] DEBUG_PROC_DESC Flags,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder ExeName,
            [In] int ExeNameSize,
            [Out] out uint ActualExeNameSize,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint ActualDescriptionSize);

        /// <summary>
        ///     Attaches the process.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="ProcessID">The process identifier.</param>
        /// <param name="AttachFlags">The attach flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int AttachProcess(
            [In] ulong Server,
            [In] uint ProcessID,
            [In] DEBUG_ATTACH AttachFlags);

        /// <summary>
        ///     Creates the process.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="CommandLine">The command line.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateProcess(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags);

        /// <summary>
        ///     Creates the process and attach.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="CommandLine">The command line.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="ProcessId">The process identifier.</param>
        /// <param name="AttachFlags">The attach flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateProcessAndAttach(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        /// <summary>
        ///     Gets the process options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetProcessOptions(
            [Out] out DEBUG_PROCESS Options);

        /// <summary>
        ///     Adds the process options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int AddProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        ///     Removes the process options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int RemoveProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        ///     Sets the process options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        ///     Opens the dump file.
        /// </summary>
        /// <param name="DumpFile">The dump file.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OpenDumpFile(
            [In] [MarshalAs(UnmanagedType.LPStr)] string DumpFile);

        /// <summary>
        ///     Writes the dump file.
        /// </summary>
        /// <param name="DumpFile">The dump file.</param>
        /// <param name="Qualifier">The qualifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int WriteDumpFile(
            [In] [MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier);

        /// <summary>
        ///     Connects the session.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="HistoryLimit">The history limit.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ConnectSession(
            [In] DEBUG_CONNECT_SESSION Flags,
            [In] uint HistoryLimit);

        /// <summary>
        ///     Starts the server.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int StartServer(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Options);

        /// <summary>
        ///     Outputs the server.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Machine">The machine.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputServer(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Machine,
            [In] DEBUG_SERVERS Flags);

        /// <summary>
        ///     Terminates the processes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int TerminateProcesses();

        /// <summary>
        ///     Detaches the processes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int DetachProcesses();

        /// <summary>
        ///     Ends the session.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int EndSession(
            [In] DEBUG_END Flags);

        /// <summary>
        ///     Gets the exit code.
        /// </summary>
        /// <param name="Code">The code.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetExitCode(
            [Out] out uint Code);

        /// <summary>
        ///     Dispatches the callbacks.
        /// </summary>
        /// <param name="Timeout">The timeout.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int DispatchCallbacks(
            [In] uint Timeout);

        /// <summary>
        ///     Exits the dispatch.
        /// </summary>
        /// <param name="Client">The client.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ExitDispatch(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugClient Client);

        /// <summary>
        ///     Creates the client.
        /// </summary>
        /// <param name="Client">The client.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateClient(
            [Out] [MarshalAs(UnmanagedType.Interface)] out IDebugClient Client);

        /// <summary>
        ///     Gets the input callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetInputCallbacks(
            [Out] [MarshalAs(UnmanagedType.Interface)] out IDebugInputCallbacks Callbacks);

        /// <summary>
        ///     Sets the input callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetInputCallbacks(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugInputCallbacks Callbacks);

        /* GetOutputCallbacks could a conversion thunk from the debugger engine so we can't specify a specific interface */

        /// <summary>
        ///     Gets the output callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOutputCallbacks(
            [Out] out IDebugOutputCallbacks Callbacks);

        /* We may have to pass a debugger engine conversion thunk back in so we can't specify a specific interface */

        /// <summary>
        ///     Sets the output callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetOutputCallbacks(
            [In] IDebugOutputCallbacks Callbacks);

        /// <summary>
        ///     Gets the output mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOutputMask(
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Sets the output mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetOutputMask(
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Gets the other output mask.
        /// </summary>
        /// <param name="Client">The client.</param>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOtherOutputMask(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugClient Client,
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Sets the other output mask.
        /// </summary>
        /// <param name="Client">The client.</param>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetOtherOutputMask(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugClient Client,
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Gets the width of the output.
        /// </summary>
        /// <param name="Columns">The columns.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOutputWidth(
            [Out] out uint Columns);

        /// <summary>
        ///     Sets the width of the output.
        /// </summary>
        /// <param name="Columns">The columns.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetOutputWidth(
            [In] uint Columns);

        /// <summary>
        ///     Gets the output line prefix.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PrefixSize">Size of the prefix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOutputLinePrefix(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PrefixSize);

        /// <summary>
        ///     Sets the output line prefix.
        /// </summary>
        /// <param name="Prefix">The prefix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetOutputLinePrefix(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Prefix);

        /// <summary>
        ///     Gets the identity.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="IdentitySize">Size of the identity.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetIdentity(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint IdentitySize);

        /// <summary>
        ///     Outputs the identity.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Format">The format.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputIdentity(
            [In] DEBUG_OUTCTL OutputControl,
            [In] uint Flags,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Format);

        /* GetEventCallbacks could a conversion thunk from the debugger engine so we can't specify a specific interface */

        /// <summary>
        ///     Gets the event callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetEventCallbacks(
            [Out] out IDebugEventCallbacks Callbacks);

        /* We may have to pass a debugger engine conversion thunk back in so we can't specify a specific interface */

        /// <summary>
        ///     Sets the event callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetEventCallbacks(
            [In] IDebugEventCallbacks Callbacks);

        /// <summary>
        ///     Flushes the callbacks.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int FlushCallbacks();
    }
}