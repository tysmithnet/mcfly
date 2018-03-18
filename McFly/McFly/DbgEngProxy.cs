// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-04-2018
//
// Last Modified By : master
// Last Modified On : 03-10-2018
// ***********************************************************************
// <copyright file="DbgEngProxy.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Debugger;

namespace McFly
{
    /// <summary>
    ///     Class DbgEngProxy.
    /// </summary>
    /// <seealso cref="McFly.IDbgEngProxy" />
    /// <seealso cref="System.IDisposable" />
    [Export(typeof(IDbgEngProxy))]
    [ExcludeFromCodeCoverage]
    public class DbgEngProxy : IDbgEngProxy, IDisposable
    {
        /// <summary>
        ///     The is32 bit
        /// </summary>
        private readonly bool Is32Bit;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DbgEngProxy" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="client">The client.</param>
        /// <param name="registers">The registers.</param>
        /// <param name="systemObjects"></param>
        public DbgEngProxy(IDebugControl6 control, IDebugClient5 client, IDebugRegisters2 registers, IDebugSystemObjects systemObjects)
        {
            Control = control;
            Client = client;
            Registers = registers;
            ExecuteWrapper = new ExecuteWrapper(Client);
            SystemObjects = systemObjects;
            Is32Bit =
                Regex.Match(ExecuteWrapper.Execute("!peb"), @"PEB at (?<peb>[a-fA-F0-9]+)").Groups["peb"].Value
                    .Length == 8;
        }

        public IDebugSystemObjects SystemObjects { get; set; }

        /// <summary>
        ///     Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        private IDebugControl6 Control { get; }

        /// <summary>
        ///     Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        private IDebugClient5 Client { get; }

        /// <summary>
        ///     Gets or sets the execute wrapper.
        /// </summary>
        /// <value>The execute wrapper.</value>
        private ExecuteWrapper ExecuteWrapper { get; }

        /// <summary>
        ///     Gets or sets the registers.
        /// </summary>
        /// <value>The registers.</value>
        private IDebugRegisters2 Registers { get; }

        /// <summary>
        ///     Runs the until break.
        /// </summary>
        public void RunUntilBreak()
        {
            DEBUG_STATUS status;
            var goStatuses = new[]
            {
                DEBUG_STATUS.GO, DEBUG_STATUS.STEP_BRANCH, DEBUG_STATUS.STEP_INTO, DEBUG_STATUS.STEP_OVER,
                DEBUG_STATUS.REVERSE_STEP_BRANCH, DEBUG_STATUS.REVERSE_STEP_INTO, DEBUG_STATUS.REVERSE_GO,
                DEBUG_STATUS.REVERSE_STEP_OVER
            };
            Control.SetExecutionStatus(DEBUG_STATUS.GO);
            while (true)
            {
                Control.GetExecutionStatus(out status);
                if (goStatuses.Contains(status))
                {
                    Control.WaitForEvent(DEBUG_WAIT.DEFAULT,
                        UInt32.MaxValue); // todo: make reasonable and add counter.. shouldn't wait more than 10s
                    continue;
                }

                if (status == DEBUG_STATUS.BREAK)
                    break;
            }
        }

        /// <summary>
        ///     Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>System.String.</returns>
        public string Execute(string command)
        {
            return ExecuteWrapper.Execute(command);
        }

        /// <summary>
        ///     Gets the registers.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        public RegisterSet GetRegisters(int threadId, IEnumerable<Register> registers)
        {
            var list = registers.ToList();
            if (list.Count == 0)
                return new RegisterSet();
            var registerSet = new RegisterSet();
            var registerNames = String.Join(",", list.Select(x => x.Name));
            var registerText = Execute($"~~[{threadId:X}] r {registerNames}");
            foreach (var register in list)
            {
                var numChars = Is32Bit ? 8 : 16;
                var match = Regex.Match(registerText, $"{register.Name}=(?<val>[a-fA-F0-9]{{{numChars}}})");
                var val = match.Groups["val"].Value;
                registerSet.Process(register.Name, val, 16);
            }
            return registerSet;
        }

        /// <summary>
        ///     Gets the starting position of the trace. Many times this is 35:0
        /// </summary>
        /// <returns>Position.</returns>
        public Position GetStartingPosition()
        {
            var end = Execute("!tt 0"); // todo: get from trace_info
            var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
            return Position.Parse(endMatch.Groups["pos"].Value);
        }

        /// <summary>
        ///     Gets the ending position
        /// </summary>
        /// <returns>Position.</returns>
        public Position GetEndingPosition()
        {
            var end = Execute("!tt 100"); // todo: get from trace_info
            var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
            return Position.Parse(endMatch.Groups["pos"].Value);
        }

        public void Write(string message)
        {
            Control.ControlledOutput(DEBUG_OUTCTL.ALL_CLIENTS, DEBUG_OUTPUT.NORMAL, message);
        }

        public void WriteLine(string line)
        {
            Write($"{line}\n");
        }

        public StackTrace GetStackTrace()
        {
            var stackTrace = Execute("k");
            var frames = ExtractStackFrames(stackTrace);
            return new StackTrace(GetCurrentThreadId(), frames);
        }

        public StackTrace GetStackTrace(int threadId)
        {
            var frames = GetStackFrames(threadId);
            return new StackTrace(threadId, frames);
        }

        public int GetCurrentThreadId()
        {
            SystemObjects.GetCurrentThreadId(out var threadId);
            return Convert.ToInt32(threadId);                   
        }

        /// <summary>
        ///     Strings to byte array.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] StringToByteArray(string hex)
        {
            var NumberChars = hex.Length;
            var bytes = new byte[NumberChars / 2];
            for (var i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public IEnumerable<DisassemblyLine> GetDisassemblyLines(int threadId, int numInstructions)
        {
            if(numInstructions <= 0)
                throw new ArgumentOutOfRangeException("Number of instructions must be > 0");
            var ipRegister = Is32Bit ? "eip" : "rip";
            var instructionText = Execute($"u {ipRegister} L{numInstructions}");
            var matches = Regex.Matches(instructionText,
                @"(?<ip>[a-fA-F0-9`]+)\s+(?<opcode>[a-fA-F0-9]+)\s+(?<ins>\w+)\s+(?<extra>.+)?");
            var list = new List<DisassemblyLine>();
            foreach (var match in matches.Cast<Match>())
            {
                var ip = match.Groups["ip"].Success ? Convert.ToUInt64(match.Groups["ip"].Value.Replace("`", ""), 16) : 0;
                byte[] opcode = null;
                if (match.Groups["opcode"].Success)
                    opcode = StringToByteArray(match.Groups["opcode"].Value);
                var instruction = match.Groups["ins"].Success ? match.Groups["ins"].Value : "";
                var note = match.Groups["extra"].Success ? match.Groups["extra"].Value : "";
                var newLine = new DisassemblyLine(ip, opcode, instruction, note); 
                list.Add(newLine);
            }
            return list;
        }

        public void SetCurrentPosition(Position startingPosition)
        {
            
        }

        public void SetBreakpointByMask(string breakpointMask)
        {
            Execute($"bm {breakpointMask}");
        }

        public void SetReadAccessBreakpoint(int length, ulong address)
        {
            Execute($"ba r{length} {address}");
        }

        public void SetWriteAccessBreakpoint(int length, ulong address)
        {
            Execute($"ba w{length} {address}");
        }

        public void ClearBreakpoints()
        {
            Execute($"bc *");
        }

        private static IEnumerable<StackFrame> ExtractStackFrames(string stackTrace)
        {
            var stackFrames = (from m in Regex.Matches(stackTrace,
                        @"(?<sp>[a-fA-F0-9`]+) (?<ret>[a-fA-F0-9`]+) (?<mod>.*)!(?<fun>[^+]+)\+?(?<off>[a-fA-F0-9x]+)?")
                    .Cast<Match>()
                let stackPointer = Convert.ToUInt64(m.Groups["sp"].Value.Replace("`", ""), 16)
                let returnAddress = Convert.ToUInt64(m.Groups["ret"].Value.Replace("`", ""), 16)
                let module = m.Groups["mod"].Value
                let functionName = m.Groups["fun"].Value
                let offset = m.Groups["off"].Success ? Convert.ToUInt32(m.Groups["off"].Value, 16) : 0
                select new StackFrame(stackPointer, returnAddress, module, functionName, offset)).ToList();
            return stackFrames;
        }

        public IEnumerable<StackFrame> GetStackFrames(int threadId)
        {
            var command = $"~~[{threadId:X}] k";
            var raw = Execute(command);
            return ExtractStackFrames(raw);
        }



        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            ExecuteWrapper?.Dispose();
        }
    }
}