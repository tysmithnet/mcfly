// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-04-2018
//
// Last Modified By : master
// Last Modified On : 03-11-2018
// ***********************************************************************
// <copyright file="IndexMethod.cs" company="">
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
        /// <summary>
        ///     The is32 bit
        /// </summary>
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

        [Import]
        protected internal IServerClient ServerClient { get; set; }

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
                var startingPosition = GetStartingPosition(options);
                var endingPosition = DbgEngProxy.GetEndingPosition();
                SetBreakpoints(options);
                ProcessInternal(startingPosition, endingPosition);
            }).WithNotParsed(errors =>
            {
                Log.Error($"Error: Unable to parse arguments"); // todo: add errors
            });
        }

        /// <summary>
        ///     Gets the starting position.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Position.</returns>
        protected internal Position GetStartingPosition(IndexOptions options)
        {
            if (options == null || options.Start == null)
                return DbgEngProxy.GetStartingPosition();
            if (!Position.TryParse(options.Start, out var startingPosition))
                startingPosition = new Position(0, 0);
            return startingPosition;
        }

        /// <summary>
        ///     Is32s the bit.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected internal bool Is32Bit()
        {
            if (!_is32Bit.HasValue)
                _is32Bit = Regex.Match(DbgEngProxy.Execute("!peb"), @"PEB at (?<peb>[a-fA-F0-9]+)").Groups["peb"].Value
                               .Length ==
                           8;
            return _is32Bit.Value;
        }

        /// <summary>
        ///     Processes the internal.
        /// </summary>
        /// <param name="startingPosition">The starting position.</param>
        /// <param name="endingPosition">The ending position.</param>
        protected internal void ProcessInternal(Position startingPosition, Position endingPosition)
        {
            DbgEngProxy.SetCurrentPosition(startingPosition);
            // loop through all the set break points and record relevant values
            while (true)
            {
                DbgEngProxy.RunUntilBreak();
                var positionsRecords = DbgEngProxy.GetPositions().ToArray();
                var breakRecord = positionsRecords.Single(x => x.IsThreadWithBreak);
                if (breakRecord.Position >= endingPosition)
                    break;

                var frames = CreateFramesForUpsert(positionsRecords, breakRecord);
                UpsertFrames(frames);
            }
        }

        /// <summary>
        ///     Creates the frames for upsert.
        /// </summary>
        /// <param name="positionRecords">The records.</param>
        /// <param name="breakRecord">The break record.</param>
        /// <param name="is32Bit">if set to <c>true</c> [is32 bit].</param>
        /// <returns>List&lt;Frame&gt;.</returns>
        protected internal List<Frame> CreateFramesForUpsert(PositionsRecord[] positionRecords,
            PositionsRecord breakRecord)
        {
            var frames = positionRecords.Where(positionRecord => positionRecord.Position == breakRecord.Position)
                .Select(positionRecord => DbgEngProxy.GetFrame(positionRecord.ThreadId)).ToList();
            return frames;
        }

        /// <summary>
        ///     Upserts the frames.
        /// </summary>
        /// <param name="frames">The frames.</param>
        [ExcludeFromCodeCoverage] // pass through
        protected internal void UpsertFrames(List<Frame> frames)
        {
            ServerClient.UpsertFrames(frames);
        }

        /// <summary>
        ///     Gets the stack frames.
        /// </summary>
        /// <param name="stackTrace">The stack trace.</param>
        /// <returns>List&lt;StackFrame&gt;.</returns>
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

        /// <summary>
        ///     Sets the breakpoints.
        /// </summary>
        /// <param name="options">The options.</param>
        protected internal void SetBreakpoints(IndexOptions options)
        {
            DbgEngProxy.ClearBreakpoints();

            if (options.BreakpointMasks != null)
                foreach (var optionsBreakpointMask in options.BreakpointMasks)
                    DbgEngProxy.SetBreakpointByMask(optionsBreakpointMask);

            if (options.AccessBreakpoints == null) return;
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
                {
                    var length = Convert.ToInt32(match.Groups["length"].Value, 16); // todo: allow for decimal/hex
                    var address = Convert.ToUInt64(match.Groups["address"].Value, 16);
                    switch (c)
                    {
                        case 'r':
                            DbgEngProxy.SetReadAccessBreakpoint(length, address);
                            break;
                        case 'w':
                            DbgEngProxy.SetWriteAccessBreakpoint(length, address);
                            break;
                    }
                }
            }
        }
    }
}