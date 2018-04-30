// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugSymbolGroup2.cs" company="">
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
    ///     Interface IDebugSymbolGroup2
    /// </summary>
    /// <seealso cref="IDebugSymbolGroup" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6a7ccc5f-fb5e-4dcc-b41c-6c20307bccc7")]
    public interface IDebugSymbolGroup2 : IDebugSymbolGroup
    {
        /* IDebugSymbolGroup */

        /// <summary>
        ///     Gets the number symbols.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberSymbols(
            [Out] out uint Number);

        /// <summary>
        ///     Adds the symbol.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddSymbol(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] [Out] ref uint Index);

        /// <summary>
        ///     Removes the name of the symbol by.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveSymbolByName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name);

        /// <summary>
        ///     Removes the index of the symbols by.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveSymbolsByIndex(
            [In] uint Index);

        /// <summary>
        ///     Gets the name of the symbol.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolName(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the symbol parameters.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Params">The parameters.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSymbolParameters(
            [In] uint Start,
            [In] uint Count,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_SYMBOL_PARAMETERS[] Params);

        /// <summary>
        ///     Expands the symbol.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Expand">if set to <c>true</c> [expand].</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ExpandSymbol(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.Bool)] bool Expand);

        /// <summary>
        ///     Outputs the symbols.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputSymbols(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT_SYMBOLS Flags,
            [In] uint Start,
            [In] uint Count);

        /// <summary>
        ///     Writes the symbol.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Value">The value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteSymbol(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Value);

        /// <summary>
        ///     Outputs as type.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputAsType(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Type);

        /* IDebugSymbolGroup2 */

        /// <summary>
        ///     Adds the symbol wide.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int AddSymbolWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] [Out] ref uint Index);

        /// <summary>
        ///     Removes the symbol by name wide.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int RemoveSymbolByNameWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Name);

        /// <summary>
        ///     Gets the symbol name wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolNameWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Writes the symbol wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Value">The value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int WriteSymbolWide(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Value);

        /// <summary>
        ///     Outputs as type wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputAsTypeWide(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Type);

        /// <summary>
        ///     Gets the name of the symbol type.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolTypeName(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the symbol type name wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolTypeNameWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the size of the symbol.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Size">The size.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolSize(
            [In] uint Index,
            [Out] out uint Size);

        /// <summary>
        ///     Gets the symbol offset.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolOffset(
            [In] uint Index,
            [Out] out ulong Offset);

        /// <summary>
        ///     Gets the symbol register.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Register">The register.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolRegister(
            [In] uint Index,
            [Out] out uint Register);

        /// <summary>
        ///     Gets the symbol value text.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolValueText(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the symbol value text wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="NameSize">Size of the name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolValueTextWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        /// <summary>
        ///     Gets the symbol entry information.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Info">The information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSymbolEntryInformation(
            [In] uint Index,
            [Out] out DEBUG_SYMBOL_ENTRY Info);
    }
}