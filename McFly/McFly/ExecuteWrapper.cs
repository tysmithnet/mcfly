using System;
using System.Diagnostics;
using System.Text;
using Microsoft.Diagnostics.Runtime.Interop;

namespace McFly
{
    public class ExecuteWrapper : IDebugOutputCallbacks, IDisposable
    {
        private bool _disposed = false; // To detect redundant calls
        private IDebugOutputCallbacks _old;
        private IDebugClient _client;
        private IDebugControl _control;
        private StringBuilder _builder = new StringBuilder();

        public ExecuteWrapper(IDebugClient client)
        {
            _client = client;
            _control = (IDebugControl)client;

            int hr = client.GetOutputCallbacks(out _old);
            Debug.Assert(hr == 0);

            hr = client.SetOutputCallbacks(this);
            Debug.Assert(hr == 0);
        }

        public string Execute(string cmd)
        {
            lock (_builder)
                _builder.Clear();

            int hr = _control.Execute(DEBUG_OUTCTL.THIS_CLIENT, cmd, DEBUG_EXECUTE.NOT_LOGGED);
            Debug.Assert(hr == 0);
            //todo:  Something with hr, it may be an error legitimately.

            lock (_builder)
                return _builder.ToString();
        }

        int IDebugOutputCallbacks.Output(DEBUG_OUTPUT mask, string text)
        {
            // TODO: Check mask and write to appropriate location.

            lock (_builder)
                _builder.Append(text);

            return 0;
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _client.SetOutputCallbacks(_old);
                _disposed = true;
            }
        }

        ~ExecuteWrapper()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}