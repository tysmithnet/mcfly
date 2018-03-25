// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-24-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="BreakpointHitEventArgs.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     Class BreakpointHitEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class BreakpointHitEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakpointHitEventArgs" /> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <exception cref="ArgumentNullException">position</exception>
        public BreakpointHitEventArgs(Position position, int threadId)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            ThreadId = threadId;
        }

        /// <summary>
        ///     Gets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; internal set; }

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        public int ThreadId { get; set; }
    }
}