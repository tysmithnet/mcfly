// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-04-2018
//
// Last Modified By : master
// Last Modified On : 03-06-2018
// ***********************************************************************
// <copyright file="IndexMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using CommandLine;
using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     Class IndexMethod.
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    internal class IndexMethod : IMcFlyMethod
    {
        private bool? _is32Bit;

        /// <summary>
        ///     Gets or sets the log.
        /// </summary>
        /// <value>The log.</value>
        [Import]
        protected internal ILog Log { get; set; }

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        protected internal IDbgEngProxy DbgEngProxy { get; set; }

        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        protected internal Settings Settings { get; set; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; } = "index";

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            // todo: handle help
            IndexOptions options;
            
            Parser.Default.ParseArguments<IndexOptions>(args).WithParsed(o =>
            {
                options = o;
                Position startingPosition = GetStartingPosition(options);
                Position endingPosition = GetEndingPosition(options);
                SetBreakpoints(options);
                ProcessInternal(startingPosition, endingPosition);
            }).WithNotParsed(errors =>
            {
                Log.Error($"Error: Unable to parse arguments"); // todo: add errors
            });                                                   
        }

        protected internal static Position GetStartingPosition(IndexOptions options)
        {
            if(options == null || options.Start == null)
                return new Position(0, 0);
            if (!Position.TryParse(options.Start, out var startingPosition))
                startingPosition = new Position(0, 0);
            return startingPosition;
        }

        protected internal bool Is32Bit()
        {                         
            if (!_is32Bit.HasValue)    
                _is32Bit = Regex.Match(DbgEngProxy.Execute("!peb"), @"PEB at (?<peb>[a-fA-F0-9]+)").Groups["peb"].Value.Length ==
                8;
            return _is32Bit.Value;
        }

        protected internal void ProcessInternal(Position startingPosition, Position endingPosition)
        {
            DbgEngProxy.Execute($"!tt {startingPosition}");
            // loop through all the set break points and record relevant values
            while (true)
            {
                DbgEngProxy.RunUntilBreak();
                var records = GetPositions().ToArray();
                var breakRecord = records.Single(x => x.IsThreadWithBreak);
                if (breakRecord.Position >= endingPosition)
                    break;

                var frames = CreateFramesForUpsert(records, breakRecord, Is32Bit());
                UpsertFrames(frames);
            }
        }

        protected internal List<Frame> CreateFramesForUpsert(PositionsRecord[] records, PositionsRecord breakRecord, bool is32Bit)
        {
            var frames = (from record in records
                where record.Position == breakRecord.Position
                let registerSet = DbgEngProxy.GetRegisters(record.ThreadId, Register.CoreUserRegisters64)
                let stackTrace = DbgEngProxy.Execute("k")
                let stackFrames = GetStackFrames(stackTrace)
                select CreateFrame(is32Bit, record, registerSet, stackFrames)).ToList();
            return frames;
        }

        protected internal void UpsertFrames(List<Frame> frames)
        {
            using (var serverClient = new ServerClient(new Uri(Settings.ServerUrl)))
            {
                serverClient.UpsertFrames(Settings.ProjectName, frames);
            }
        }

        protected internal Frame CreateFrame(bool is32Bit, PositionsRecord record, RegisterSet registerSet,
            List<StackFrame> stackFrames)
        {
            var eipRegister = is32Bit ? "eip" : "rip";
            var instructionText = DbgEngProxy.Execute($"u {eipRegister} L1");
            var match = Regex.Match(instructionText,
                @"(?<sp>[a-fA-F0-9`]+)\s+[a-fA-F0-9]+\s+(?<ins>\w+)\s+(?<extra>.+)?");

            var frame = new Frame
            {
                Position = record.Position,
                RegisterSet = registerSet,
                ThreadId = record.ThreadId,
                StackFrames = stackFrames,
                OpcodeMnemonic = match.Groups["ins"].Success ? match.Groups["ins"].Value : null,
                DisassemblyNote = match.Groups["extra"].Success ? match.Groups["extra"].Value : null
            };
            return frame;
        }

        protected internal static List<StackFrame> GetStackFrames(string stackTrace)
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

        protected internal void SetBreakpoints(IndexOptions options)
        {
// clear breakpoints
            DbgEngProxy.Execute("bc *"); // todo: save existing break points and restore

            // set head at start

            // set breakpoints
            if (options.BreakpointMasks != null)
                foreach (var optionsBreakpointMask in options.BreakpointMasks)
                    DbgEngProxy.Execute($"bm {optionsBreakpointMask}");

            if (options.AccessBreakpoints != null)
                foreach (var accessBreakpoint in options.AccessBreakpoints)
                {
                    // todo: move
                    var match = Regex.Match(accessBreakpoint,
                        @"^\s*(?<access>[rw]{1,2})(?<length>[a-fA-F0-9]+):(?<address>[a-fA-F0-9]+)\s*$");
                    if (!match.Success)
                    {
                        Log.Error($"Error: invalid access breakpoint: {accessBreakpoint}");
                        continue;
                    }

                    foreach (var c in match.Groups["access"].Value)
                        DbgEngProxy.Execute($"ba {c}{match.Groups["length"].Value} {match.Groups["address"].Value}");
                }
        }

        protected internal Position GetEndingPosition(IndexOptions options)
        {
            Position endingPosition;
            if (options.End != null)
            {
                endingPosition = Position.Parse(options.End);
            }
            else
            {
                var end = DbgEngProxy.Execute("!tt 100"); // todo: get from trace_info
                var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
                endingPosition = Position.Parse(endMatch.Groups["pos"].Value);
            }
            return endingPosition;
        }

        /// <summary>
        ///     The positions of all threads at the current frame
        /// </summary>
        /// <returns>The positions of all threads at the current frame</returns>
        protected internal IEnumerable<PositionsRecord> GetPositions()
        {
            var positionsText = DbgEngProxy.Execute("!positions");

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
    }
}