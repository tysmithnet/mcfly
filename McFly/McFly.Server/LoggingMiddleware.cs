// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-27-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="LoggingMiddleware.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Common.Logging;
using Microsoft.Owin;

namespace McFly.Server
{
    /// <summary>
    ///     Class LoggingMiddleware.
    /// </summary>
    /// <seealso cref="Microsoft.Owin.OwinMiddleware" />
    [ExcludeFromCodeCoverage]
    public class LoggingMiddleware : OwinMiddleware
    {
        /// <summary>
        ///     The request number
        /// </summary>
        private static ulong _requestNum;

        /// <summary>
        ///     The lock
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        ///     The log
        /// </summary>
        private readonly ILog Log = LogManager.GetLogger<LoggingMiddleware>();

        /// <summary>
        ///     Instantiates the middleware with an optional pointer to the next component.
        /// </summary>
        /// <param name="next">The next.</param>
        public LoggingMiddleware(OwinMiddleware next) : base(next)
        {
        }

        /// <summary>
        ///     Process an individual request.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public override async Task Invoke(IOwinContext context)
        {
            ulong requestNum;
            lock (_lock)
            {
                requestNum = _requestNum++;
            }

            var req = context.Request;
            var sw = Stopwatch.StartNew();
            Log.Info($"-> {requestNum} {req.Method} {req.Path}{req.QueryString}");
            sw.Stop();
            await Next.Invoke(context);
            var res = context.Response;
            Log.Info(
                $"<- {requestNum} {res.StatusCode} {sw.ElapsedMilliseconds}ms {res.ContentLength}B \"{res.ContentType}\"");
        }
    }
}