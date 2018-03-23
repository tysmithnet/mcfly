﻿// ***********************************************************************
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
        ///     Initializes a new instance of the <see cref="DbgEngProxy" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="client">The client.</param>
        /// <param name="registers">The registers.</param>
        /// <param name="systemObjects"></param>
        public DbgEngProxy(IDebugControl6 control, IDebugClient5 client, IDebugRegisters2 registers,
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

        private IDebugSystemObjects SystemObjects { get; set; }

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
                        uint.MaxValue); // todo: make reasonable and add counter.. shouldn't wait more than 10s
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
        public int GetCurrentThreadId()
        {
            SystemObjects.GetCurrentThreadId(out var threadId);
            return Convert.ToInt32(threadId);
        }

        public void SwitchToThread(int threadId)
        {
            SystemObjects.SetCurrentThreadId(threadId.ToUInt());
        }

        public bool Is32Bit { get; }
        public event EventHandler<BreakpointHitEventArgs> BreakpointHit;

        protected virtual void OnBreakpointHit(BreakpointHitEventArgs args)
        {
            BreakpointHit?.Invoke(this, args);
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