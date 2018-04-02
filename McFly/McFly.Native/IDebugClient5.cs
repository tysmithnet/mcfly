// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugClient5.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace McFly.Native
{
    /// <summary>
    ///     Interface IDebugClient5
    /// </summary>
    /// <seealso cref="IDebugClient4" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("e3acb9d7-7ec2-4f0c-a0da-e81e0cbbe628")]
    public interface IDebugClient5 : IDebugClient4
    {
        /* IDebugClient */

        /// <summary>
        ///     Attaches the kernel.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="ConnectOptions">The connect options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AttachKernel(
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
        new int GetKernelConnectionOptions(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint OptionsSize);

        /// <summary>
        ///     Sets the kernel connection options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetKernelConnectionOptions(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Options);

        /// <summary>
        ///     Starts the process server.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Options">The options.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int StartProcessServer(
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
        new int ConnectProcessServer(
            [In] [MarshalAs(UnmanagedType.LPStr)] string RemoteOptions,
            [Out] out ulong Server);

        /// <summary>
        ///     Disconnects the process server.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int DisconnectProcessServer(
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
        new int GetRunningProcessSystemIds(
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
        new int GetRunningProcessSystemIdByExecutableName(
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
        new int GetRunningProcessDescription(
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
        new int AttachProcess(
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
        new int CreateProcess(
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
        new int CreateProcessAndAttach(
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
        new int GetProcessOptions(
            [Out] out DEBUG_PROCESS Options);

        /// <summary>
        ///     Adds the process options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        ///     Removes the process options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        ///     Sets the process options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetProcessOptions(
            [In] DEBUG_PROCESS Options);

        /// <summary>
        ///     Opens the dump file.
        /// </summary>
        /// <param name="DumpFile">The dump file.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OpenDumpFile(
            [In] [MarshalAs(UnmanagedType.LPStr)] string DumpFile);

        /// <summary>
        ///     Writes the dump file.
        /// </summary>
        /// <param name="DumpFile">The dump file.</param>
        /// <param name="Qualifier">The qualifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteDumpFile(
            [In] [MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier);

        /// <summary>
        ///     Connects the session.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="HistoryLimit">The history limit.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ConnectSession(
            [In] DEBUG_CONNECT_SESSION Flags,
            [In] uint HistoryLimit);

        /// <summary>
        ///     Starts the server.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int StartServer(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Options);

        /// <summary>
        ///     Outputs the server.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Machine">The machine.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputServer(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Machine,
            [In] DEBUG_SERVERS Flags);

        /// <summary>
        ///     Terminates the processes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int TerminateProcesses();

        /// <summary>
        ///     Detaches the processes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int DetachProcesses();

        /// <summary>
        ///     Ends the session.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int EndSession(
            [In] DEBUG_END Flags);

        /// <summary>
        ///     Gets the exit code.
        /// </summary>
        /// <param name="Code">The code.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExitCode(
            [Out] out uint Code);

        /// <summary>
        ///     Dispatches the callbacks.
        /// </summary>
        /// <param name="Timeout">The timeout.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int DispatchCallbacks(
            [In] uint Timeout);

        /// <summary>
        ///     Exits the dispatch.
        /// </summary>
        /// <param name="Client">The client.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ExitDispatch(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugClient Client);

        /// <summary>
        ///     Creates the client.
        /// </summary>
        /// <param name="Client">The client.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CreateClient(
            [Out] [MarshalAs(UnmanagedType.Interface)] out IDebugClient Client);

        /// <summary>
        ///     Gets the input callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetInputCallbacks(
            [Out] [MarshalAs(UnmanagedType.Interface)] out IDebugInputCallbacks Callbacks);

        /// <summary>
        ///     Sets the input callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetInputCallbacks(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugInputCallbacks Callbacks);

        /* GetOutputCallbacks could a conversion thunk from the debugger engine so we can't specify a specific interface */

        /// <summary>
        ///     Gets the output callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOutputCallbacks(
            [Out] out IDebugOutputCallbacks Callbacks);

        /* We may have to pass a debugger engine conversion thunk back in so we can't specify a specific interface */

        /// <summary>
        ///     Sets the output callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetOutputCallbacks(
            [In] IDebugOutputCallbacks Callbacks);

        /// <summary>
        ///     Gets the output mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOutputMask(
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Sets the output mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetOutputMask(
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Gets the other output mask.
        /// </summary>
        /// <param name="Client">The client.</param>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOtherOutputMask(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugClient Client,
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Sets the other output mask.
        /// </summary>
        /// <param name="Client">The client.</param>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetOtherOutputMask(
            [In] [MarshalAs(UnmanagedType.Interface)] IDebugClient Client,
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Gets the width of the output.
        /// </summary>
        /// <param name="Columns">The columns.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOutputWidth(
            [Out] out uint Columns);

        /// <summary>
        ///     Sets the width of the output.
        /// </summary>
        /// <param name="Columns">The columns.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetOutputWidth(
            [In] uint Columns);

        /// <summary>
        ///     Gets the output line prefix.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PrefixSize">Size of the prefix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOutputLinePrefix(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PrefixSize);

        /// <summary>
        ///     Sets the output line prefix.
        /// </summary>
        /// <param name="Prefix">The prefix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetOutputLinePrefix(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Prefix);

        /// <summary>
        ///     Gets the identity.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="IdentitySize">Size of the identity.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetIdentity(
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
        new int OutputIdentity(
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
        new int GetEventCallbacks(
            [Out] out IDebugEventCallbacks Callbacks);

        /* We may have to pass a debugger engine conversion thunk back in so we can't specify a specific interface */

        /// <summary>
        ///     Sets the event callbacks.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetEventCallbacks(
            [In] IDebugEventCallbacks Callbacks);

        /// <summary>
        ///     Flushes the callbacks.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int FlushCallbacks();

        /* IDebugClient2 */

        /// <summary>
        ///     Writes the dump file2.
        /// </summary>
        /// <param name="DumpFile">The dump file.</param>
        /// <param name="Qualifier">The qualifier.</param>
        /// <param name="FormatFlags">The format flags.</param>
        /// <param name="Comment">The comment.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteDumpFile2(
            [In] [MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier,
            [In] DEBUG_FORMAT FormatFlags,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Comment);

        /// <summary>
        ///     Adds the dump information file.
        /// </summary>
        /// <param name="InfoFile">The information file.</param>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddDumpInformationFile(
            [In] [MarshalAs(UnmanagedType.LPStr)] string InfoFile,
            [In] DEBUG_DUMP_FILE Type);

        /// <summary>
        ///     Ends the process server.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int EndProcessServer(
            [In] ulong Server);

        /// <summary>
        ///     Waits for process server end.
        /// </summary>
        /// <param name="Timeout">The timeout.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WaitForProcessServerEnd(
            [In] uint Timeout);

        /// <summary>
        ///     Determines whether [is kernel debugger enabled].
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int IsKernelDebuggerEnabled();

        /// <summary>
        ///     Terminates the current process.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int TerminateCurrentProcess();

        /// <summary>
        ///     Detaches the current process.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int DetachCurrentProcess();

        /// <summary>
        ///     Abandons the current process.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AbandonCurrentProcess();

        /* IDebugClient3 */

        /// <summary>
        ///     Gets the running process system identifier by executable name wide.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="ExeName">Name of the executable.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetRunningProcessSystemIdByExecutableNameWide(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ExeName,
            [In] DEBUG_GET_PROC Flags,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the running process description wide.
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
        new int GetRunningProcessDescriptionWide(
            [In] ulong Server,
            [In] uint SystemId,
            [In] DEBUG_PROC_DESC Flags,
            [Out] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder ExeName,
            [In] int ExeNameSize,
            [Out] out uint ActualExeNameSize,
            [Out] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint ActualDescriptionSize);

        /// <summary>
        ///     Creates the process wide.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="CommandLine">The command line.</param>
        /// <param name="CreateFlags">The create flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CreateProcessWide(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS CreateFlags);

        /// <summary>
        ///     Creates the process and attach wide.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="CommandLine">The command line.</param>
        /// <param name="CreateFlags">The create flags.</param>
        /// <param name="ProcessId">The process identifier.</param>
        /// <param name="AttachFlags">The attach flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CreateProcessAndAttachWide(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS CreateFlags,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        /* IDebugClient4 */

        /// <summary>
        ///     Opens the dump file wide.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="FileHandle">The file handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OpenDumpFileWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string FileName,
            [In] ulong FileHandle);

        /// <summary>
        ///     Writes the dump file wide.
        /// </summary>
        /// <param name="DumpFile">The dump file.</param>
        /// <param name="FileHandle">The file handle.</param>
        /// <param name="Qualifier">The qualifier.</param>
        /// <param name="FormatFlags">The format flags.</param>
        /// <param name="Comment">The comment.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteDumpFileWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string DumpFile,
            [In] ulong FileHandle,
            [In] DEBUG_DUMP Qualifier,
            [In] DEBUG_FORMAT FormatFlags,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Comment);

        /// <summary>
        ///     Adds the dump information file wide.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="FileHandle">The file handle.</param>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddDumpInformationFileWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string FileName,
            [In] ulong FileHandle,
            [In] DEBUG_DUMP_FILE Type);

        /// <summary>
        ///     Gets the number dump files.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberDumpFiles(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the dump file.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Handle">The handle.</param>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetDumpFile(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Handle,
            [Out] out uint Type);

        /// <summary>
        ///     Gets the dump file wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Handle">The handle.</param>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetDumpFileWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Handle,
            [Out] out uint Type);

        /* IDebugClient5 */

        /// <summary>
        ///     Attaches the kernel wide.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="ConnectOptions">The connect options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int AttachKernelWide(
            [In] DEBUG_ATTACH Flags,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string ConnectOptions);

        /// <summary>
        ///     Gets the kernel connection options wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="OptionsSize">Size of the options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetKernelConnectionOptionsWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint OptionsSize);

        /// <summary>
        ///     Sets the kernel connection options wide.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetKernelConnectionOptionsWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Options);

        /// <summary>
        ///     Starts the process server wide.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Options">The options.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int StartProcessServerWide(
            [In] DEBUG_CLASS Flags,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Options,
            [In] IntPtr Reserved);

        /// <summary>
        ///     Connects the process server wide.
        /// </summary>
        /// <param name="RemoteOptions">The remote options.</param>
        /// <param name="Server">The server.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ConnectProcessServerWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string RemoteOptions,
            [Out] out ulong Server);

        /// <summary>
        ///     Starts the server wide.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int StartServerWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Options);

        /// <summary>
        ///     Outputs the servers wide.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Machine">The machine.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputServersWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Machine,
            [In] DEBUG_SERVERS Flags);

        /* GetOutputCallbacks could a conversion thunk from the debugger engine so we can't specify a specific interface */

        /// <summary>
        ///     Gets the output callbacks wide.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOutputCallbacksWide(
            [Out] out IDebugOutputCallbacksWide Callbacks);

        /* We may have to pass a debugger engine conversion thunk back in so we can't specify a specific interface */

        /// <summary>
        ///     Sets the output callbacks wide.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetOutputCallbacksWide(
            [In] IDebugOutputCallbacks2 Callbacks);

        /// <summary>
        ///     Gets the output line prefix wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="PrefixSize">Size of the prefix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOutputLinePrefixWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PrefixSize);

        /// <summary>
        ///     Sets the output line prefix wide.
        /// </summary>
        /// <param name="Prefix">The prefix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetOutputLinePrefixWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Prefix);

        /// <summary>
        ///     Gets the identity wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="IdentitySize">Size of the identity.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetIdentityWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint IdentitySize);

        /// <summary>
        ///     Outputs the identity wide.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Machine">The machine.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputIdentityWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] uint Flags,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Machine);

        /* GetEventCallbacks could a conversion thunk from the debugger engine so we can't specify a specific interface */

        /// <summary>
        ///     Gets the event callbacks wide.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetEventCallbacksWide(
            [Out] out IDebugEventCallbacksWide Callbacks);

        /* We may have to pass a debugger engine conversion thunk back in so we can't specify a specific interface */

        /// <summary>
        ///     Sets the event callbacks wide.
        /// </summary>
        /// <param name="Callbacks">The callbacks.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetEventCallbacksWide(
            [In] IDebugEventCallbacksWide Callbacks);

        /// <summary>
        ///     Creates the process2.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="CommandLine">The command line.</param>
        /// <param name="OptionsBuffer">The options buffer.</param>
        /// <param name="OptionsBufferSize">Size of the options buffer.</param>
        /// <param name="InitialDirectory">The initial directory.</param>
        /// <param name="Environment">The environment.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateProcess2(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In] [MarshalAs(UnmanagedType.LPStr)] string InitialDirectory,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Environment);

        /// <summary>
        ///     Creates the process2 wide.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="CommandLine">The command line.</param>
        /// <param name="OptionsBuffer">The options buffer.</param>
        /// <param name="OptionsBufferSize">Size of the options buffer.</param>
        /// <param name="InitialDirectory">The initial directory.</param>
        /// <param name="Environment">The environment.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateProcess2Wide(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Environment);

        /// <summary>
        ///     Creates the process and attach2.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="CommandLine">The command line.</param>
        /// <param name="OptionsBuffer">The options buffer.</param>
        /// <param name="OptionsBufferSize">Size of the options buffer.</param>
        /// <param name="InitialDirectory">The initial directory.</param>
        /// <param name="Environment">The environment.</param>
        /// <param name="ProcessId">The process identifier.</param>
        /// <param name="AttachFlags">The attach flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateProcessAndAttach2(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In] [MarshalAs(UnmanagedType.LPStr)] string InitialDirectory,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Environment,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        /// <summary>
        ///     Creates the process and attach2 wide.
        /// </summary>
        /// <param name="Server">The server.</param>
        /// <param name="CommandLine">The command line.</param>
        /// <param name="OptionsBuffer">The options buffer.</param>
        /// <param name="OptionsBufferSize">Size of the options buffer.</param>
        /// <param name="InitialDirectory">The initial directory.</param>
        /// <param name="Environment">The environment.</param>
        /// <param name="ProcessId">The process identifier.</param>
        /// <param name="AttachFlags">The attach flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CreateProcessAndAttach2Wide(
            [In] ulong Server,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Environment,
            [In] uint ProcessId,
            [In] DEBUG_ATTACH AttachFlags);

        /// <summary>
        ///     Pushes the output line prefix.
        /// </summary>
        /// <param name="NewPrefix">The new prefix.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int PushOutputLinePrefix(
            [In] [MarshalAs(UnmanagedType.LPStr)] string NewPrefix,
            [Out] out ulong Handle);

        /// <summary>
        ///     Pushes the output line prefix wide.
        /// </summary>
        /// <param name="NewPrefix">The new prefix.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int PushOutputLinePrefixWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string NewPrefix,
            [Out] out ulong Handle);

        /// <summary>
        ///     Pops the output line prefix.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int PopOutputLinePrefix(
            [In] ulong Handle);

        /// <summary>
        ///     Gets the number input callbacks.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNumberInputCallbacks(
            [Out] out uint Count);

        /// <summary>
        ///     Gets the number output callbacks.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNumberOutputCallbacks(
            [Out] out uint Count);

        /// <summary>
        ///     Gets the number event callbacks.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Count">The count.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNumberEventCallbacks(
            [In] DEBUG_EVENT Flags,
            [Out] out uint Count);

        /// <summary>
        ///     Gets the quit lock string.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetQuitLockString(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        /// <summary>
        ///     Sets the quit lock string.
        /// </summary>
        /// <param name="LockString">The lock string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetQuitLockString(
            [In] [MarshalAs(UnmanagedType.LPStr)] string LockString);

        /// <summary>
        ///     Gets the quit lock string wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetQuitLockStringWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        /// <summary>
        ///     Sets the quit lock string wide.
        /// </summary>
        /// <param name="LockString">The lock string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetQuitLockStringWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string LockString);
    }
}