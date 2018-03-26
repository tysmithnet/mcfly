// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-04-2018
//
// Last Modified By : master
// Last Modified On : 03-23-2018
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
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        ///     Gets or sets the breakpoint facade.
        /// </summary>
        /// <value>The breakpoint facade.</value>
        [Import]
        protected internal IBreakpointFacade BreakpointFacade { get; set; }

        /// <summary>
        ///     Gets or sets the time travel facade.
        /// </summary>
        /// <value>The time travel facade.</value>
        [Import]
        protected internal ITimeTravelFacade TimeTravelFacade { get; set; }

        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        protected internal Settings Settings { get; set; }

        /// <summary>
        ///     Gets or sets the server client.
        /// </summary>
        /// <value>The server client.</value>
        [Import]
        protected internal IServerClient ServerClient { get; set; }

        public HelpInfo HelpInfo { get; } = new HelpInfo
        (
            "index", "Record the state of registers, memory, etc for further analysis", null, null, null
        );

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        [ExcludeFromCodeCoverage]
        public void Process(string[] args)
        {
            // todo: handle help
            IndexOptions options;

            Parser.Default.ParseArguments<IndexOptions>(args).WithParsed(o =>
            {
                options = o;
                var startingPosition = GetStartingPosition(options);
                var endingPosition = GetEndingPosition(options);
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
        /// <exception cref="FormatException"></exception>
        protected internal Position GetStartingPosition(IndexOptions options)
        {
            if (options == null || options.Start == null)
                return TimeTravelFacade.GetStartingPosition();
            if (!Position.TryParse(options.Start, out var startingPosition))
                throw new FormatException($"Invalid position passed to Start option: {options.Start}");
            return startingPosition;
        }

        /// <summary>
        ///     Gets the starting position.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Position.</returns>
        /// <exception cref="FormatException"></exception>
        protected internal Position GetEndingPosition(IndexOptions options)
        {
            if (options == null || options.End == null)
                return TimeTravelFacade.GetEndingPosition();
            if (!Position.TryParse(options.End, out var endingPosition))
                throw new FormatException($"Invalid position passed to End option: {options.End}");
            return endingPosition;
        }

        /// <summary>
        ///     Is32s the bit.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected internal bool Is32Bit()
        {
            if (!_is32Bit.HasValue)
                _is32Bit = Regex.Match(DebugEngineProxy.Execute("!peb"), @"PEB at (?<peb>[a-fA-F0-9]+)").Groups["peb"]
                               .Value
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
            TimeTravelFacade.SetPosition(startingPosition);
            // loop through all the set break points and record relevant values
            var frames = new List<Frame>();
            Position last = null;
            while (true) // todo: have better abstraction... while(!DbgEngProxy.RunTo(endingPosition))
            {
                DebugEngineProxy.RunUntilBreak();
                var positions = TimeTravelFacade.Positions();
                var breakRecord = positions.CurrentThread;
                if (last == breakRecord.Position)
                    break;

                var newFrames = CreateFramesForUpsert(positions, breakRecord);
                frames.AddRange(newFrames);
                last = breakRecord.Position;
            }
            ServerClient.UpsertFrames(frames);
        }

        /// <summary>
        ///     Creates the frames for upsert.
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <param name="breakRecord">The break record.</param>
        /// <returns>List&lt;Frame&gt;.</returns>
        protected internal List<Frame> CreateFramesForUpsert(PositionsResult positions,
            PositionsRecord breakRecord)
        {
            var frames = positions.Where(positionRecord => positionRecord.Position == breakRecord.Position)
                .Select(positionRecord => TimeTravelFacade.GetCurrentFrame(positionRecord.ThreadId)).ToList();
            return frames;
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
            BreakpointFacade.ClearBreakpoints();

            if (options.BreakpointMasks != null)
                foreach (var optionsBreakpointMask in options.BreakpointMasks)
                    BreakpointFacade.SetBreakpointByMask(optionsBreakpointMask);

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
                            BreakpointFacade.SetReadAccessBreakpoint(length, address);
                            break;
                        case 'w':
                            BreakpointFacade.SetWriteAccessBreakpoint(length, address);
                            break;
                    }
                }
            }
        }
    }
}