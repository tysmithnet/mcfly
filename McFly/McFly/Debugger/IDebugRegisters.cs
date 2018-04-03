// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugRegisters.cs" company="">
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
    ///     Interface IDebugRegisters
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("ce289126-9e84-45a7-937e-67bb18691493")]
    public interface IDebugRegisters
    {
        /// <summary>
        ///     Gets the number registers.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNumberRegisters(
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
        int GetDescription(
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
        int GetIndexByName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint Index);

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <param name="Register">The register.</param>
        /// <param name="Value">The value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetValue(
            [In] uint Register,
            [Out] out DEBUG_VALUE Value);

        /// <summary>
        ///     Sets the value.
        /// </summary>
        /// <param name="Register">The register.</param>
        /// <param name="Value">The value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetValue(
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
        int GetValues( //FIX ME!!! This needs to be tested
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)] uint[] Indices,
            [In] uint Start,
            [Out] [MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Values);

        /// <summary>
        ///     Sets the values.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Indices">The indices.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Values">The values.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetValues(
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)] uint[] Indices,
            [In] uint Start,
            [In] [MarshalAs(UnmanagedType.LPArray)] DEBUG_VALUE[] Values);

        /// <summary>
        ///     Outputs the registers.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputRegisters(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_REGISTERS Flags);

        /// <summary>
        ///     Gets the instruction offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetInstructionOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the stack offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetStackOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the frame offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetFrameOffset(
            [Out] out ulong Offset);
    }
}