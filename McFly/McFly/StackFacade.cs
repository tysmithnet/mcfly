// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="StackFacade.cs" company="">
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

namespace McFly
{
    /// <summary>
    /// Class StackFacade.
    /// </summary>
    /// <seealso cref="McFly.IStackFacade" />
    [Export(typeof(IStackFacade))]
    public class StackFacade : IStackFacade
    {
        /// <summary>
        /// Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        /// Gets the current stack trace.
        /// </summary>
        /// <returns>StackTrace.</returns>
        public StackTrace GetCurrentStackTrace()
        {
            var stackTrace = DebugEngineProxy.Execute("k");
            var frames = ExtractStackFrames(stackTrace);
            return new StackTrace(frames);
        }

        /// <summary>
        /// Gets the current stack trace.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>StackTrace.</returns>
        public StackTrace GetCurrentStackTrace(int threadId)
        {
            var frames = GetStackFrames(threadId);
            return new StackTrace(frames);
        }

        /// <summary>
        /// Gets the stack frames.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>IEnumerable&lt;StackFrame&gt;.</returns>
        public IEnumerable<StackFrame> GetStackFrames(int threadId)
        {
            var command = $"k";
            var raw = DebugEngineProxy.Execute(threadId, command);
            return ExtractStackFrames(raw);
        }

        /// <summary>
        /// Extracts the stack frames.
        /// </summary>
        /// <param name="stackTrace">The stack trace.</param>
        /// <returns>IEnumerable&lt;StackFrame&gt;.</returns>
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