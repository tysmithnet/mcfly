// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-04-2018
//
// Last Modified By : master
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="ILog.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly
{
    /// <summary>
    ///     Interface ILog
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="McFly.IInjectable" />
    public interface ILog : IDisposable, IInjectable
    {
        /// <summary>
        ///     Verboses the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Verbose(string message);

        /// <summary>
        ///     Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(string message);

        /// <summary>
        ///     Informations the specified messasge.
        /// </summary>
        /// <param name="messasge">The messasge.</param>
        void Info(string messasge);

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);

        /// <summary>
        ///     Errors the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Error(Exception exception);

        /// <summary>
        ///     Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Fatal(string message);

        /// <summary>
        ///     Fatals the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Fatal(Exception exception);
    }
}