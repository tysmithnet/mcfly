// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="StackFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using McFly.Core;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Default implementation of <see cref="IStackFacade" />
    /// </summary>
    /// <seealso cref="IStackFacade" />
    [Export(typeof(IStackFacade))]
    public class StackFacade : IStackFacade
    {
        /// <summary>
        ///     Gets the current stack trace.
        /// </summary>
        /// <returns>StackTrace.</returns>
        public StackTrace GetCurrentStackTrace()
        {
            var stackTrace = DebugEngineProxy.Execute("k");
            var frames = ExtractStackFrames(stackTrace);
            return new StackTrace(frames);
        }

        /// <summary>
        ///     Gets the current stack trace.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>StackTrace.</returns>
        public StackTrace GetCurrentStackTrace(int threadId)
        {
            var frames = GetStackFrames(threadId);
            return new StackTrace(frames);
        }

        /// <summary>
        ///     Gets the stack frames.
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
        ///     Extracts the stack frames.
        /// </summary>
        /// <param name="stackTrace">The stack trace.</param>
        /// <returns>IEnumerable&lt;StackFrame&gt;.</returns>
        internal static IEnumerable<StackFrame> ExtractStackFrames(string stackTrace)
        {
            var stackFrames = new List<StackFrame>();
            var lines = stackTrace.Split('\n');
            foreach (var line in lines)
            {
                if (!Regex.IsMatch(line, "^([a-f0-9`]+ ){2}")) continue;
                Match m;

                m = Regex.Match(line, "^(?<sp>[a-f0-9`]+) (?<ret>[a-f0-9`]+) 0x(?<off>[a-f0-9]+)");
                if (m.Success)
                {
                    var sp = Convert.ToUInt64(m.Groups["sp"].Value.Replace("`", ""), 16);
                    var ret = Convert.ToUInt64(m.Groups["ret"].Value.Replace("`", ""), 16);
                    var off = Convert.ToUInt64(m.Groups["off"].Value.Replace("`", ""), 16);
                    var frame = new StackFrame(sp, ret, null, null, off);
                    stackFrames.Add(frame);
                    continue;
                }

                m = Regex.Match(line,
                    @"^(?<sp>[a-f0-9`]+) (?<ret>[a-f0-9`]+) (?<mod>[^+]+)!(?<fun>[^\s]+)\+(?<off>[a-f0-9x]+)");
                if (m.Success)
                {
                    var sp = Convert.ToUInt64(m.Groups["sp"].Value.Replace("`", ""), 16);
                    var ret = Convert.ToUInt64(m.Groups["ret"].Value.Replace("`", ""), 16);
                    var mod = m.Groups["mod"].Value;
                    var fun = m.Groups["fun"].Value;
                    var off = Convert.ToUInt64(m.Groups["off"].Value.Replace("`", ""), 16);
                    var frame = new StackFrame(sp, ret, mod, fun, off);
                    stackFrames.Add(frame);
                    continue;
                }

                m = Regex.Match(line, @"^(?<sp>[a-f0-9`]+) (?<ret>[a-f0-9`]+) (?<mod>[^!+]+)\+(?<off>[a-f0-9x]+)");
                if (m.Success)
                {
                    var sp = Convert.ToUInt64(m.Groups["sp"].Value.Replace("`", ""), 16);
                    var ret = Convert.ToUInt64(m.Groups["ret"].Value.Replace("`", ""), 16);
                    var mod = m.Groups["mod"].Value;
                    var off = Convert.ToUInt64(m.Groups["off"].Value.Replace("`", ""), 16);
                    var frame = new StackFrame(sp, ret, mod, null, off);
                    stackFrames.Add(frame);
                }
            }

            return stackFrames;
        }

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }
    }
}