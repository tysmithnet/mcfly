// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugSystemObjects2.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace McFly.Debugger
{
    /// <summary>
    ///     Interface IDebugSystemObjects2
    /// </summary>
    /// <seealso cref="McFly.Debugger.IDebugSystemObjects" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0ae9f5ff-1852-4679-b055-494bee6407ee")]
    public interface IDebugSystemObjects2 : IDebugSystemObjects
    {
        /* IDebugSystemObjects */

        /// <summary>
        ///     Gets the event thread.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEventThread(
            [Out] out uint Id);

        /// <summary>
        ///     Gets the event process.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEventProcess(
            [Out] out uint Id);

        /// <summary>
        ///     Gets the current thread identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentThreadId(
            [Out] out uint Id);

        /// <summary>
        ///     Sets the current thread identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetCurrentThreadId(
            [In] uint Id);

        /// <summary>
        ///     Gets the current process identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentProcessId(
            [Out] out uint Id);

        /// <summary>
        ///     Sets the current process identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetCurrentProcessId(
            [In] uint Id);

        /// <summary>
        ///     Gets the number threads.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberThreads(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the total number threads.
        /// </summary>
        /// <param name="Total">The total.</param>
        /// <param name="LargestProcess">The largest process.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTotalNumberThreads(
            [Out] out uint Total,
            [Out] out uint LargestProcess);

        /// <summary>
        ///     Gets the index of the thread ids by.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Ids">The ids.</param>
        /// <param name="SysIds">The system ids.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetThreadIdsByIndex(
            [In] uint Start,
            [In] uint Count,
            [Out] [MarshalAs(UnmanagedType.LPArray)] uint[] Ids,
            [Out] [MarshalAs(UnmanagedType.LPArray)] uint[] SysIds);

        /// <summary>
        ///     Gets the thread identifier by processor.
        /// </summary>
        /// <param name="Processor">The processor.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetThreadIdByProcessor(
            [In] uint Processor,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the current thread data offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentThreadDataOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the thread identifier by data offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetThreadIdByDataOffset(
            [In] ulong Offset,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the current thread teb.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentThreadTeb(
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the thread identifier by teb.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetThreadIdByTeb(
            [In] ulong Offset,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the current thread system identifier.
        /// </summary>
        /// <param name="SysId">The system identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentThreadSystemId(
            [Out] out uint SysId);

        /// <summary>
        ///     Gets the thread identifier by system identifier.
        /// </summary>
        /// <param name="SysId">The system identifier.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetThreadIdBySystemId(
            [In] uint SysId,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the current thread handle.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentThreadHandle(
            [Out] out ulong Handle);

        /// <summary>
        ///     Gets the thread identifier by handle.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetThreadIdByHandle(
            [In] ulong Handle,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the number processes.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberProcesses(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the index of the process ids by.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Ids">The ids.</param>
        /// <param name="SysIds">The system ids.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetProcessIdsByIndex(
            [In] uint Start,
            [In] uint Count,
            [Out] [MarshalAs(UnmanagedType.LPArray)] uint[] Ids,
            [Out] [MarshalAs(UnmanagedType.LPArray)] uint[] SysIds);

        /// <summary>
        ///     Gets the current process data offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentProcessDataOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the process identifier by data offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetProcessIdByDataOffset(
            [In] ulong Offset,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the current process peb.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentProcessPeb(
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the process identifier by peb.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetProcessIdByPeb(
            [In] ulong Offset,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the current process system identifier.
        /// </summary>
        /// <param name="SysId">The system identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentProcessSystemId(
            [Out] out uint SysId);

        /// <summary>
        ///     Gets the process identifier by system identifier.
        /// </summary>
        /// <param name="SysId">The system identifier.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetProcessIdBySystemId(
            [In] uint SysId,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the current process handle.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentProcessHandle(
            [Out] out ulong Handle);

        /// <summary>
        ///     Gets the process identifier by handle.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetProcessIdByHandle(
            [In] ulong Handle,
            [Out] out uint Id);

        /// <summary>
        ///     Gets the name of the current process executable.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="ExeSize">Size of the executable.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentProcessExecutableName(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ExeSize);

        /* IDebugSystemObjects2 */

        /// <summary>
        ///     Gets the current process up time.
        /// </summary>
        /// <param name="UpTime">Up time.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetCurrentProcessUpTime(
            [Out] out uint UpTime);

        /// <summary>
        ///     Gets the implicit thread data offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetImplicitThreadDataOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Sets the implicit thread data offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetImplicitThreadDataOffset(
            [In] ulong Offset);

        /// <summary>
        ///     Gets the implicit process data offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetImplicitProcessDataOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Sets the implicit process data offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetImplicitProcessDataOffset(
            [In] ulong Offset);
    }
}