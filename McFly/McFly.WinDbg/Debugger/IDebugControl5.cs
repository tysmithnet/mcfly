// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugControl5.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace McFly.WinDbg.Debugger
{
    /// <summary>
    ///     Interface IDebugControl5
    /// </summary>
    /// <seealso cref="IDebugControl4" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("b2ffe162-2412-429f-8d1d-5bf6dd824696")]
    public interface IDebugControl5 : IDebugControl4
    {
        /* IDebugControl */

        /// <summary>
        ///     Gets the interrupt.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetInterrupt();

        /// <summary>
        ///     Sets the interrupt.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetInterrupt(
            [In] DEBUG_INTERRUPT Flags);

        /// <summary>
        ///     Gets the interrupt timeout.
        /// </summary>
        /// <param name="Seconds">The seconds.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetInterruptTimeout(
            [Out] out uint Seconds);

        /// <summary>
        ///     Sets the interrupt timeout.
        /// </summary>
        /// <param name="Seconds">The seconds.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetInterruptTimeout(
            [In] uint Seconds);

        /// <summary>
        ///     Gets the log file.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="FileSize">Size of the file.</param>
        /// <param name="Append">if set to <c>true</c> [append].</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLogFile(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out] [MarshalAs(UnmanagedType.Bool)] out bool Append);

        /// <summary>
        ///     Opens the log file.
        /// </summary>
        /// <param name="File">The file.</param>
        /// <param name="Append">if set to <c>true</c> [append].</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OpenLogFile(
            [In] [MarshalAs(UnmanagedType.LPStr)] string File,
            [In] [MarshalAs(UnmanagedType.Bool)] bool Append);

        /// <summary>
        ///     Closes the log file.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CloseLogFile();

        /// <summary>
        ///     Gets the log mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLogMask(
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Sets the log mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetLogMask(
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Inputs the specified buffer.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="InputSize">Size of the input.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int Input(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint InputSize);

        /// <summary>
        ///     Returns the input.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReturnInput(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Buffer);

        /// <summary>
        ///     Outputs the specified mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int Output(
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Format);

        /// <summary>
        ///     Outputs the va list.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <param name="va_list_Args">The va list arguments.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        ///     Controlleds the output.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ControlledOutput(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Format);

        /// <summary>
        ///     Controlleds the output va list.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <param name="va_list_Args">The va list arguments.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ControlledOutputVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        ///     Outputs the prompt.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Format">The format.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputPrompt(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Format);

        /// <summary>
        ///     Outputs the prompt va list.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Format">The format.</param>
        /// <param name="va_list_Args">The va list arguments.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputPromptVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        ///     Gets the prompt text.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="TextSize">Size of the text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetPromptText(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        /// <summary>
        ///     Outputs the state of the current.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputCurrentState(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_CURRENT Flags);

        /// <summary>
        ///     Outputs the version information.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputVersionInformation(
            [In] DEBUG_OUTCTL OutputControl);

        /// <summary>
        ///     Gets the notify event handle.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNotifyEventHandle(
            [Out] out ulong Handle);

        /// <summary>
        ///     Sets the notify event handle.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetNotifyEventHandle(
            [In] ulong Handle);

        /// <summary>
        ///     Assembles the specified offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Instr">The instr.</param>
        /// <param name="EndOffset">The end offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int Assemble(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Instr,
            [Out] out ulong EndOffset);

        /// <summary>
        ///     Disassembles the specified offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DisassemblySize">Size of the disassembly.</param>
        /// <param name="EndOffset">The end offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int Disassemble(
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DisassemblySize,
            [Out] out ulong EndOffset);

        /// <summary>
        ///     Gets the disassemble effective offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetDisassembleEffectiveOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Outputs the disassembly.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="EndOffset">The end offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputDisassembly(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out ulong EndOffset);

        /// <summary>
        ///     Outputs the disassembly lines.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="PreviousLines">The previous lines.</param>
        /// <param name="TotalLines">The total lines.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="OffsetLine">The offset line.</param>
        /// <param name="StartOffset">The start offset.</param>
        /// <param name="EndOffset">The end offset.</param>
        /// <param name="LineOffsets">The line offsets.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputDisassemblyLines(
            [In] DEBUG_OUTCTL OutputControl,
            [In] uint PreviousLines,
            [In] uint TotalLines,
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] out uint OffsetLine,
            [Out] out ulong StartOffset,
            [Out] out ulong EndOffset,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] LineOffsets);

        /// <summary>
        ///     Gets the near instruction.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Delta">The delta.</param>
        /// <param name="NearOffset">The near offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNearInstruction(
            [In] ulong Offset,
            [In] int Delta,
            [Out] out ulong NearOffset);

        /// <summary>
        ///     Gets the stack trace.
        /// </summary>
        /// <param name="FrameOffset">The frame offset.</param>
        /// <param name="StackOffset">The stack offset.</param>
        /// <param name="InstructionOffset">The instruction offset.</param>
        /// <param name="Frames">The frames.</param>
        /// <param name="FrameSize">Size of the frame.</param>
        /// <param name="FramesFilled">The frames filled.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetStackTrace(
            [In] ulong FrameOffset,
            [In] ulong StackOffset,
            [In] ulong InstructionOffset,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [Out] out uint FramesFilled);

        /// <summary>
        ///     Gets the return offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetReturnOffset(
            [Out] out ulong Offset);

        /// <summary>
        ///     Outputs the stack trace.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Frames">The frames.</param>
        /// <param name="FramesSize">Size of the frames.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] DEBUG_STACK Flags);

        /// <summary>
        ///     Gets the type of the debuggee.
        /// </summary>
        /// <param name="Class">The class.</param>
        /// <param name="Qualifier">The qualifier.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetDebuggeeType(
            [Out] out DEBUG_CLASS Class,
            [Out] out DEBUG_CLASS_QUALIFIER Qualifier);

        /// <summary>
        ///     Gets the actual type of the processor.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetActualProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        ///     Gets the type of the executing processor.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExecutingProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        ///     Gets the number possible executing processor types.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberPossibleExecutingProcessorTypes(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the possible executing processor types.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Types">The types.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetPossibleExecutingProcessorTypes(
            [In] uint Start,
            [In] uint Count,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            IMAGE_FILE_MACHINE[] Types);

        /// <summary>
        ///     Gets the number processors.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberProcessors(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the system version.
        /// </summary>
        /// <param name="PlatformId">The platform identifier.</param>
        /// <param name="Major">The major.</param>
        /// <param name="Minor">The minor.</param>
        /// <param name="ServicePackString">The service pack string.</param>
        /// <param name="ServicePackStringSize">Size of the service pack string.</param>
        /// <param name="ServicePackStringUsed">The service pack string used.</param>
        /// <param name="ServicePackNumber">The service pack number.</param>
        /// <param name="BuildString">The build string.</param>
        /// <param name="BuildStringSize">Size of the build string.</param>
        /// <param name="BuildStringUsed">The build string used.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSystemVersion(
            [Out] out uint PlatformId,
            [Out] out uint Major,
            [Out] out uint Minor,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder ServicePackString,
            [In] int ServicePackStringSize,
            [Out] out uint ServicePackStringUsed,
            [Out] out uint ServicePackNumber,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder BuildString,
            [In] int BuildStringSize,
            [Out] out uint BuildStringUsed);

        /// <summary>
        ///     Gets the size of the page.
        /// </summary>
        /// <param name="Size">The size.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetPageSize(
            [Out] out uint Size);

        /// <summary>
        ///     Determines whether [is pointer64 bit].
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int IsPointer64Bit();

        /// <summary>
        ///     Reads the bug check data.
        /// </summary>
        /// <param name="Code">The code.</param>
        /// <param name="Arg1">The arg1.</param>
        /// <param name="Arg2">The arg2.</param>
        /// <param name="Arg3">The arg3.</param>
        /// <param name="Arg4">The arg4.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadBugCheckData(
            [Out] out uint Code,
            [Out] out ulong Arg1,
            [Out] out ulong Arg2,
            [Out] out ulong Arg3,
            [Out] out ulong Arg4);

        /// <summary>
        ///     Gets the number supported processor types.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberSupportedProcessorTypes(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the supported processor types.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Types">The types.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSupportedProcessorTypes(
            [In] uint Start,
            [In] uint Count,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            IMAGE_FILE_MACHINE[] Types);

        /// <summary>
        ///     Gets the processor type names.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="FullNameBuffer">The full name buffer.</param>
        /// <param name="FullNameBufferSize">Full size of the name buffer.</param>
        /// <param name="FullNameSize">Full size of the name.</param>
        /// <param name="AbbrevNameBuffer">The abbrev name buffer.</param>
        /// <param name="AbbrevNameBufferSize">Size of the abbrev name buffer.</param>
        /// <param name="AbbrevNameSize">Size of the abbrev name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetProcessorTypeNames(
            [In] IMAGE_FILE_MACHINE Type,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        /// <summary>
        ///     Gets the type of the effective processor.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEffectiveProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        ///     Sets the type of the effective processor.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetEffectiveProcessorType(
            [In] IMAGE_FILE_MACHINE Type);

        /// <summary>
        ///     Gets the execution status.
        /// </summary>
        /// <param name="Status">The status.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExecutionStatus(
            [Out] out DEBUG_STATUS Status);

        /// <summary>
        ///     Sets the execution status.
        /// </summary>
        /// <param name="Status">The status.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetExecutionStatus(
            [In] DEBUG_STATUS Status);

        /// <summary>
        ///     Gets the code level.
        /// </summary>
        /// <param name="Level">The level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCodeLevel(
            [Out] out DEBUG_LEVEL Level);

        /// <summary>
        ///     Sets the code level.
        /// </summary>
        /// <param name="Level">The level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetCodeLevel(
            [In] DEBUG_LEVEL Level);

        /// <summary>
        ///     Gets the engine options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEngineOptions(
            [Out] out DEBUG_ENGOPT Options);

        /// <summary>
        ///     Adds the engine options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        ///     Removes the engine options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        ///     Sets the engine options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        ///     Gets the system error control.
        /// </summary>
        /// <param name="OutputLevel">The output level.</param>
        /// <param name="BreakLevel">The break level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSystemErrorControl(
            [Out] out ERROR_LEVEL OutputLevel,
            [Out] out ERROR_LEVEL BreakLevel);

        /// <summary>
        ///     Sets the system error control.
        /// </summary>
        /// <param name="OutputLevel">The output level.</param>
        /// <param name="BreakLevel">The break level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSystemErrorControl(
            [In] ERROR_LEVEL OutputLevel,
            [In] ERROR_LEVEL BreakLevel);

        /// <summary>
        ///     Gets the text macro.
        /// </summary>
        /// <param name="Slot">The slot.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="MacroSize">Size of the macro.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTextMacro(
            [In] uint Slot,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MacroSize);

        /// <summary>
        ///     Sets the text macro.
        /// </summary>
        /// <param name="Slot">The slot.</param>
        /// <param name="Macro">The macro.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetTextMacro(
            [In] uint Slot,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Macro);

        /// <summary>
        ///     Gets the radix.
        /// </summary>
        /// <param name="Radix">The radix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetRadix(
            [Out] out uint Radix);

        /// <summary>
        ///     Sets the radix.
        /// </summary>
        /// <param name="Radix">The radix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetRadix(
            [In] uint Radix);

        /// <summary>
        ///     Evaluates the specified expression.
        /// </summary>
        /// <param name="Expression">The expression.</param>
        /// <param name="DesiredType">Type of the desired.</param>
        /// <param name="Value">The value.</param>
        /// <param name="RemainderIndex">Index of the remainder.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int Evaluate(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out uint RemainderIndex);

        /// <summary>
        ///     Coerces the value.
        /// </summary>
        /// <param name="In">The in.</param>
        /// <param name="OutType">Type of the out.</param>
        /// <param name="Out">The out.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CoerceValue(
            [In] DEBUG_VALUE In,
            [In] DEBUG_VALUE_TYPE OutType,
            [Out] out DEBUG_VALUE Out);

        /// <summary>
        ///     Coerces the values.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="In">The in.</param>
        /// <param name="OutType">Type of the out.</param>
        /// <param name="Out">The out.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CoerceValues(
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] In,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE_TYPE[] OutType,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_VALUE[] Out);

        /// <summary>
        ///     Executes the specified output control.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Command">The command.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int Execute(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Command,
            [In] DEBUG_EXECUTE Flags);

        /// <summary>
        ///     Executes the command file.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="CommandFile">The command file.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ExecuteCommandFile(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);

        /// <summary>
        ///     Gets the number breakpoints.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberBreakpoints(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the index of the breakpoint by.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetBreakpointByIndex(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint bp);

        /// <summary>
        ///     Gets the breakpoint by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetBreakpointById(
            [In] uint Id,
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint bp);

        /// <summary>
        ///     Gets the breakpoint parameters.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Ids">The ids.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Params">The parameters.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetBreakpointParameters(
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            uint[] Ids,
            [In] uint Start,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_BREAKPOINT_PARAMETERS[] Params);

        /// <summary>
        ///     Adds the breakpoint.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="DesiredId">The desired identifier.</param>
        /// <param name="Bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddBreakpoint(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] uint DesiredId,
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint Bp);

        /// <summary>
        ///     Removes the breakpoint.
        /// </summary>
        /// <param name="Bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveBreakpoint(
            [In] [MarshalAs(UnmanagedType.Interface)]
            IDebugBreakpoint Bp);

        /// <summary>
        ///     Adds the extension.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddExtension(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Path,
            [In] uint Flags,
            [Out] out ulong Handle);

        /// <summary>
        ///     Removes the extension.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveExtension(
            [In] ulong Handle);

        /// <summary>
        ///     Gets the extension by path.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExtensionByPath(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Path,
            [Out] out ulong Handle);

        /// <summary>
        ///     Calls the extension.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="Function">The function.</param>
        /// <param name="Arguments">The arguments.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CallExtension(
            [In] ulong Handle,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Function,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Arguments);

        /// <summary>
        ///     Gets the extension function.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="FuncName">Name of the function.</param>
        /// <param name="Function">The function.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExtensionFunction(
            [In] ulong Handle,
            [In] [MarshalAs(UnmanagedType.LPStr)] string FuncName,
            [Out] out IntPtr Function);

        /// <summary>
        ///     Gets the windbg extension apis32.
        /// </summary>
        /// <param name="Api">The API.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetWindbgExtensionApis32(
            [In] [Out] ref WINDBG_EXTENSION_APIS Api);

        /* Must be In and Out as the nSize member has to be initialized */

        /// <summary>
        ///     Gets the windbg extension apis64.
        /// </summary>
        /// <param name="Api">The API.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetWindbgExtensionApis64(
            [In] [Out] ref WINDBG_EXTENSION_APIS Api);

        /* Must be In and Out as the nSize member has to be initialized */

        /// <summary>
        ///     Gets the number event filters.
        /// </summary>
        /// <param name="SpecificEvents">The specific events.</param>
        /// <param name="SpecificExceptions">The specific exceptions.</param>
        /// <param name="ArbitraryExceptions">The arbitrary exceptions.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberEventFilters(
            [Out] out uint SpecificEvents,
            [Out] out uint SpecificExceptions,
            [Out] out uint ArbitraryExceptions);

        /// <summary>
        ///     Gets the event filter text.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="TextSize">Size of the text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEventFilterText(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        /// <summary>
        ///     Gets the event filter command.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="CommandSize">Size of the command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEventFilterCommand(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        /// <summary>
        ///     Sets the event filter command.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Command">The command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetEventFilterCommand(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Command);

        /// <summary>
        ///     Gets the specific filter parameters.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Params">The parameters.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSpecificFilterParameters(
            [In] uint Start,
            [In] uint Count,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);

        /// <summary>
        ///     Sets the specific filter parameters.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Params">The parameters.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSpecificFilterParameters(
            [In] uint Start,
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_SPECIFIC_FILTER_PARAMETERS[] Params);

        /// <summary>
        ///     Gets the specific event filter argument.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="ArgumentSize">Size of the argument.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSpecificEventFilterArgument(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ArgumentSize);

        /// <summary>
        ///     Sets the specific event filter argument.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Argument">The argument.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSpecificEventFilterArgument(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Argument);

        /// <summary>
        ///     Gets the exception filter parameters.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Codes">The codes.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Params">The parameters.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExceptionFilterParameters(
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            uint[] Codes,
            [In] uint Start,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);

        /// <summary>
        ///     Sets the exception filter parameters.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Params">The parameters.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetExceptionFilterParameters(
            [In] uint Count,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_EXCEPTION_FILTER_PARAMETERS[] Params);

        /// <summary>
        ///     Gets the exception filter second command.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="CommandSize">Size of the command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExceptionFilterSecondCommand(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        /// <summary>
        ///     Sets the exception filter second command.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Command">The command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetExceptionFilterSecondCommand(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Command);

        /// <summary>
        ///     Waits for event.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Timeout">The timeout.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WaitForEvent(
            [In] DEBUG_WAIT Flags,
            [In] uint Timeout);

        /// <summary>
        ///     Gets the last event information.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="ProcessId">The process identifier.</param>
        /// <param name="ThreadId">The thread identifier.</param>
        /// <param name="ExtraInformation">The extra information.</param>
        /// <param name="ExtraInformationSize">Size of the extra information.</param>
        /// <param name="ExtraInformationUsed">The extra information used.</param>
        /// <param name="Description">The description.</param>
        /// <param name="DescriptionSize">Size of the description.</param>
        /// <param name="DescriptionUsed">The description used.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLastEventInformation(
            [Out] out DEBUG_EVENT Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr ExtraInformation,
            [In] uint ExtraInformationSize,
            [Out] out uint ExtraInformationUsed,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint DescriptionUsed);

        /* IDebugControl2 */

        /// <summary>
        ///     Gets the current time date.
        /// </summary>
        /// <param name="TimeDate">The time date.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentTimeDate(
            [Out] out uint TimeDate);

        /// <summary>
        ///     Gets the current system up time.
        /// </summary>
        /// <param name="UpTime">Up time.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentSystemUpTime(
            [Out] out uint UpTime);

        /// <summary>
        ///     Gets the dump format flags.
        /// </summary>
        /// <param name="FormatFlags">The format flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetDumpFormatFlags(
            [Out] out DEBUG_FORMAT FormatFlags);

        /// <summary>
        ///     Gets the number text replacements.
        /// </summary>
        /// <param name="NumRepl">The number repl.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberTextReplacements(
            [Out] out uint NumRepl);

        /// <summary>
        ///     Gets the text replacement.
        /// </summary>
        /// <param name="SrcText">The source text.</param>
        /// <param name="Index">The index.</param>
        /// <param name="SrcBuffer">The source buffer.</param>
        /// <param name="SrcBufferSize">Size of the source buffer.</param>
        /// <param name="SrcSize">Size of the source.</param>
        /// <param name="DstBuffer">The DST buffer.</param>
        /// <param name="DstBufferSize">Size of the DST buffer.</param>
        /// <param name="DstSize">Size of the DST.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTextReplacement(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder SrcBuffer,
            [In] int SrcBufferSize,
            [Out] out uint SrcSize,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder DstBuffer,
            [In] int DstBufferSize,
            [Out] out uint DstSize);

        /// <summary>
        ///     Sets the text replacement.
        /// </summary>
        /// <param name="SrcText">The source text.</param>
        /// <param name="DstText">The DST text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetTextReplacement(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SrcText,
            [In] [MarshalAs(UnmanagedType.LPStr)] string DstText);

        /// <summary>
        ///     Removes the text replacements.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveTextReplacements();

        /// <summary>
        ///     Outputs the text replacements.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputTextReplacements(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUT_TEXT_REPL Flags);

        /* IDebugControl3 */

        /// <summary>
        ///     Gets the assembly options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetAssemblyOptions(
            [Out] out DEBUG_ASMOPT Options);

        /// <summary>
        ///     Adds the assembly options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        /// <summary>
        ///     Removes the assembly options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        /// <summary>
        ///     Sets the assembly options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetAssemblyOptions(
            [In] DEBUG_ASMOPT Options);

        /// <summary>
        ///     Gets the expression syntax.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExpressionSyntax(
            [Out] out DEBUG_EXPR Flags);

        /// <summary>
        ///     Sets the expression syntax.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetExpressionSyntax(
            [In] DEBUG_EXPR Flags);

        /// <summary>
        ///     Sets the name of the expression syntax by.
        /// </summary>
        /// <param name="AbbrevName">Name of the abbrev.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetExpressionSyntaxByName(
            [In] [MarshalAs(UnmanagedType.LPStr)] string AbbrevName);

        /// <summary>
        ///     Gets the number expression syntaxes.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberExpressionSyntaxes(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the expression syntax names.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="FullNameBuffer">The full name buffer.</param>
        /// <param name="FullNameBufferSize">Full size of the name buffer.</param>
        /// <param name="FullNameSize">Full size of the name.</param>
        /// <param name="AbbrevNameBuffer">The abbrev name buffer.</param>
        /// <param name="AbbrevNameBufferSize">Size of the abbrev name buffer.</param>
        /// <param name="AbbrevNameSize">Size of the abbrev name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExpressionSyntaxNames(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        /// <summary>
        ///     Gets the number events.
        /// </summary>
        /// <param name="Events">The events.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNumberEvents(
            [Out] out uint Events);

        /// <summary>
        ///     Gets the event index description.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Which">The which.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DescSize">Size of the desc.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEventIndexDescription(
            [In] uint Index,
            [In] DEBUG_EINDEX Which,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DescSize);

        /// <summary>
        ///     Gets the index of the current event.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetCurrentEventIndex(
            [Out] out uint Index);

        /// <summary>
        ///     Sets the index of the next event.
        /// </summary>
        /// <param name="Relation">The relation.</param>
        /// <param name="Value">The value.</param>
        /// <param name="NextIndex">Index of the next.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetNextEventIndex(
            [In] DEBUG_EINDEX Relation,
            [In] uint Value,
            [Out] out uint NextIndex);

        /* IDebugControl4 */

        /// <summary>
        ///     Gets the log file wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="FileSize">Size of the file.</param>
        /// <param name="Append">if set to <c>true</c> [append].</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLogFileWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out] [MarshalAs(UnmanagedType.Bool)] out bool Append);

        /// <summary>
        ///     Opens the log file wide.
        /// </summary>
        /// <param name="File">The file.</param>
        /// <param name="Append">if set to <c>true</c> [append].</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OpenLogFileWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] [MarshalAs(UnmanagedType.Bool)] bool Append);

        /// <summary>
        ///     Inputs the wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="InputSize">Size of the input.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int InputWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint InputSize);

        /// <summary>
        ///     Returns the input wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReturnInputWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Buffer);

        /// <summary>
        ///     Outputs the wide.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputWide(
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Format);

        /// <summary>
        ///     Outputs the va list wide.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <param name="va_list_Args">The va list arguments.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputVaListWide( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        ///     Controlleds the output wide.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ControlledOutputWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Format);

        /// <summary>
        ///     Controlleds the output va list wide.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <param name="va_list_Args">The va list arguments.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ControlledOutputVaListWide( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT Mask,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        ///     Outputs the prompt wide.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Format">The format.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputPromptWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Format);

        /// <summary>
        ///     Outputs the prompt va list wide.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Format">The format.</param>
        /// <param name="va_list_Args">The va list arguments.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputPromptVaListWide( /* THIS SHOULD NEVER BE CALLED FROM C# */
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Format,
            [In] IntPtr va_list_Args);

        /// <summary>
        ///     Gets the prompt text wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="TextSize">Size of the text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetPromptTextWide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        /// <summary>
        ///     Assembles the wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Instr">The instr.</param>
        /// <param name="EndOffset">The end offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AssembleWide(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Instr,
            [Out] out ulong EndOffset);

        /// <summary>
        ///     Disassembles the wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DisassemblySize">Size of the disassembly.</param>
        /// <param name="EndOffset">The end offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int DisassembleWide(
            [In] ulong Offset,
            [In] DEBUG_DISASM Flags,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DisassemblySize,
            [Out] out ulong EndOffset);

        /// <summary>
        ///     Gets the processor type names wide.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="FullNameBuffer">The full name buffer.</param>
        /// <param name="FullNameBufferSize">Full size of the name buffer.</param>
        /// <param name="FullNameSize">Full size of the name.</param>
        /// <param name="AbbrevNameBuffer">The abbrev name buffer.</param>
        /// <param name="AbbrevNameBufferSize">Size of the abbrev name buffer.</param>
        /// <param name="AbbrevNameSize">Size of the abbrev name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetProcessorTypeNamesWide(
            [In] IMAGE_FILE_MACHINE Type,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        /// <summary>
        ///     Gets the text macro wide.
        /// </summary>
        /// <param name="Slot">The slot.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="MacroSize">Size of the macro.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTextMacroWide(
            [In] uint Slot,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MacroSize);

        /// <summary>
        ///     Sets the text macro wide.
        /// </summary>
        /// <param name="Slot">The slot.</param>
        /// <param name="Macro">The macro.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetTextMacroWide(
            [In] uint Slot,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Macro);

        /// <summary>
        ///     Evaluates the wide.
        /// </summary>
        /// <param name="Expression">The expression.</param>
        /// <param name="DesiredType">Type of the desired.</param>
        /// <param name="Value">The value.</param>
        /// <param name="RemainderIndex">Index of the remainder.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int EvaluateWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Expression,
            [In] DEBUG_VALUE_TYPE DesiredType,
            [Out] out DEBUG_VALUE Value,
            [Out] out uint RemainderIndex);

        /// <summary>
        ///     Executes the wide.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Command">The command.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ExecuteWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Command,
            [In] DEBUG_EXECUTE Flags);

        /// <summary>
        ///     Executes the command file wide.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="CommandFile">The command file.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ExecuteCommandFileWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);

        /// <summary>
        ///     Gets the breakpoint by index2.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetBreakpointByIndex2(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint2 bp);

        /// <summary>
        ///     Gets the breakpoint by id2.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetBreakpointById2(
            [In] uint Id,
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint2 bp);

        /// <summary>
        ///     Adds the breakpoint2.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="DesiredId">The desired identifier.</param>
        /// <param name="Bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddBreakpoint2(
            [In] DEBUG_BREAKPOINT_TYPE Type,
            [In] uint DesiredId,
            [Out] [MarshalAs(UnmanagedType.Interface)]
            out IDebugBreakpoint2 Bp);

        /// <summary>
        ///     Removes the breakpoint2.
        /// </summary>
        /// <param name="Bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int RemoveBreakpoint2(
            [In] [MarshalAs(UnmanagedType.Interface)]
            IDebugBreakpoint2 Bp);

        /// <summary>
        ///     Adds the extension wide.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int AddExtensionWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Path,
            [In] uint Flags,
            [Out] out ulong Handle);

        /// <summary>
        ///     Gets the extension by path wide.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExtensionByPathWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Path,
            [Out] out ulong Handle);

        /// <summary>
        ///     Calls the extension wide.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="Function">The function.</param>
        /// <param name="Arguments">The arguments.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CallExtensionWide(
            [In] ulong Handle,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Function,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Arguments);

        /// <summary>
        ///     Gets the extension function wide.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="FuncName">Name of the function.</param>
        /// <param name="Function">The function.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExtensionFunctionWide(
            [In] ulong Handle,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string FuncName,
            [Out] out IntPtr Function);

        /// <summary>
        ///     Gets the event filter text wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="TextSize">Size of the text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEventFilterTextWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint TextSize);

        /// <summary>
        ///     Gets the event filter command wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="CommandSize">Size of the command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEventFilterCommandWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        /// <summary>
        ///     Sets the event filter command wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Command">The command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetEventFilterCommandWide(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Command);

        /// <summary>
        ///     Gets the specific event filter argument wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="ArgumentSize">Size of the argument.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSpecificEventFilterArgumentWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ArgumentSize);

        /// <summary>
        ///     Sets the specific event filter argument wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Argument">The argument.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetSpecificEventFilterArgumentWide(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Argument);

        /// <summary>
        ///     Gets the exception filter second command wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="CommandSize">Size of the command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExceptionFilterSecondCommandWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        /// <summary>
        ///     Sets the exception filter second command wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Command">The command.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetExceptionFilterSecondCommandWide(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string Command);

        /// <summary>
        ///     Gets the last event information wide.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="ProcessId">The process identifier.</param>
        /// <param name="ThreadId">The thread identifier.</param>
        /// <param name="ExtraInformation">The extra information.</param>
        /// <param name="ExtraInformationSize">Size of the extra information.</param>
        /// <param name="ExtraInformationUsed">The extra information used.</param>
        /// <param name="Description">The description.</param>
        /// <param name="DescriptionSize">Size of the description.</param>
        /// <param name="DescriptionUsed">The description used.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLastEventInformationWide(
            [Out] out DEBUG_EVENT Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr ExtraInformation,
            [In] int ExtraInformationSize,
            [Out] out uint ExtraInformationUsed,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint DescriptionUsed);

        /// <summary>
        ///     Gets the text replacement wide.
        /// </summary>
        /// <param name="SrcText">The source text.</param>
        /// <param name="Index">The index.</param>
        /// <param name="SrcBuffer">The source buffer.</param>
        /// <param name="SrcBufferSize">Size of the source buffer.</param>
        /// <param name="SrcSize">Size of the source.</param>
        /// <param name="DstBuffer">The DST buffer.</param>
        /// <param name="DstBufferSize">Size of the DST buffer.</param>
        /// <param name="DstSize">Size of the DST.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetTextReplacementWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder SrcBuffer,
            [In] int SrcBufferSize,
            [Out] out uint SrcSize,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder DstBuffer,
            [In] int DstBufferSize,
            [Out] out uint DstSize);

        /// <summary>
        ///     Sets the text replacement wide.
        /// </summary>
        /// <param name="SrcText">The source text.</param>
        /// <param name="DstText">The DST text.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetTextReplacementWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string SrcText,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string DstText);

        /// <summary>
        ///     Sets the expression syntax by name wide.
        /// </summary>
        /// <param name="AbbrevName">Name of the abbrev.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SetExpressionSyntaxByNameWide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string AbbrevName);

        /// <summary>
        ///     Gets the expression syntax names wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="FullNameBuffer">The full name buffer.</param>
        /// <param name="FullNameBufferSize">Full size of the name buffer.</param>
        /// <param name="FullNameSize">Full size of the name.</param>
        /// <param name="AbbrevNameBuffer">The abbrev name buffer.</param>
        /// <param name="AbbrevNameBufferSize">Size of the abbrev name buffer.</param>
        /// <param name="AbbrevNameSize">Size of the abbrev name.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetExpressionSyntaxNamesWide(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder FullNameBuffer,
            [In] int FullNameBufferSize,
            [Out] out uint FullNameSize,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder AbbrevNameBuffer,
            [In] int AbbrevNameBufferSize,
            [Out] out uint AbbrevNameSize);

        /// <summary>
        ///     Gets the event index description wide.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Which">The which.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DescSize">Size of the desc.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetEventIndexDescriptionWide(
            [In] uint Index,
            [In] DEBUG_EINDEX Which,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint DescSize);

        /// <summary>
        ///     Gets the log file2.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="FileSize">Size of the file.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLogFile2(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out] out DEBUG_LOG Flags);

        /// <summary>
        ///     Opens the log file2.
        /// </summary>
        /// <param name="File">The file.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OpenLogFile2(
            [In] [MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out DEBUG_LOG Flags);

        /// <summary>
        ///     Gets the log file2 wide.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="FileSize">Size of the file.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetLogFile2Wide(
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FileSize,
            [Out] out DEBUG_LOG Flags);

        /// <summary>
        ///     Opens the log file2 wide.
        /// </summary>
        /// <param name="File">The file.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OpenLogFile2Wide(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out DEBUG_LOG Flags);

        /// <summary>
        ///     Gets the system version values.
        /// </summary>
        /// <param name="PlatformId">The platform identifier.</param>
        /// <param name="Win32Major">The win32 major.</param>
        /// <param name="Win32Minor">The win32 minor.</param>
        /// <param name="KdMajor">The kd major.</param>
        /// <param name="KdMinor">The kd minor.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSystemVersionValues(
            [Out] out uint PlatformId,
            [Out] out uint Win32Major,
            [Out] out uint Win32Minor,
            [Out] out uint KdMajor,
            [Out] out uint KdMinor);

        /// <summary>
        ///     Gets the system version string.
        /// </summary>
        /// <param name="Which">The which.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSystemVersionString(
            [In] DEBUG_SYSVERSTR Which,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        /// <summary>
        ///     Gets the system version string wide.
        /// </summary>
        /// <param name="Which">The which.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetSystemVersionStringWide(
            [In] DEBUG_SYSVERSTR Which,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        /// <summary>
        ///     Gets the context stack trace.
        /// </summary>
        /// <param name="StartContext">The start context.</param>
        /// <param name="StartContextSize">Start size of the context.</param>
        /// <param name="Frames">The frames.</param>
        /// <param name="FrameSize">Size of the frame.</param>
        /// <param name="FrameContexts">The frame contexts.</param>
        /// <param name="FrameContextsSize">Size of the frame contexts.</param>
        /// <param name="FrameContextsEntrySize">Size of the frame contexts entry.</param>
        /// <param name="FramesFilled">The frames filled.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetContextStackTrace(
            [In] IntPtr StartContext,
            [In] uint StartContextSize,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_STACK_FRAME[] Frames,
            [In] int FrameSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [Out] out uint FramesFilled);

        /// <summary>
        ///     Outputs the context stack trace.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Frames">The frames.</param>
        /// <param name="FramesSize">Size of the frames.</param>
        /// <param name="FrameContexts">The frame contexts.</param>
        /// <param name="FrameContextsSize">Size of the frame contexts.</param>
        /// <param name="FrameContextsEntrySize">Size of the frame contexts entry.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int OutputContextStackTrace(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_STACK_FRAME[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [In] DEBUG_STACK Flags);

        /// <summary>
        ///     Gets the stored event information.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="ProcessId">The process identifier.</param>
        /// <param name="ThreadId">The thread identifier.</param>
        /// <param name="Context">The context.</param>
        /// <param name="ContextSize">Size of the context.</param>
        /// <param name="ContextUsed">The context used.</param>
        /// <param name="ExtraInformation">The extra information.</param>
        /// <param name="ExtraInformationSize">Size of the extra information.</param>
        /// <param name="ExtraInformationUsed">The extra information used.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetStoredEventInformation(
            [Out] out DEBUG_EVENT Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr Context,
            [In] uint ContextSize,
            [Out] out uint ContextUsed,
            [In] IntPtr ExtraInformation,
            [In] uint ExtraInformationSize,
            [Out] out uint ExtraInformationUsed);

        /// <summary>
        ///     Gets the managed status.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="WhichString">The which string.</param>
        /// <param name="String">The string.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <param name="StringNeeded">The string needed.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetManagedStatus(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder String,
            [In] int StringSize,
            [Out] out uint StringNeeded);

        /// <summary>
        ///     Gets the managed status wide.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="WhichString">The which string.</param>
        /// <param name="String">The string.</param>
        /// <param name="StringSize">Size of the string.</param>
        /// <param name="StringNeeded">The string needed.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetManagedStatusWide(
            [Out] out DEBUG_MANAGED Flags,
            [In] DEBUG_MANSTR WhichString,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder String,
            [In] int StringSize,
            [Out] out uint StringNeeded);

        /// <summary>
        ///     Resets the managed status.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ResetManagedStatus(
            [In] DEBUG_MANRESET Flags);

        /* IDebugControl5 */

        /// <summary>
        ///     Gets the stack trace ex.
        /// </summary>
        /// <param name="FrameOffset">The frame offset.</param>
        /// <param name="StackOffset">The stack offset.</param>
        /// <param name="InstructionOffset">The instruction offset.</param>
        /// <param name="Frames">The frames.</param>
        /// <param name="FramesSize">Size of the frames.</param>
        /// <param name="FramesFilled">The frames filled.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetStackTraceEx(
            [In] ulong FrameOffset,
            [In] ulong StackOffset,
            [In] ulong InstructionOffset,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [Out] out uint FramesFilled);

        /// <summary>
        ///     Outputs the stack trace ex.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Frames">The frames.</param>
        /// <param name="FramesSize">Size of the frames.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputStackTraceEx(
            [In] uint OutputControl,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] DEBUG_STACK Flags);

        /// <summary>
        ///     Gets the context stack trace ex.
        /// </summary>
        /// <param name="StartContext">The start context.</param>
        /// <param name="StartContextSize">Start size of the context.</param>
        /// <param name="Frames">The frames.</param>
        /// <param name="FramesSize">Size of the frames.</param>
        /// <param name="FrameContexts">The frame contexts.</param>
        /// <param name="FrameContextsSize">Size of the frame contexts.</param>
        /// <param name="FrameContextsEntrySize">Size of the frame contexts entry.</param>
        /// <param name="FramesFilled">The frames filled.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetContextStackTraceEx(
            [In] IntPtr StartContext,
            [In] uint StartContextSize,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [Out] out uint FramesFilled);

        /// <summary>
        ///     Outputs the context stack trace ex.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <param name="Frames">The frames.</param>
        /// <param name="FramesSize">Size of the frames.</param>
        /// <param name="FrameContexts">The frame contexts.</param>
        /// <param name="FrameContextsSize">Size of the frame contexts.</param>
        /// <param name="FrameContextsEntrySize">Size of the frame contexts entry.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputContextStackTraceEx(
            [In] uint OutputControl,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            DEBUG_STACK_FRAME_EX[] Frames,
            [In] int FramesSize,
            [In] IntPtr FrameContexts,
            [In] uint FrameContextsSize,
            [In] uint FrameContextsEntrySize,
            [In] DEBUG_STACK Flags);

        /// <summary>
        ///     Gets the breakpoint by unique identifier.
        /// </summary>
        /// <param name="Guid">The unique identifier.</param>
        /// <param name="Bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetBreakpointByGuid(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            Guid Guid,
            [Out] out IDebugBreakpoint3 Bp);
    }
}