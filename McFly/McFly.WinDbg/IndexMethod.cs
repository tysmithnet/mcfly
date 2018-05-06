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
    internal sealed class IndexMethod : IMcFlyMethod
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
            var startingPosition = GetStartingPosition(options);
            var endingPosition = GetEndingPosition(options);
            ProcessInternal(startingPosition, endingPosition, options);
        }

        /// <summary>
        ///     Creates the frames for upsert.
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <param name="breakRecord">The break record.</param>
        /// <param name="options">The options.</param>
        /// <returns>List&lt;Frame&gt;.</returns>
        internal List<Frame> CreateFramesForUpsert(PositionsResult positions,
            PositionsRecord breakRecord, IndexOptions options)
        {
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
        internal static void ExtractAccessBreakpoints(string[] args, int startingIndex, string arg,
            IndexOptions options)
        {
            var accessBreakpoints = new List<AccessBreakpoint>();
            for (var j = startingIndex + 1; j < args.Length; j++)
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
        }

        /// <summary>
        ///     Extracts the end.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="i">The i.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.FormatException"></exception>
        internal static void ExtractEnd(string[] args, int i, string arg, IndexOptions options)
        {
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
        }

        /// <summary>
        ///     Extracts the index options.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IndexOptions.</returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        internal IndexOptions ExtractIndexOptions(string[] args)
        {
            var options = new IndexOptions();
            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                switch (arg)
                {
                    case "-m":
                    case "--memory":
                        ExtractMemoryRanges(args, i, arg, options);
                        break;
                    case "-s":
                    case "--start":
                        ExtractStart(args, i, arg, options);
                        break;
                    case "-e":
                    case "--end":
                        ExtractEnd(args, i, arg, options);
                        break;
                    case "--bm":
                        ExtractMasks(args, i, arg, options);
                        break;
                    case "--ba":
                        ExtractAccessBreakpoints(args, i, arg, options);
                        break;
                    case "--step":
                        ExtractStep(args, ref i, options);
                        break;
                }
            }

            return options;
        }

        /// <summary>
        ///     Extracts the masks.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="i">The i.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        internal static void ExtractMasks(string[] args, int i, string arg, IndexOptions options)
        {
            var breakpointMasks = new List<BreakpointMask>();
            for (var j = i + 1; j < args.Length; j++)
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
        }

        /// <summary>
        ///     Extracts the memory ranges.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="i">The i.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        internal void ExtractMemoryRanges(string[] args, int i, string arg, IndexOptions options)
        {
            var ranges = new List<MemoryRange>();
            for (var j = i + 1; j < args.Length; j++)
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
        }

        /// <summary>
        ///     Extracts the start.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="i">The i.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.FormatException"></exception>
        internal static void ExtractStart(string[] args, int i, string arg, IndexOptions options)
        {
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
        }

        /// <summary>
        ///     Extracts the step.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="i">The i.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="ArgumentException">args</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     args
        ///     or
        ///     args
        /// </exception>
        internal static void ExtractStep(string[] args, ref int i, IndexOptions options)
        {
            if (i + 1 >= args.Length)
                throw new ArgumentException($"--step requires a positive integer", nameof(args));
            if (int.TryParse(args[i + 1], out var step))
            {
                if (step < 1)
                    throw new ArgumentOutOfRangeException(nameof(args),
                        $"--step requires a positive integer, but found {args[i + 1]}");

                options.Step = step;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(args),
                    $"--step requires a positive integer, but found {args[i + 1]}");
            }

            i++;
        }

        /// <summary>
        ///     Gets the starting position.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Position.</returns>
        /// <exception cref="FormatException"></exception>
        internal Position GetEndingPosition(IndexOptions options)
        {
            if (options == null || options.End == null)
                return TimeTravelFacade.GetEndingPosition();
            return options.End;
        }

        /// <summary>
        ///     Gets the starting position.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Position.</returns>
        /// <exception cref="FormatException"></exception>
        internal Position GetStartingPosition(IndexOptions options)
        {
            if (options == null || options.Start == null)
                return TimeTravelFacade.GetStartingPosition();
            return options.Start;
        }

        /// <summary>
        ///     Is32s the bit.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal bool Is32Bit()
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
        /// <param name="options">The options.</param>
        internal void ProcessInternal(Position startingPosition, Position endingPosition, IndexOptions options)
        {
            SetBreakpoints(options);
            TimeTravelFacade.SetPosition(startingPosition);
            // loop through all the set break points and record relevant values
            var frames = new List<Frame>();
            Position last = null;

            /*
             * todo: PRIORITY FIX
             */

            while (true) // todo: have better abstraction... while(!TimeTravelFacade.RunTo(endingPosition))
            {
                DebugEngineProxy.RunUntilBreak();
                var positions = TimeTravelFacade.Positions();
                var breakRecord = positions.CurrentThreadResult;
                if (last == breakRecord.Position)
                    break;

                var newFrames = CreateFramesForUpsert(positions, breakRecord, options);
                frames.AddRange(newFrames);

                foreach (var optionsMemoryRange in options?.MemoryRanges ?? new List<MemoryRange>())
                {
                    var bytes = DebugEngineProxy.ReadVirtualMemory(optionsMemoryRange); // todo: errors?
                    ServerClient.AddMemoryRange(new MemoryChunk
                    {
                        MemoryRange = optionsMemoryRange,
                        Bytes = bytes,
                        Position = breakRecord.Position
                    });
                }

                last = breakRecord.Position;
            }

            try
            {
                ServerClient.UpsertFrames(frames);
            }
            catch (Exception e)
            {
                Log.Error($"Error persisting frames: {e.GetType().FullName} - {e.Message}");
                DebugEngineProxy.WriteLine($"Error persisting frames: {e.GetType().FullName} - {e.Message}");
            }
        }

        /// <summary>
        ///     Sets the breakpoints.
        /// </summary>
        /// <param name="options">The options.</param>
        internal void SetBreakpoints(IndexOptions options)
        {
            BreakpointFacade.ClearBreakpoints();

            if (options.BreakpointMasks != null)
                foreach (var optionsBreakpointMask in options.BreakpointMasks)
                    optionsBreakpointMask.SetBreakpoint(BreakpointFacade);

            if (options.AccessBreakpoints == null) return;
            foreach (var accessBreakpoint in options.AccessBreakpoints)
                accessBreakpoint.SetBreakpoint(BreakpointFacade);
        }

        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder() // todo: add thread specifier
            .SetName("index")
            .SetDescription("Record the state of registers, memory, etc for further analysis")
            .AddSwitch("-m, --memory range[ range]", "Memory ranges to index")
            .AddSwitch("-s, --start pos", "Lowest frame to index during the run")
            .AddSwitch("-e, --end pos", "Highest possible frame to index during the run")
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
        internal IBreakpointFacade BreakpointFacade { private get; set; }

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        internal IDebugEngineProxy DebugEngineProxy { private get; set; }

        /// <summary>
        ///     Gets or sets the server client.
        /// </summary>
        /// <value>The server client.</value>
        [Import]
        internal IServerClient ServerClient { private get; set; }

        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        internal Settings Settings { private get; set; }

        /// <summary>
        ///     Gets or sets the time travel facade.
        /// </summary>
        /// <value>The time travel facade.</value>
        [Import]
        internal ITimeTravelFacade TimeTravelFacade { private get; set; }

        /// <summary>
        ///     Gets or sets the log.
        /// </summary>
        /// <value>The log.</value>
        [Import]
        private ILog Log { get; set; }
    }
}