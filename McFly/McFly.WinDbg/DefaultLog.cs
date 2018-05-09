// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="DefaultLog.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.CompilerServices;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Class DefaultLog.
    /// </summary>
    /// <seealso cref="ILog" />
    /// <seealso cref="System.IDisposable" />
    [Export(typeof(ILog))]
    public class DefaultLog : ILog, IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DefaultLog" /> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public DefaultLog(string filePath)
        {
            var fs = File.Open(filePath, FileMode.Append);
            var bs = new BufferedStream(fs);
            StreamWriter = new StreamWriter(bs);
        }

        /// <summary>
        ///     Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message, [CallerMemberName]string callingMember = "")
        {
            StreamWriter.WriteLine($"[d] [{DateTime.Now}] [{callingMember}]: {message}");
        }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            StreamWriter?.Dispose();
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message, [CallerMemberName]string callingMember = "")
        {
            StreamWriter.WriteLine($"[e] [{DateTime.Now}] [{callingMember}]: {message}");
        }

        /// <summary>
        ///     Errors the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Error(Exception exception, [CallerMemberName]string callingMember = "")
        {
            StreamWriter.WriteLine($"[e] [{DateTime.Now}] [{callingMember}]: {exception.Message}");
            do
            {
                StreamWriter.WriteLine(exception.StackTrace);
            } while ((exception = exception.InnerException) != null);
        }

        /// <summary>
        ///     Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(string message, [CallerMemberName]string callingMember = "")
        {
            StreamWriter.WriteLine($"[f] [{DateTime.Now}] [{callingMember}]: {message}");
        }

        /// <summary>
        ///     Fatals the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Fatal(Exception exception, [CallerMemberName]string callingMember = "")
        {
            StreamWriter.WriteLine($"[f] [{DateTime.Now}] [{callingMember}]: {exception.Message}");
            do
            {
                StreamWriter.WriteLine(exception.StackTrace);
            } while ((exception = exception.InnerException) != null);
        }

        /// <summary>
        ///     Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(string message, [CallerMemberName]string callingMember = "")
        {
            StreamWriter.WriteLine($"[i] [{DateTime.Now}] [{callingMember}]: {message}");
        }

        /// <summary>
        ///     Verboses the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Verbose(string message, [CallerMemberName]string callingMember = "")
        {
            StreamWriter.WriteLine($"[v] [{DateTime.Now}] [{callingMember}]: {message}");
        }

        /// <summary>
        ///     Gets or sets the stream writer.
        /// </summary>
        /// <value>The stream writer.</value>
        private StreamWriter StreamWriter { get; }
    }
}