using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommandLine;
using McFly.Core;
using McFly.Debugger;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    internal class Index : IMcFlyMethod
    {
        [Import]
        private ILog Log { get; set; }

        [Import]
        private IDbgEngProxy DbgEngProxy { get; set; }

        [Import]
        private Settings Settings { get; set; }

        public string Name { get; } = "index";

        public async Task Process(string[] args)
        {
            IndexOptions options = new IndexOptions();
            Parser.Default.ParseArguments<IndexOptions>(args).WithParsed(o =>
            {
                options = o;
            }).WithNotParsed(errors =>
            {
                Log.Error($"Error: Unable to parse arguments"); // todo: add errors
                    return;
            });

            Position endingPosition;
            if (options.End != null)
            {
                endingPosition = Position.Parse(options.End);
            }
            else
            {
                var end = DbgEngProxy.Execute("!tt 100");
                var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
                endingPosition = Position.Parse(endMatch.Groups["pos"].Value);
            }

            // clear breakpoints
            DbgEngProxy.Execute("bc *"); // todo: save existing break points and restore

            // set head at start
            DbgEngProxy.Execute(options.Start != null ? $"!tt {options.Start}" : "!tt 0");

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

            var endReached = false;
            var is32Bit =
                Regex.Match(DbgEngProxy.Execute("!peb"), @"PEB at (?<peb>[a-fA-F0-9]+)").Groups["peb"].Value.Length == 8;
            // loop through all the set break points and record relevant values
            while (true)
            {     
                DbgEngProxy.RunUntilBreak();
                var records = GetPositions().ToArray();
                var breakRecord = records.Single(x => x.IsThreadWithBreak);
                if (breakRecord.Position >= endingPosition)
                    break;

                var frames = new List<Frame>();
                foreach (var record in records)
                {
                    // all threads currently at the same breakpoint position
                    if (record.Position != breakRecord.Position) continue;
                    var registerSet = DbgEngProxy.GetRegisters(record.ThreadId, Register.CoreUserRegisters64);
                    var stackTrace = DbgEngProxy.Execute("k");

                    var stackFrames = (from m in Regex.Matches(stackTrace, @"(?<sp>[a-fA-F0-9`]+) (?<ret>[a-fA-F0-9`]+) (?<mod>.*)!(?<fun>.*)\+(?<off>[a-fA-F0-9x]+)?")
                            .Cast<Match>()
                                       let stackPointer = Convert.ToUInt64(m.Groups["sp"].Value.Replace("`", ""), 16)
                                       let returnAddress = Convert.ToUInt64(m.Groups["ret"].Value.Replace("`", ""), 16)
                                       let module = m.Groups["mod"].Value
                                       let functionName = m.Groups["fun"].Value
                                       let offset = Convert.ToUInt32(m.Groups["off"].Value, 16)
                                       select new StackFrame(stackPointer, returnAddress, module, functionName, offset)).ToList();

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
                        OpcodeNmemonic = match.Groups["ins"].Success ? match.Groups["ins"].Value : null,
                        DisassemblyNote = match.Groups["extra"].Success ? match.Groups["extra"].Value : null
                    };
                    frames.Add(frame);
                }
                using (var serverClient = new ServerClient(new Uri(Settings.ServerUrl)))
                {
                    await serverClient.UpsertFrames(Settings.ProjectName, frames);
                }
            }
        }

        /// <summary>
        ///     The positions of all threads at the current frame
        /// </summary>
        /// <param name="ew">The ew.</param>
        /// <returns>The positions of all threads at the current frame</returns>
        private IEnumerable<PositionsRecord> GetPositions()
        {
            var positionsText = DbgEngProxy.Execute("!positions");

            var matches = Regex.Matches(positionsText,
                "(?<cur>>)?Thread ID=0x(?<tid>[A-F0-9]+) - Position: (?<maj>[A-F0-9]+):(?<min>[A-F0-9]+)");

            return matches.Cast<Match>().Select(x => new PositionsRecord
            {
                ThreadId = Convert.ToInt32(x.Groups["tid"].Value, 16),
                Position = new Position(Convert.ToInt32(x.Groups["maj"].Value, 16),
                    Convert.ToInt32(x.Groups["min"].Value, 16)),
                IsThreadWithBreak = x.Groups["cur"].Success
            });
        }    
    }
}