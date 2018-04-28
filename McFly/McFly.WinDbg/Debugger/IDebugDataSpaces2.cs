// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugDataSpaces2.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.WinDbg.Debugger
{
    /// <summary>
    ///     Interface IDebugDataSpaces2
    /// </summary>
    /// <seealso cref="IDebugDataSpaces" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7a5e852f-96e9-468f-ac1b-0b3addc4a049")]
    public interface IDebugDataSpaces2 : IDebugDataSpaces
    {
        /* IDebugDataSpaces */

        /// <summary>
        ///     Reads the virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadVirtual(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteVirtual(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Searches the virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Length">The length.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="PatternSize">Size of the pattern.</param>
        /// <param name="PatternGranularity">The pattern granularity.</param>
        /// <param name="MatchOffset">The match offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SearchVirtual(
            [In] ulong Offset,
            [In] ulong Length,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] pattern,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);

        /// <summary>
        ///     Reads the virtual uncached.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadVirtualUncached(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the virtual uncached.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteVirtualUncached(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the pointers virtual.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Ptrs">The PTRS.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadPointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
            ulong[] Ptrs);

        /// <summary>
        ///     Writes the pointers virtual.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Ptrs">The PTRS.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WritePointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] Ptrs);

        /// <summary>
        ///     Reads the physical.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadPhysical(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the physical.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WritePhysical(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the control.
        /// </summary>
        /// <param name="Processor">The processor.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadControl(
            [In] uint Processor,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] int BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the control.
        /// </summary>
        /// <param name="Processor">The processor.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] int BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the io.
        /// </summary>
        /// <param name="InterfaceType">Type of the interface.</param>
        /// <param name="BusNumber">The bus number.</param>
        /// <param name="AddressSpace">The address space.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the io.
        /// </summary>
        /// <param name="InterfaceType">Type of the interface.</param>
        /// <param name="BusNumber">The bus number.</param>
        /// <param name="AddressSpace">The address space.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the MSR.
        /// </summary>
        /// <param name="Msr">The MSR.</param>
        /// <param name="MsrValue">The MSR value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadMsr(
            [In] uint Msr,
            [Out] out ulong MsrValue);

        /// <summary>
        ///     Writes the MSR.
        /// </summary>
        /// <param name="Msr">The MSR.</param>
        /// <param name="MsrValue">The MSR value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteMsr(
            [In] uint Msr,
            [In] ulong MsrValue);

        /// <summary>
        ///     Reads the bus data.
        /// </summary>
        /// <param name="BusDataType">Type of the bus data.</param>
        /// <param name="BusNumber">The bus number.</param>
        /// <param name="SlotNumber">The slot number.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the bus data.
        /// </summary>
        /// <param name="BusDataType">Type of the bus data.</param>
        /// <param name="BusNumber">The bus number.</param>
        /// <param name="SlotNumber">The slot number.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Checks the low memory.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CheckLowMemory();

        /// <summary>
        ///     Reads the debugger data.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DataSize">Size of the data.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadDebuggerData(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        /// <summary>
        ///     Reads the processor system data.
        /// </summary>
        /// <param name="Processor">The processor.</param>
        /// <param name="Index">The index.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DataSize">Size of the data.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadProcessorSystemData(
            [In] uint Processor,
            [In] DEBUG_DATA Index,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        /* IDebugDataSpaces2 */

        /// <summary>
        ///     Virtuals to physical.
        /// </summary>
        /// <param name="Virtual">The virtual.</param>
        /// <param name="Physical">The physical.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int VirtualToPhysical(
            [In] ulong Virtual,
            [Out] out ulong Physical);

        /// <summary>
        ///     Gets the virtual translation physical offsets.
        /// </summary>
        /// <param name="Virtual">The virtual.</param>
        /// <param name="Offsets">The offsets.</param>
        /// <param name="OffsetsSize">Size of the offsets.</param>
        /// <param name="Levels">The levels.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetVirtualTranslationPhysicalOffsets(
            [In] ulong Virtual,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] Offsets,
            [In] uint OffsetsSize,
            [Out] out uint Levels);

        /// <summary>
        ///     Reads the handle data.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="DataType">Type of the data.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DataSize">Size of the data.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadHandleData(
            [In] ulong Handle,
            [In] DEBUG_HANDLE_DATA_TYPE DataType,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        /// <summary>
        ///     Fills the virtual.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Size">The size.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="PatternSize">Size of the pattern.</param>
        /// <param name="Filled">The filled.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int FillVirtual(
            [In] ulong Start,
            [In] uint Size,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);

        /// <summary>
        ///     Fills the physical.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Size">The size.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="PatternSize">Size of the pattern.</param>
        /// <param name="Filled">The filled.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int FillPhysical(
            [In] ulong Start,
            [In] uint Size,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);

        /// <summary>
        ///     Queries the virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Info">The information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int QueryVirtual(
            [In] ulong Offset,
            [Out] out MEMORY_BASIC_INFORMATION64 Info);
    }
}