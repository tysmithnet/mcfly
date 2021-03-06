﻿// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugControl.cs" company="">
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
    ///     Interface IDebugControl
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5182e668-105e-416e-ad92-24ef800424ba")]
    public interface IDebugControl
    {
        /* IDebugControl */

        /// <summary>
        ///     Gets the interrupt.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetInterrupt();

        /// <summary>
        ///     Sets the interrupt.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetInterrupt(
            [In] DEBUG_INTERRUPT Flags);

        /// <summary>
        ///     Gets the interrupt timeout.
        /// </summary>
        /// <param name="Seconds">The seconds.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetInterruptTimeout(
            [Out] out uint Seconds);

        /// <summary>
        ///     Sets the interrupt timeout.
        /// </summary>
        /// <param name="Seconds">The seconds.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetInterruptTimeout(
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
        int GetLogFile(
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
        int OpenLogFile(
            [In] [MarshalAs(UnmanagedType.LPStr)] string File,
            [In] [MarshalAs(UnmanagedType.Bool)] bool Append);

        /// <summary>
        ///     Closes the log file.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int CloseLogFile();

        /// <summary>
        ///     Gets the log mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetLogMask(
            [Out] out DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Sets the log mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetLogMask(
            [In] DEBUG_OUTPUT Mask);

        /// <summary>
        ///     Inputs the specified buffer.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="InputSize">Size of the input.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Input(
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint InputSize);

        /// <summary>
        ///     Returns the input.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReturnInput(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Buffer);

        /// <summary>
        ///     Outputs the specified mask.
        /// </summary>
        /// <param name="Mask">The mask.</param>
        /// <param name="Format">The format.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Output(
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
        int OutputVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
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
        int ControlledOutput(
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
        int ControlledOutputVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
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
        int OutputPrompt(
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
        int OutputPromptVaList( /* THIS SHOULD NEVER BE CALLED FROM C# */
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
        int GetPromptText(
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
        int OutputCurrentState(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_CURRENT Flags);

        /// <summary>
        ///     Outputs the version information.
        /// </summary>
        /// <param name="OutputControl">The output control.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int OutputVersionInformation(
            [In] DEBUG_OUTCTL OutputControl);

        /// <summary>
        ///     Gets the notify event handle.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNotifyEventHandle(
            [Out] out ulong Handle);

        /// <summary>
        ///     Sets the notify event handle.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetNotifyEventHandle(
            [In] ulong Handle);

        /// <summary>
        ///     Assembles the specified offset.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Instr">The instr.</param>
        /// <param name="EndOffset">The end offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int Assemble(
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
        int Disassemble(
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
        int GetDisassembleEffectiveOffset(
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
        int OutputDisassembly(
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
        int OutputDisassemblyLines(
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
        int GetNearInstruction(
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
        int GetStackTrace(
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
        int GetReturnOffset(
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
        int OutputStackTrace(
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
        int GetDebuggeeType(
            [Out] out DEBUG_CLASS Class,
            [Out] out DEBUG_CLASS_QUALIFIER Qualifier);

        /// <summary>
        ///     Gets the actual type of the processor.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetActualProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        ///     Gets the type of the executing processor.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetExecutingProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        ///     Gets the number possible executing processor types.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNumberPossibleExecutingProcessorTypes(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the possible executing processor types.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Types">The types.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetPossibleExecutingProcessorTypes(
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
        int GetNumberProcessors(
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
        int GetSystemVersion(
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
        int GetPageSize(
            [Out] out uint Size);

        /// <summary>
        ///     Determines whether [is pointer64 bit].
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int IsPointer64Bit();

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
        int ReadBugCheckData(
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
        int GetNumberSupportedProcessorTypes(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the supported processor types.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Count">The count.</param>
        /// <param name="Types">The types.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSupportedProcessorTypes(
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
        int GetProcessorTypeNames(
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
        int GetEffectiveProcessorType(
            [Out] out IMAGE_FILE_MACHINE Type);

        /// <summary>
        ///     Sets the type of the effective processor.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetEffectiveProcessorType(
            [In] IMAGE_FILE_MACHINE Type);

        /// <summary>
        ///     Gets the execution status.
        /// </summary>
        /// <param name="Status">The status.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetExecutionStatus(
            [Out] out DEBUG_STATUS Status);

        /// <summary>
        ///     Sets the execution status.
        /// </summary>
        /// <param name="Status">The status.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetExecutionStatus(
            [In] DEBUG_STATUS Status);

        /// <summary>
        ///     Gets the code level.
        /// </summary>
        /// <param name="Level">The level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetCodeLevel(
            [Out] out DEBUG_LEVEL Level);

        /// <summary>
        ///     Sets the code level.
        /// </summary>
        /// <param name="Level">The level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetCodeLevel(
            [In] DEBUG_LEVEL Level);

        /// <summary>
        ///     Gets the engine options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetEngineOptions(
            [Out] out DEBUG_ENGOPT Options);

        /// <summary>
        ///     Adds the engine options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int AddEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        ///     Removes the engine options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int RemoveEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        ///     Sets the engine options.
        /// </summary>
        /// <param name="Options">The options.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetEngineOptions(
            [In] DEBUG_ENGOPT Options);

        /// <summary>
        ///     Gets the system error control.
        /// </summary>
        /// <param name="OutputLevel">The output level.</param>
        /// <param name="BreakLevel">The break level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetSystemErrorControl(
            [Out] out ERROR_LEVEL OutputLevel,
            [Out] out ERROR_LEVEL BreakLevel);

        /// <summary>
        ///     Sets the system error control.
        /// </summary>
        /// <param name="OutputLevel">The output level.</param>
        /// <param name="BreakLevel">The break level.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetSystemErrorControl(
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
        int GetTextMacro(
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
        int SetTextMacro(
            [In] uint Slot,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Macro);

        /// <summary>
        ///     Gets the radix.
        /// </summary>
        /// <param name="Radix">The radix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetRadix(
            [Out] out uint Radix);

        /// <summary>
        ///     Sets the radix.
        /// </summary>
        /// <param name="Radix">The radix.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SetRadix(
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
        int Evaluate(
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
        int CoerceValue(
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
        int CoerceValues(
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
        int Execute(
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
        int ExecuteCommandFile(
            [In] DEBUG_OUTCTL OutputControl,
            [In] [MarshalAs(UnmanagedType.LPStr)] string CommandFile,
            [In] DEBUG_EXECUTE Flags);

        /// <summary>
        ///     Gets the number breakpoints.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNumberBreakpoints(
            [Out] out uint Number);

        /// <summary>
        ///     Gets the index of the breakpoint by.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="bp">The bp.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetBreakpointByIndex(
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
        int GetBreakpointById(
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
        int GetBreakpointParameters(
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
        int AddBreakpoint(
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
        int RemoveBreakpoint(
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
        int AddExtension(
            [In] [MarshalAs(UnmanagedType.LPStr)] string Path,
            [In] uint Flags,
            [Out] out ulong Handle);

        /// <summary>
        ///     Removes the extension.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int RemoveExtension(
            [In] ulong Handle);

        /// <summary>
        ///     Gets the extension by path.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetExtensionByPath(
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
        int CallExtension(
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
        int GetExtensionFunction(
            [In] ulong Handle,
            [In] [MarshalAs(UnmanagedType.LPStr)] string FuncName,
            [Out] out IntPtr Function);

        /// <summary>
        ///     Gets the windbg extension apis32.
        /// </summary>
        /// <param name="Api">The API.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetWindbgExtensionApis32(
            [In] [Out] ref WINDBG_EXTENSION_APIS Api);

        /* Must be In and Out as the nSize member has to be initialized */

        /// <summary>
        ///     Gets the windbg extension apis64.
        /// </summary>
        /// <param name="Api">The API.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetWindbgExtensionApis64(
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
        int GetNumberEventFilters(
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
        int GetEventFilterText(
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
        int GetEventFilterCommand(
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
        int SetEventFilterCommand(
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
        int GetSpecificFilterParameters(
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
        int SetSpecificFilterParameters(
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
        int GetSpecificEventFilterArgument(
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
        int SetSpecificEventFilterArgument(
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
        int GetExceptionFilterParameters(
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
        int SetExceptionFilterParameters(
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
        int GetExceptionFilterSecondCommand(
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
        int SetExceptionFilterSecondCommand(
            [In] uint Index,
            [In] [MarshalAs(UnmanagedType.LPStr)] string Command);

        /// <summary>
        ///     Waits for event.
        /// </summary>
        /// <param name="Flags">The flags.</param>
        /// <param name="Timeout">The timeout.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int WaitForEvent(
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
        int GetLastEventInformation(
            [Out] out DEBUG_EVENT Type,
            [Out] out uint ProcessId,
            [Out] out uint ThreadId,
            [In] IntPtr ExtraInformation,
            [In] uint ExtraInformationSize,
            [Out] out uint ExtraInformationUsed,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] int DescriptionSize,
            [Out] out uint DescriptionUsed);
    }
}