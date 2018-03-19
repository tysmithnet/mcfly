using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;

namespace McFly
{
    [Export(typeof(ITimeTravelFacade))]
    public class TimeTravelFacade : ITimeTravelFacade, IFrameFacade
    {
        [Import]
        protected internal IDbgEngProxy DbgEngProxy { get; set; }  

        [Import]
        protected internal IStackFacade StackFacade { get; set; }
        
        [Import]
        protected internal IRegisterFacade RegisterFacade { get; set; }

        [Import]
        protected internal IDisassemblyFacade DisassemblyFacade { get; set; }

        public void SetPosition(Position position)
        {
            DbgEngProxy.Execute($"!tt {position}");
        }

        public Position GetCurrentPosition()
        {
            return Positions().Single(x => x.IsThreadWithBreak).Position;
        }

        public Position GetCurrentPosition(int threadId)
        {
            return Positions().Single(x => x.ThreadId == threadId).Position;
        }

        public PositionsResult Positions()
        {
            var positionsText = DbgEngProxy.Execute("!positions");
            var records = ParsePositionsCommandText(positionsText);
            return new PositionsResult(records);
        }
        
        /// <summary>
        ///     Gets the starting position of the trace. Many times this is 35:0
        /// </summary>
        /// <returns>Position.</returns>
        public Position GetStartingPosition()
        {
            var end = DbgEngProxy.Execute("!tt 0"); // todo: get from trace_info
            var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
            return Position.Parse(endMatch.Groups["pos"].Value);
        }

        public Position GetEndingPosition()
        {
            throw new NotImplementedException();
        }

        public Frame GetCurrentFrame()
        {
            return new Frame
            {
                Position = GetCurrentPosition(),
                StackTrace = StackFacade.GetCurrentStackTrace(),
                RegisterSet = RegisterFacade.GetCurrentRegisterSet(Register.AllRegisters64),
                DisassemblyLine = DisassemblyFacade.GetDisassemblyLines(1).Single()
            };
        }

        public Frame GetCurrentFrame(int threadId)
        {
            return new Frame
            {
                Position = GetCurrentPosition(threadId),
                StackTrace = StackFacade.GetCurrentStackTrace(threadId),
                DisassemblyLine = DisassemblyFacade.GetDisassemblyLines(threadId, 1).Single()
            };
        }

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
    }
}