// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-05-2018
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
using McFly.Core;

namespace McFly.WinDbg
{
    /// <summary>
    ///     McFly method that will persist the state of the trace at various positions
    /// </summary>
    /// <seealso cref="McFly.WinDbg.IMcFlyMethod" />
    /// <seealso cref="IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    [Export(typeof(IndexMethod))]
    internal class IndexMethod : IMcFlyMethod
    {
        /// <summary>
        ///     The is32 bit flag
        /// </summary>
        private bool? _is32Bit;

        /// <summary>
        ///     The switches this application can take
        /// </summary>
        private static readonly string[] Switches =
            {"-m", "--memory", "-s", "--start", "-e", "--end", "--bm", "--ba", "--step"};

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            var options = ExtractIndexOptions(args);
            if (options.IsAllPositionsInRange)
                IndexAllPositionsInRange(options);
            else
                IndexBreakpointHits(options);
        }

        /// <summary>
        ///     Creates the frames for upsert.
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <returns>List&lt;Frame&gt;.</returns>
        internal virtual List<Frame> CreateFramesForUpsert(PositionsResult positions)
        {
            var breakRecord = positions.CurrentThreadResult;
            var frames = positions
                .Where(positionRecord => positionRecord.Position == breakRecord.Position)
                .Select(positionRecord => TimeTravelFacade.GetCurrentFrame(positionRecord.ThreadId))
                .ToList();
            return frames;
        }

        /// <summary>
        ///     Extracts the access breakpoints
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="startingIndex">The i.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        internal virtual int ExtractAccessBreakpoints(string[] args, int startingIndex, string arg,
            IndexOptions options)
        {
            var accessBreakpoints = new List<AccessBreakpoint>();
            int j;
            for (j = startingIndex + 1; j < args.Length; j++)
            {
                var ptr = args[j];
                if (Switches.Contains(ptr))
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
            return j;
        }

        /// <summary>
        ///     Extracts the end.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="startIndex">The i.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.FormatException"></exception>
        internal virtual int ExtractEnd(string[] args, int startIndex, string arg, IndexOptions options)
        {
            if (startIndex + 1 >= args.Length)
                throw new ArgumentException($"No argument passed to {arg}");
            try
            {
                options.End = Position.Parse(args[startIndex + 1]);
                return startIndex + 1;
            }
            catch (Exception e)
            {
                throw new FormatException($"Unable to parse {args[startIndex + 1]} as a Position", e);
            }
        }

        /// <summary>
        ///     Extracts the index options.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IndexOptions.</returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        internal virtual IndexOptions ExtractIndexOptions(string[] args)
        {
            var options = new IndexOptions();
            for (var index = 0; index < args.Length; index++)
            {
                var arg = args[index];
                switch (arg)
                {
                    case "-m":
                    case "--memory":
                        index = ExtractMemoryRanges(args, index, arg, options);
                        break;
                    case "-s":
                    case "--start":
                        index = ExtractStart(args, index, arg, options);
                        break;
                    case "-e":
                    case "--end":
                        index = ExtractEnd(args, index, arg, options);
                        break;
                    case "--bm":
                        index = ExtractMasks(args, index, arg, options);
                        break;
                    case "--ba":
                        index = ExtractAccessBreakpoints(args, index, arg, options); // todo: these all need to be by ref i
                        break;
                    case "--step":
                        index = ExtractStep(args, index, options);
                        break;
                    case "-a":
                    case "--all":
                        options.IsAllPositionsInRange = true;
                        break;
                }
            }

            return options;
        }

        internal virtual int ExtractMasks(string[] args, int startIndex, string arg, IndexOptions options)
        {
            var breakpointMasks = new List<BreakpointMask>();
            int j;
            for (j = startIndex + 1; j < args.Length; j++)
            {
                var ptr = args[j];
                if (Switches.Contains(ptr))
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
            return j;
        }

        internal virtual int ExtractMemoryRanges(string[] args, int startIndex, string arg, IndexOptions options)
        {
            var ranges = new List<MemoryRange>();
            int j;
            for (j = startIndex + 1; j < args.Length; j++)
            {
                var ptr = args[j];
                if (Switches.Contains(ptr))
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
            return j;
        }

        internal virtual int ExtractStart(string[] args, int startindex, string arg, IndexOptions options)
        {
            if (startindex + 1 >= args.Length)
                throw new ArgumentException($"No argument passed to {arg}");
            try
            {
                options.Start = Position.Parse(args[startindex + 1]);
                return startindex + 1;
            }
            catch (Exception e)
            {
                throw new FormatException($"Unable to parse {args[startindex + 1]} as a Position", e);
            }
        }

        internal virtual int ExtractStep(string[] args, int startIndex, IndexOptions options)
        {
            if (startIndex + 1 >= args.Length)
                throw new ArgumentException($"--step requires a positive integer", nameof(args));
            if (int.TryParse(args[startIndex + 1], out var step))
            {
                if (step < 1)
                    throw new ArgumentOutOfRangeException(nameof(args),
                        $"--step requires a positive integer, but found {args[startIndex + 1]}");

                options.Step = step;
                return 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(args),
                    $"--step requires a positive integer, but found {args[startIndex + 1]}");
            }
        }

        internal virtual Position GetEndingPosition(IndexOptions options)
        {
            if (options == null || options.End == null)
                return TimeTravelFacade.LastPosition;
            return options.End;
        }

        internal virtual Position GetStartingPosition(IndexOptions options)
        {
            if (options == null || options.Start == null)
                return TimeTravelFacade.FirstPosition;
            return options.Start;
        }

        /// <summary>
        ///     Indexes all positions in range.
        /// </summary>
        /// <param name="options">The options.</param>
        internal virtual void IndexAllPositionsInRange(IndexOptions options)
        {
            var end = options.End ?? TimeTravelFacade.LastPosition;
            var start = options.Start ?? TimeTravelFacade.FirstPosition;
            var curPos = TimeTravelFacade.SetPosition(start).ActualPosition;
            while (curPos <= end)
            {
                UpsertCurrentPosition(options);
                var nextPosition = new Position(curPos.High, curPos.Low + 1);
                curPos = TimeTravelFacade.SetPosition(nextPosition).ActualPosition;
            }
        }

        /// <summary>
        ///     Indexes the breakpoint hits.
        /// </summary>
        /// <param name="options">The options.</param>
        internal virtual void IndexBreakpointHits(IndexOptions options)
        {
            var end = options.End ?? TimeTravelFacade.LastPosition;
            var start = options.Start ?? TimeTravelFacade.FirstPosition;
            var curPos = TimeTravelFacade.SetPosition(start).ActualPosition;
            BreakpointFacade.ClearBreakpoints();
            SetBreakpoints(options);
            while (curPos <= end)
            {
                DebugEngineProxy.RunUntilBreak();
                curPos = TimeTravelFacade.GetCurrentPosition();
                if (curPos <= end) UpsertCurrentPosition(options);
                for (int i = 0; i < options.Step; i++)
                {
                    var newPosition = new Position(curPos.High, curPos.Low + 1);
                    var posRes = TimeTravelFacade.SetPosition(newPosition);
                    curPos = posRes.ActualPosition;
                    if (posRes.BreakpointHit.HasValue)
                        i = -1;
                    if (curPos >= end)
                        return;
                    UpsertCurrentPosition(options);
                }
            }
        }

        /// <summary>
        ///     Sets the breakpoints.
        /// </summary>
        /// <param name="options">The options.</param>
        internal virtual void SetBreakpoints(IndexOptions options)
        {
            if (options.BreakpointMasks != null)
                foreach (var optionsBreakpointMask in options.BreakpointMasks)
                    optionsBreakpointMask.SetBreakpoint(BreakpointFacade);

            if (options.AccessBreakpoints == null) return;
            foreach (var accessBreakpoint in options.AccessBreakpoints)
                accessBreakpoint.SetBreakpoint(BreakpointFacade);
        }

        /// <summary>
        ///     Upserts the current position.
        /// </summary>
        /// <param name="options">The options.</param>
        internal virtual void UpsertCurrentPosition(IndexOptions options)
        {
            var positions = TimeTravelFacade.Positions();
            var frames = CreateFramesForUpsert(positions);
            ServerClient.UpsertFrames(frames);
            foreach (var optionsMemoryRange in options?.MemoryRanges ?? new List<MemoryRange>())
            {
                var bytes = DebugEngineProxy.ReadVirtualMemory(optionsMemoryRange); // todo: errors?
                ServerClient.AddMemoryRange(new MemoryChunk
                {
                    MemoryRange = optionsMemoryRange,
                    Bytes = bytes,
                    Position = positions.CurrentThreadResult.Position
                });
            }
        }

        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder() // todo: add thread specifier
            .SetName("index")
            .SetDescription("Record the state of registers, memory, etc for further analysis")
            .AddSwitch("-m, --memory range[ range]", "Memory ranges to index") // todo: not supported
            .AddSwitch("-s, --start pos", "Lowest frame to index during the run")
            .AddSwitch("-e, --end pos", "Highest possible frame to index during the run")
            .AddSwitch("-a, --all", "If specified, all positions between start and end will be indexed")
            .AddSwitch("--bm mask[ mask]", "Breakpoint masks of the form mod!func, wildcards supported")
            .AddSwitch("--ba spec[ spec]", "Memory access breakpoints")
            .AddSwitch("--step n",
                "Number of positions to record after a break") // todo: should allow for +/- around break
            .AddExample("!mf index", "Record the current frame")
            .AddExample("!mf index --bm user32!*", "Record all function calls in user32")
            .AddExample("!mf index --ba rw8:abc123", "Record all read/writes to abc123:abc12b")
            .AddExample("!mf index --ba rw8:abc123 --step 3",
                "Record all read/writes to abc123:abc12b and 3 positions after")
            .AddExample("!mf index -s 35:0 -e 35:f", "Index every position from 35:0 to 35:f")
            .Build();

        /// <summary>
        ///     Gets or sets the breakpoint facade.
        /// </summary>
        /// <value>The breakpoint facade.</value>
        [Import]
        internal virtual IBreakpointFacade BreakpointFacade { private get; set; }

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        internal virtual IDebugEngineProxy DebugEngineProxy { private get; set; }

        /// <summary>
        ///     Gets or sets the server client.
        /// </summary>
        /// <value>The server client.</value>
        [Import]
        internal virtual IServerClient ServerClient { private get; set; }

        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        internal virtual Settings Settings { private get; set; }

        /// <summary>
        ///     Gets or sets the time travel facade.
        /// </summary>
        /// <value>The time travel facade.</value>
        [Import]
        internal virtual ITimeTravelFacade TimeTravelFacade { private get; set; }

        /// <summary>
        ///     Gets or sets the log.
        /// </summary>
        /// <value>The log.</value>
        [Import]
        private ILog Log { get; set; }
    }
}