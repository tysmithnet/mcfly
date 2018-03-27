// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-25-2018
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

        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()                             // todo: add thread specifier
            .SetName("index")
            .SetDescription("Record the state of registers, memory, etc for further analysis")
            .AddSwitch("-m, --memory range[ range]", "Memory ranges to index")
            .AddSwitch("-s, --start pos", "Lowest frame to index during the run")
            .AddSwitch("-e, --end pos", "Highest possible frame to index during the run")
            .AddSwitch("--bm mask[ mask]", "Breakpoint masks of the form mod!func, wildcards supported")
            .AddSwitch("--ba spec[ spec]", "Memory access breakpoints")
            .AddSwitch("--step n", "Number of positions to record after a break") // todo: should allow for +/- around break
            .AddExample("!mf index --bm user32!*", "Record all function calls in user32")
            .AddExample("!mf index --ba rw8:abc123", "Record all read/writes to abc123:abc12b")
            .AddExample("!mf index --ba rw8:abc123 --step 3", "Record all read/writes to abc123:abc12b and 3 positions after")
            .AddExample("!mf index -s 35:0 -e 35:f", "Index every position from 35:0 to 35:f")
            .Build();

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            var options = ExtractIndexOptions(args);
            var startingPosition = GetStartingPosition(options);
            var endingPosition = GetEndingPosition(options);
            SetBreakpoints(options);
            ProcessInternal(startingPosition, endingPosition);
        }

        internal static IndexOptions ExtractIndexOptions(string[] args)
        {
            IndexOptions options = new IndexOptions();
            var switches = new[] {"-m", "--memory", "-s", "--start", "-e", "--end", "--bm", "--ba", "--step"};
            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                switch (arg)
                {
                    case "-m":
                    case "--memory":
                        var ranges = new List<MemoryRange>();
                        for (int j = i + 1; j < args.Length; j++)
                        {
                            var ptr = args[j];
                            if (switches.Contains(ptr))
                                break;
                            try
                            {
                                var range = MemoryRange.Parse(ptr);
                                ranges.Add(range);
                            }
                            catch (Exception e)
                            {
                                throw new FormatException($"Unable to parse memory range {ptr}", e);
                            }
                        }
                        if (!ranges.Any())
                            throw new ArgumentException($"No memory ranges provided to {arg}");
                        options.MemoryRanges = ranges;
                        break;
                    case "-s":
                    case "--start":
                        if (i + 1 >= args.Length)
                            throw new ArgumentException($"No argument passed to {arg}");
                        try
                        {
                            options.Start = Position.Parse(args[i + 1]);
                        }
                        catch (Exception e)
                        {
                            throw new FormatException($"Unable to parse {args[i + 1]} as a Position", e);
                        }
                        break;
                    case "-e":
                    case "--end":
                        if (i + 1 >= args.Length)
                            throw new ArgumentException($"No argument passed to {arg}");
                        try
                        {
                            options.End = Position.Parse(args[i + 1]);
                        }
                        catch (Exception e)
                        {
                            throw new FormatException($"Unable to parse {args[i + 1]} as a Position", e);
                        }
                        break;
                    case "--bm":
                        var breakpointMasks = new List<BreakpointMask>();
                        for (int j = i + 1; j < args.Length; j++)
                        {
                            var ptr = args[j];
                            if (switches.Contains(ptr))
                                break;
                            try
                            {
                                var mask = BreakpointMask.Parse(ptr);
                                breakpointMasks.Add(mask);
                            }
                            catch (Exception e)
                            {
                                throw new FormatException($"Unable to parse {ptr} as a BreakpointMask", e);
                            }
                        }
                        if (!breakpointMasks.Any())
                            throw new ArgumentException($"No breakpoint masks provided to {arg}");
                        options.BreakpointMasks = breakpointMasks;
                        break;
                    case "--ba":
                        var accessBreakpoints = new List<AccessBreakpoint>();
                        for (int j = i + 1; j < args.Length; j++)
                        {
                            var ptr = args[j];
                            if (switches.Contains(ptr))
                                break;
                            try
                            {
                                var bp = AccessBreakpoint.Parse(ptr);
                                accessBreakpoints.Add(bp);
                            }
                            catch (Exception e)
                            {
                                throw new FormatException($"Unable to parse {ptr} as an access breakpoint", e);
                            }
                        }
                        if (!accessBreakpoints.Any())
                            throw new ArgumentException($"No memory ranges provided to {arg}");
                        options.AccessBreakpoints = accessBreakpoints;
                        break;
                    case "--step":
                        break;
                }
            }
            return options;
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
            return options.Start;
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
            return options.End;
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
                    optionsBreakpointMask.SetBreakpoint(BreakpointFacade);

            if (options.AccessBreakpoints == null) return;
            foreach (var accessBreakpoint in options.AccessBreakpoints)
                accessBreakpoint.SetBreakpoint(BreakpointFacade);
        }
    }
}