// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugSymbolGroup.cs" company="">
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
    ///     Interface IDebugSymbolGroup
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("f2528316-0f1a-4431-aeed-11d096e1e2ab")]
    public interface IDebugSymbolGroup
    {
        /* IDebugSymbolGroup */

        /// <summary>
        ///     Gets the number symbols.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNumberSymbols(
            [Out] out uint Number);

        /// <summary>
        ///     Adds the symbol.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int AddSymbol(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] [Out] ref uint Index);

        /// <summary>
        ///     Removes the name of the symbol by.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int RemoveSymbolByName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Name);

        /// <summary>
        ///     Removes the index of the symbols by.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int RemoveSymbolsByIndex(
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
        int GetSymbolName(
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
        int GetSymbolParameters(
            [In] uint Start,
            [In] uint Count,
            [Out] [MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_PARAMETERS[] Params);

        /// <summary>
        ///     Expands the symbol.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Expand">if set to <c>true</c> [expand].</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ExpandSymbol(
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
        int OutputSymbols(
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
        int WriteSymbol(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Value);

        /// <summary>
        ///     Outputs as type.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputAsType(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Type);
    }
}