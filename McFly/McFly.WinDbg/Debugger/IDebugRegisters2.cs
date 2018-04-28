// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugRegisters2.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace McFly.WinDbg.Debugger
{
    /// <summary>
    ///     Interface IDebugRegisters2
    /// </summary>
    /// <seealso cref="IDebugRegisters" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1656afa9-19c6-4e3a-97e7-5dc9160cf9c4")]
    public interface IDebugRegisters2 : IDebugRegisters
    {
        /// <summary>
        ///     Gets the number registers.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberRegisters(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <param name="Register">The register.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Desc">The desc.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetDescription(
            [In] uint Register,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);

        /// <summary>
        ///     Gets the name of the index by.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetIndexByName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <param name="Register">The register.</param>
        /// <param name="Value">The value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetValue(
            [In] uint Register,
            [Out] out DEBUG_VALUE Value);

        /// <summary>
        ///     Sets the value.
        /// </summary>
        /// <param name="Register">The register.</param>
        /// <param name="Value">The value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetValue(
            [In] uint Register,
            [In] DEBUG_VALUE Value);

        /// <summary>
        ///     Gets the values.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Indices">The indices.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Values">The values.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetValues( //FIX ME!!! This needs to be tested
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values);

        /// <summary>
        ///     Sets the values.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Indices">The indices.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Values">The values.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetValues(
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values);

        /// <summary>
        ///     Outputs the registers.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputRegisters(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGISTERS Flags);

        /// <summary>
        ///     Gets the instruction offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetInstructionOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the stack offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetStackOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the frame offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetFrameOffset(
            [Out] out ulong Offset);

        /* IDebugRegisters2 */

        /// <summary>
        ///     Gets the description wide.
        /// </summary>
        /// <param name="Register">The register.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="Desc">The desc.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetDescriptionWide(
            [In] uint Register,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out DEBUG_REGISTER_DESCRIPTION Desc);

        /// <summary>
        ///     Gets the index by name wide.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetIndexByNameWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint Index);

        /// <summary>
        ///     Gets the number pseudo registers.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNumberPseudoRegisters(
            [Out] out uint Number
        );

        /// <summary>
        ///     Gets the pseudo description.
        /// </summary>
        /// <param name="Register">The register.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="TypeModule">The type module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetPseudoDescription(
            [In] uint Register,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong TypeModule,
            [Out] out uint TypeId
        );

        /// <summary>
        ///     Gets the pseudo description wide.
        /// </summary>
        /// <param name="Register">The register.</param>
        /// <param name="NameBuffer">The name buffer.</param>
        /// <param name="NameBufferSize">Size of the name buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <param name="TypeModule">The type module.</param>
        /// <param name="TypeId">The type identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetPseudoDescriptionWide(
            [In] uint Register,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong TypeModule,
            [Out] out uint TypeId
        );

        /// <summary>
        ///     Gets the name of the pseudo index by.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetPseudoIndexByName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index
        );

        /// <summary>
        ///     Gets the pseudo index by name wide.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetPseudoIndexByNameWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint Index
        );

        /// <summary>
        ///     Gets the pseudo values.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Indices">The indices.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Values">The values.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetPseudoValues(
            [In] uint Source,
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values
        );

        /// <summary>
        ///     Sets the pseudo values.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Indices">The indices.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Values">The values.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetPseudoValues(
            [In] uint Source,
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values
        );

        /// <summary>
        ///     Gets the values2.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Indices">The indices.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Values">The values.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetValues2(
            [In] DEBUG_REGSRC Source,
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values
        );

        /// <summary>
        ///     Sets the values2.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Indices">The indices.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Values">The values.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetValues2(
            [In] uint Source,
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            uint[] Indices,
            [In] uint Start,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Values
        );

        /// <summary>
        ///     Outputs the registers2.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Source">The source.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputRegisters2(
            [In] uint OutputControl,
            [In] uint Source,
            [In] uint Flags
        );

        /// <summary>
        ///     Gets the instruction offset2.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetInstructionOffset2(
            [In] uint Source,
            [Out] out ulong Offset
        );

        /// <summary>
        ///     Gets the stack offset2.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetStackOffset2(
            [In] uint Source,
            [Out] out ulong Offset
        );

        /// <summary>
        ///     Gets the frame offset2.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetFrameOffset2(
            [In] uint Source,
            [Out] out ulong Offset
        );
    }
}