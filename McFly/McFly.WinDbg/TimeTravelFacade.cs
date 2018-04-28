// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="TimeTravelFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Core.Registers;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Default implementation of the time travel facade
    /// </summary>
    /// <seealso cref="ITimeTravelFacade" />
    [Export(typeof(ITimeTravelFacade))]
    public class TimeTravelFacade : ITimeTravelFacade
    {
        /// <summary>
        ///     Gets the current frame.
        /// </summary>
        /// <returns>Frame.</returns>
        public Frame GetCurrentFrame()
        {
            var position = GetCurrentPosition();
            var currentStack = StackFacade.GetCurrentStackTrace();
            var registers = RegisterFacade.GetCurrentRegisterSet(Register.All);
            var disassembly = DisassemblyFacade.GetDisassemblyLines(1).Single();

            return new Frame
            {
                Position = position,
                StackTrace = currentStack,
                RegisterSet = registers,
                DisassemblyLine = disassembly,
                ThreadId = DebugEngineProxy.GetCurrentThreadId()
            };
        }

        /// <summary>
        ///     Gets the current frame.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Frame.</returns>
        public Frame GetCurrentFrame(int threadId)
        {
            var frame = new Frame();
            frame.Position = GetCurrentPosition(threadId);
            frame.StackTrace = StackFacade.GetCurrentStackTrace(threadId);
            frame.RegisterSet = RegisterFacade.GetCurrentRegisterSet(threadId,
                DebugEngineProxy.Is32Bit ? Register.DefaultX86Registers : Register.DefaultX64Registers);
            frame.DisassemblyLine = DisassemblyFacade.GetDisassemblyLines(threadId, 1).Single();
            frame.ThreadId = threadId;
            return frame;
        }

        /// <summary>
        ///     Gets the current position.
        /// </summary>
        /// <returns>Position.</returns>
        public Position GetCurrentPosition()
        {
            return Positions().Single(x => x.IsCurrentThread).Position;
        }

        /// <summary>
        ///     Gets the current position.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Position.</returns>
        public Position GetCurrentPosition(int threadId)
        {
            return Positions().Single(x => x.ThreadId == threadId).Position;
        }

        /// <summary>
        ///     Gets the ending position
        /// </summary>
        /// <returns>Position.</returns>
        public Position GetEndingPosition()
        {
            var end = DebugEngineProxy.Execute("!tt 100"); // todo: get from trace_info
            var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
            return Position.Parse(endMatch.Groups["pos"].Value);
        }

        /// <summary>
        ///     Gets the starting position of the trace. Many times this is 35:0
        /// </summary>
        /// <returns>Position.</returns>
        public Position GetStartingPosition()
        {
            var end = DebugEngineProxy.Execute("!tt 0"); // todo: get from trace_info
            var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
            return Position.Parse(endMatch.Groups["pos"].Value);
        }

        /// <summary>
        ///     Positionses this instance.
        /// </summary>
        /// <returns>PositionsResult.</returns>
        public PositionsResult Positions()
        {
            var positionsText = DebugEngineProxy.Execute("!positions");
            var records = ParsePositionsCommandText(positionsText);
            return new PositionsResult(records);
        }

        /// <summary>
        ///     Sets the position.
        /// </summary>
        /// <param name="position">The position.</param>
        public void SetPosition(Position position)
        {
            DebugEngineProxy.Execute($"!tt {position}");
        }

        /// <summary>
        ///     Parses the positions command text.
        /// </summary>
        /// <param name="positionsText">The positions text.</param>
        /// <returns>IEnumerable&lt;PositionsRecord&gt;.</returns>
        private static IEnumerable<PositionsRecord> ParsePositionsCommandText(string positionsText)
        {
            var matches = Regex.Matches(positionsText,
                "(?<cur>>)?Thread ID=0x(?<tid>[A-F0-9]+) - Position: (?<maj>[A-F0-9]+):(?<min>[A-F0-9]+)");

            return matches.Cast<Match>().Select(x =>
            {
                var threadId = Convert.ToInt32(x.Groups["tid"].Value, 16);
                var position = new Position(Convert.ToInt32(x.Groups["maj"].Value, 16),
                    Convert.ToInt32(x.Groups["min"].Value, 16));
                var isThreadWithBreak = x.Groups["cur"].Success;
                var item = new PositionsRecord(threadId, position, isThreadWithBreak);
                return item;
            });
        }

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        ///     Gets or sets the disassembly facade.
        /// </summary>
        /// <value>The disassembly facade.</value>
        [Import]
        protected internal IDisassemblyFacade DisassemblyFacade { get; set; }

        /// <summary>
        ///     Gets or sets the register facade.
        /// </summary>
        /// <value>The register facade.</value>
        [Import]
        protected internal IRegisterFacade RegisterFacade { get; set; }

        /// <summary>
        ///     Gets or sets the stack facade.
        /// </summary>
        /// <value>The stack facade.</value>
        [Import]
        protected internal IStackFacade StackFacade { get; set; }
    }
}