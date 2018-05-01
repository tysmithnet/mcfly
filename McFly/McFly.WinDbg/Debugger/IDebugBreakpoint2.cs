// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugBreakpoint2.cs" company="">
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
    ///     Interface IDebugBreakpoint2
    /// </summary>
    /// <seealso cref="IDebugBreakpoint" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1b278d20-79f2-426e-a3f9-c1ddf375d48e")]
    public interface IDebugBreakpoint2 : IDebugBreakpoint
    {
        /* IDebugBreakpoint */

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetId(
            [Out] out uint Id);

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <param name="BreakType">Type of the break.</param>
        /// <param name="ProcType">Type of the proc.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetType(
            [Out] out DEBUG_BREAKPOINT_TYPE BreakType,
            [Out] out uint ProcType);

        //FIX ME!!! Should try and get an enum for this
        /// <summary>
        ///     Gets the adder.
        /// </summary>
        /// <param name="Adder">The adder.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetAdder(
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugClient Adder);

        /// <summary>
        ///     Gets the flags.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetFlags(
            [Out] out DEBUG_BREAKPOINT_FLAG Flags);

        /// <summary>
        ///     Adds the flags.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        /// <summary>
        ///     Removes the flags.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        /// <summary>
        ///     Sets the flags.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        /// <summary>
        ///     Gets the offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Sets the offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetOffset(
            [In] ulong Offset);

        /// <summary>
        ///     Gets the data parameters.
        /// </summary>
        /// <param name="Size">The size.</param>
        /// <param name="AccessType">Type of the access.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetDataParameters(
            [Out] out uint Size,
            [Out] out DEBUG_BREAKPOINT_ACCESS_TYPE AccessType);

        /// <summary>
        ///     Sets the data parameters.
        /// </summary>
        /// <param name="Size">The size.</param>
        /// <param name="AccessType">Type of the access.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetDataParameters(
            [In] uint Size,
            [In] DEBUG_BREAKPOINT_ACCESS_TYPE AccessType);

        /// <summary>
        ///     Gets the pass count.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetPassCount(
            [Out] out uint Count);

        /// <summary>
        ///     Sets the pass count.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetPassCount(
            [In] uint Count);

        /// <summary>
        ///     Gets the current pass count.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentPassCount(
            [Out] out uint Count);

        /// <summary>
        ///     Gets the match thread identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetMatchThreadId(
            [Out] out uint Id);

        /// <summary>
        ///     Sets the match thread identifier.
        /// </summary>
        /// <param name="Thread">The thread.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetMatchThreadId(
            [In] uint Thread);

        /// <summary>
        ///     Gets the command.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="CommandSize">Size of the command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCommand(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        /// <summary>
        ///     Sets the command.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetCommand(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Command);

        /// <summary>
        ///     Gets the offset expression.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="ExpressionSize">Size of the expression.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetOffsetExpression(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ExpressionSize);

        /// <summary>
        ///     Sets the offset expression.
        /// </summary>
        /// <param name="Expression">The expression.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetOffsetExpression(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Expression);

        /// <summary>
        ///     Gets the parameters.
        /// </summary>
        /// <param name="Params">The parameters.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetParameters(
            [Out] out DEBUG_BREAKPOINT_PARAMETERS Params);

        /* IDebugBreakpoint2 */

        /// <summary>
        ///     Gets the command wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="CommandSize">Size of the command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetCommandWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        /// <summary>
        ///     Sets the command wide.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetCommandWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Command);

        /// <summary>
        ///     Gets the offset expression wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="ExpressionSize">Size of the expression.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOffsetExpressionWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ExpressionSize);

        /// <summary>
        ///     Sets the offset expression wide.
        /// </summary>
        /// <param name="Command">The command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetOffsetExpressionWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Command);
    }
}