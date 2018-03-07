// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugDataSpaces.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace McFly.Debugger
{
    /// <summary>
    ///     Interface IDebugDataSpaces
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("88f7dfab-3ea7-4c3a-aefb-c4e8106173aa")]
    public interface IDebugDataSpaces
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
        int ReadVirtual(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer,
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
        int WriteVirtual(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer,
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
        int SearchVirtual(
            [In] ulong Offset,
            [In] ulong Length,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pattern,
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
        int ReadVirtualUncached(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer,
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
        int WriteVirtualUncached(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer,
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
        int ReadPointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);

        /// <summary>
        ///     Writes the pointers virtual.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Ptrs">The PTRS.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int WritePointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray)] ulong[] Ptrs);

        /// <summary>
        ///     Reads the physical.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadPhysical(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer,
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
        int WritePhysical(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer,
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
        int ReadControl(
            [In] uint Processor,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] buffer,
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
        int WriteControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] buffer,
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
        int ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] buffer,
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
        int WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the MSR.
        /// </summary>
        /// <param name="Msr">The MSR.</param>
        /// <param name="MsrValue">The MSR value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadMsr(
            [In] uint Msr,
            [Out] out ulong MsrValue);

        /// <summary>
        ///     Writes the MSR.
        /// </summary>
        /// <param name="Msr">The MSR.</param>
        /// <param name="MsrValue">The MSR value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int WriteMsr(
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
        int ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] buffer,
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
        int WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Checks the low memory.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CheckLowMemory();

        /// <summary>
        ///     Reads the debugger data.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DataSize">Size of the data.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadDebuggerData(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer,
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
        int ReadProcessorSystemData(
            [In] uint Processor,
            [In] DEBUG_DATA Index,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);
    }

    /// <summary>
    ///     Interface IDebugDataSpacesPtr
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("88f7dfab-3ea7-4c3a-aefb-c4e8106173aa")]
    public interface IDebugDataSpacesPtr
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
        int ReadVirtual(
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int WriteVirtual(
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int SearchVirtual(
            [In] ulong Offset,
            [In] ulong Length,
            [In] IntPtr pattern,
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
        int ReadVirtualUncached(
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int WriteVirtualUncached(
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int ReadPointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ulong[] Ptrs);

        /// <summary>
        ///     Writes the pointers virtual.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Ptrs">The PTRS.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int WritePointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray)] ulong[] Ptrs);

        /// <summary>
        ///     Reads the physical.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadPhysical(
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int WritePhysical(
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int ReadControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int WriteControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] IntPtr buffer,
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
        int WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] IntPtr buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the MSR.
        /// </summary>
        /// <param name="Msr">The MSR.</param>
        /// <param name="MsrValue">The MSR value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadMsr(
            [In] uint Msr,
            [Out] out ulong MsrValue);

        /// <summary>
        ///     Writes the MSR.
        /// </summary>
        /// <param name="Msr">The MSR.</param>
        /// <param name="MsrValue">The MSR value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int WriteMsr(
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
        int ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] IntPtr buffer,
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
        int WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] IntPtr buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Checks the low memory.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CheckLowMemory();

        /// <summary>
        ///     Reads the debugger data.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DataSize">Size of the data.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadDebuggerData(
            [In] uint Index,
            [In] IntPtr buffer,
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
        int ReadProcessorSystemData(
            [In] uint Processor,
            [In] DEBUG_DATA Index,
            [In] IntPtr buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);
    }
}