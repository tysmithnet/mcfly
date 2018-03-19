using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;

namespace McFly
{
    [Export(typeof(IStackFacade))]
    public class StackFacade : IStackFacade
    {
        [Import]
        protected internal IDbgEngProxy DbgEngProxy { get; set; }

        public StackTrace GetCurrentStackTrace()
        {
            var stackTrace = DbgEngProxy.Execute("k");
            var frames = ExtractStackFrames(stackTrace);
            return new StackTrace(DbgEngProxy.GetCurrentThreadId(), frames);
        }

        public StackTrace GetCurrentStackTrace(int threadId)
        {
            var frames = GetStackFrames(threadId);
            return new StackTrace(threadId, frames);
        }

        public IEnumerable<StackFrame> GetStackFrames(int threadId)
        {
            var command = $"~~[{threadId:X}] k";
            var raw = DbgEngProxy.Execute(command);
            return ExtractStackFrames(raw);
        }

        private static IEnumerable<StackFrame> ExtractStackFrames(string stackTrace)
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
    }
}