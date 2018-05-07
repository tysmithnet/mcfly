// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="DbgEngProxy.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Core.Registers;
using McFly.WinDbg.Debugger;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Default implementation for interfacing with the debug engine
    /// </summary>
    /// <seealso cref="IDebugEngineProxy" />
    [Export(typeof(IDebugEngineProxy))]
    internal sealed class DebugEngineProxy : IDebugEngineProxy
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DebugEngineProxy" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="client">The client.</param>
        /// <param name="registers">The registers.</param>
        /// <param name="systemObjects">The system objects.</param>
        /// <param name="debugDataSpaces">The debug data spaces.</param>
        public DebugEngineProxy(IDebugControl6 control, IDebugClient5 client, IDebugRegisters2 registers,
            IDebugSystemObjects systemObjects, IDebugDataSpaces debugDataSpaces, IExecuteWrapper executeWrapper)
        {
            Control = control;
            Client = client;
            Registers = registers;
            Dataspaces = debugDataSpaces;
            ExecuteWrapper = executeWrapper;
            RegisterEngine = new RegisterEngine(); // todo: inject
            MemoryEngine = new MemoryEngine();
            SystemObjects = systemObjects;
            Is32Bit =
                Regex.Match(ExecuteWrapper.Execute("!peb"), @"PEB at (?<peb>[a-fA-F0-9]+)").Groups["peb"].Value
                    .Length == 8;
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
        ///     Executes a command on the specified thread id
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="command">The v.</param>
        /// <returns>System.String.</returns>
        public string Execute(int threadId, string command)
        {
            return Execute($"~~[0x{threadId:X}]e {command}");
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
        ///     Gets the register value.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="register">The register.</param>
        /// <returns>System.Byte[].</returns>
        /// <inheritdoc />
        public byte[] GetRegisterValue(int threadId, Register register)
        {
            return RegisterEngine.GetRegisterValue(threadId, register, Registers, this);
        }

        /// <summary>
        ///     Reads the virtual memory.
        /// </summary>
        /// <param name="memoryRange">The memory range.</param>
        /// <returns>System.Byte[].</returns>
        /// <inheritdoc />
        public byte[] ReadVirtualMemory(MemoryRange memoryRange)
        {
            return MemoryEngine.ReadMemory(memoryRange.LowAddress, memoryRange.HighAddress, Dataspaces);
        }

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
            var breakHasOccurred = false;
            while (!breakHasOccurred)
            {
                Control.GetExecutionStatus(out status);
                if (goStatuses.Contains(status))
                {
                    Control.WaitForEvent(DEBUG_WAIT.DEFAULT,
                        uint.MaxValue); // todo: make reasonable and add counter.. shouldn't wait more than 10s
                    continue;
                }

                if (status == DEBUG_STATUS.BREAK)
                    breakHasOccurred = true;
            }
        }

        public void StepInto()
        {
            Control.SetExecutionStatus(DEBUG_STATUS.STEP_INTO);
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
        ///     Gets or sets the dataspaces.
        /// </summary>
        /// <value>The dataspaces.</value>
        public IDebugDataSpaces Dataspaces { get; set; }

        /// <summary>
        ///     Gets a value indicating whether the current trace is 32 bit.
        /// </summary>
        /// <value><c>true</c> if 32 bit; otherwise, <c>false</c>.</value>
        public bool Is32Bit { get; }

        /// <summary>
        ///     Gets or sets the client COM interface
        /// </summary>
        /// <value>The client.</value>
        internal IDebugClient5 Client { get; }

        /// <summary>
        ///     Gets or sets the control COM interface
        /// </summary>
        /// <value>The control.</value>
        internal IDebugControl6 Control { get; }

        /// <summary>
        ///     Gets or sets the execute wrapper COM interface
        /// </summary>
        /// <value>The execute wrapper.</value>
        internal IExecuteWrapper ExecuteWrapper { get; }

        /// <summary>
        ///     Gets the memory engine.
        /// </summary>
        /// <value>The memory engine.</value>
        internal IMemoryEngine MemoryEngine { get; set; }

        /// <summary>
        ///     Gets the register engine.
        /// </summary>
        /// <value>The register engine.</value>
        internal IRegisterEngine RegisterEngine { get; set; }

        /// <summary>
        ///     Gets or sets the registers COM interface
        /// </summary>
        /// <value>The registers.</value>
        internal IDebugRegisters2 Registers { get; }

        /// <summary>
        ///     Gets or sets the system objects COM interface
        /// </summary>
        /// <value>The system objects.</value>
        private IDebugSystemObjects SystemObjects { get; }
    }
}