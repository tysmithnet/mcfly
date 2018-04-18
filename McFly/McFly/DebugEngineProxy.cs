// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
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
using System.Text;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Debugger;
using Newtonsoft.Json;

namespace McFly
{
    /// <summary>
    ///     Default implementation for interfacing with the debug engine
    /// </summary>
    /// <seealso cref="McFly.IDebugEngineProxy" />
    /// <seealso cref="IDebugEngineProxy" />
    /// <seealso cref="System.IDisposable" />
    [Export(typeof(IDebugEngineProxy))]
    [ExcludeFromCodeCoverage]
    public class DebugEngineProxy : IDebugEngineProxy, IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DebugEngineProxy" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="client">The client.</param>
        /// <param name="registers">The registers.</param>
        /// <param name="systemObjects">The system objects.</param>
        public DebugEngineProxy(IDebugControl6 control, IDebugClient5 client, IDebugRegisters2 registers,
            IDebugSystemObjects systemObjects)
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

        /// <summary>
        ///     Gets or sets the system objects COM interface
        /// </summary>
        /// <value>The system objects.</value>
        private IDebugSystemObjects SystemObjects { get; }

        /// <summary>
        ///     Gets or sets the control COM interface
        /// </summary>
        /// <value>The control.</value>
        private IDebugControl6 Control { get; }

        /// <summary>
        ///     Gets or sets the client COM interface
        /// </summary>
        /// <value>The client.</value>
        private IDebugClient5 Client { get; }

        /// <summary>
        ///     Gets or sets the execute wrapper COM interface
        /// </summary>
        /// <value>The execute wrapper.</value>
        private ExecuteWrapper ExecuteWrapper { get; }

        /// <summary>
        ///     Gets or sets the registers COM interface
        /// </summary>
        /// <value>The registers.</value>
        private IDebugRegisters2 Registers { get; }

        /// <summary>
        ///     Continues execution until a breakpoint is hit or the program ends
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
                        uint.MaxValue); // todo: make reasonable and add counter.. shouldn't wait more than 10s
                    continue;
                }

                if (status == DEBUG_STATUS.BREAK)
                    break;
            }
        }

        /// <summary>
        ///     Executes the specified command
        ///     e.g. k, bl, u
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>System.String.</returns>
        public string Execute(string command)
        {
            return ExecuteWrapper.Execute(command);
        }

        /// <summary>
        ///     Writes the text to the debuggers std out
        /// </summary>
        /// <param name="message">The message.</param>
        public void Write(string message)
        {
            Control.ControlledOutput(DEBUG_OUTCTL.ALL_CLIENTS, DEBUG_OUTPUT.NORMAL, message);
        }

        /// <summary>
        ///     Writes the line to debuggers std out
        /// </summary>
        /// <param name="line">The line.</param>
        public void WriteLine(string line)
        {
            Write($"{line}\n");
        }

        /// <summary>
        ///     Gets the current thread identifier. Whenever you executes commands, they execute under a thread context. This
        ///     returns the thread id of that context.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCurrentThreadId()
        {
            SystemObjects.GetCurrentThreadId(out var threadId);
            return Convert.ToInt32(threadId);
        }

        /// <summary>
        ///     Switches to a thread
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        public void SwitchToThread(int threadId)
        {
            SystemObjects.SetCurrentThreadId(threadId.ToUInt()); // todo: what about bad thread id?
        }

        /// <summary>
        ///     Executes a command on the specified thread id
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="command">The v.</param>
        /// <returns>System.String.</returns>
        public string Execute(int threadId, string command)
        {
            return Execute($"~~[0x{threadId:X}]e {command}");
        }

        /// <inheritdoc />
        public unsafe byte[] GetRegisterValue(int threadId, Register register)
        {
            SystemObjects.SetCurrentThreadId(threadId.ToUInt());
            if (Is32Bit)
            {
                if(register.X86Index == null)
                    throw new ArgumentException();
                int hr = Registers.GetValue(register.X86Index.Value.ToUInt(), out var debugValue);
                if (hr != 0)
                {
                    throw new ApplicationException("farrrttttt");
                }

                var list = new List<byte>();
                for (int i = 0; i < register.X86NumBits / 8; i++)
                {
                    list.Add(debugValue.F128Bytes[i]);
                }

                return list.ToArray();
            }
            else
            {
                if (register.X64Index == null)
                    throw new ArgumentException();
                int hr = Registers.GetValue(register.X64Index.Value.ToUInt(), out var debugValue);
                if (hr != 0)
                {
                    throw new ApplicationException("farrrttttt");
                }

                var list = new List<byte>();
                for (int i = 0; i < register.X64NumBits / 8; i++)
                {
                    list.Add(debugValue.F128Bytes[i]);
                }

                return list.ToArray();
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the current trace is 32 bit.
        /// </summary>
        /// <value><c>true</c> if 32 bit; otherwise, <c>false</c>.</value>
        public bool Is32Bit { get; }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            ExecuteWrapper?.Dispose();
        }

        /// <summary>
        ///     Gets the last known position in the trace
        /// </summary>
        /// <returns>Position.</returns>
        public Position GetEndingPosition()
        {
            var end = Execute("!tt 100"); // todo: get from trace_info
            var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
            return Position.Parse(endMatch.Groups["pos"].Value);
        }

        public object GetRegister(uint reg)
        {
            Registers.GetNumberRegisters(out var numRegisters);
            for (int i = 0; i < numRegisters; i++)
            {
                var sb = new StringBuilder(1024);
                Registers.GetDescription(i.ToUInt(), sb, 1024, out var nameLength, out var desc);
                Registers.GetValue(i.ToUInt(), out var val);
                WriteLine($"{i}:{sb}:{desc.Type.ToString()}:{desc.Flags}");
            }
            return null;
        }
    }
}