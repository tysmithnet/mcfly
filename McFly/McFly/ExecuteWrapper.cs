// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-25-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="ExecuteWrapper.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Text;
using McFly.Debugger;

namespace McFly
{
    /// <summary>
    ///     Wrapper around the debug client such that you can execute raw commands
    /// </summary>
    /// <seealso cref="McFly.Debugger.IDebugOutputCallbacks" />
    /// <seealso cref="System.IDisposable" />
    public class ExecuteWrapper : IDebugOutputCallbacks, IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExecuteWrapper" /> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public ExecuteWrapper(IDebugClient client)
        {
            _client = client;
            // ReSharper disable once SuspiciousTypeConversion.Global
            _control = (IDebugControl) client;

            var hr = client.GetOutputCallbacks(out _old);
            Debug.Assert(hr == 0);

            hr = client.SetOutputCallbacks(this);
            Debug.Assert(hr == 0);
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="ExecuteWrapper" /> class.
        /// </summary>
        ~ExecuteWrapper()
        {
            Dispose(false);
        }

        /// <summary>
        ///     The builder
        /// </summary>
        private readonly StringBuilder _builder = new StringBuilder();

        /// <summary>
        ///     The debug client
        /// </summary>
        private readonly IDebugClient _client;

        /// <summary>
        ///     The main debug control COM server
        /// </summary>
        private readonly IDebugControl _control;

        /// <summary>
        ///     The disposed flag
        /// </summary>
        private bool _disposed; // To detect redundant calls

        /// <summary>
        ///     The old debug callbacks, this is to restore old callbacks
        /// </summary>
        private readonly IDebugOutputCallbacks _old;

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Executes the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>System.String.</returns>
        public string Execute(string cmd)
        {
            lock (_builder)
            {
                _builder.Clear();
            }

            var hr = _control.Execute(DEBUG_OUTCTL.THIS_CLIENT, cmd, DEBUG_EXECUTE.NOT_LOGGED);
            Debug.Assert(hr == 0);
            //todo:  Something with hr, it may be an error legitimately.

            lock (_builder)
            {
                return _builder.ToString();
            }
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _client.SetOutputCallbacks(_old);
                _disposed = true;
            }
        }

        /// <summary>
        ///     Outputs some text using the specified mask
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        int IDebugOutputCallbacks.Output(DEBUG_OUTPUT mask, string text)
        {
            lock (_builder)
            {
                _builder.Append(text);
            }

            return 0;
        }
    }
}