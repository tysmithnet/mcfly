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

namespace McFly
{
    /// <summary>
    ///     Class DefaultLog.
    /// </summary>
    /// <seealso cref="McFly.ILog" />
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
        public void Debug(string message)
        {
            StreamWriter.WriteLine($"[d] {DateTime.Now} {message}");
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
        public void Error(string message)
        {
            StreamWriter.WriteLine($"[e] {DateTime.Now} {message}");
        }

        /// <summary>
        ///     Errors the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Error(Exception exception)
        {
            StreamWriter.WriteLine($"[e] {DateTime.Now} {exception.Message}");
            do
            {
                StreamWriter.WriteLine(exception.StackTrace);
            } while ((exception = exception.InnerException) != null);
        }

        /// <summary>
        ///     Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(string message)
        {
            StreamWriter.WriteLine($"[f] {DateTime.Now} {message}");
        }

        /// <summary>
        ///     Fatals the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Fatal(Exception exception)
        {
            StreamWriter.WriteLine($"[f] {DateTime.Now} {exception.Message}");
            do
            {
                StreamWriter.WriteLine(exception.StackTrace);
            } while ((exception = exception.InnerException) != null);
        }

        /// <summary>
        ///     Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(string message)
        {
            StreamWriter.WriteLine($"[i] {DateTime.Now} {message}");
        }

        /// <summary>
        ///     Verboses the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Verbose(string message)
        {
            StreamWriter.WriteLine($"[v] {DateTime.Now} {message}");
        }

        // todo: refactor this

        /// <summary>
        ///     Gets or sets the stream writer.
        /// </summary>
        /// <value>The stream writer.</value>
        private StreamWriter StreamWriter { get; }
    }
}