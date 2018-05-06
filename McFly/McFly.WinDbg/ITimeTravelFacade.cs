// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ITimeTravelFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Facade over changing the time travel position of the trace
    /// </summary>
    /// <seealso cref="McFly.WinDbg.IInjectable" />
    /// <seealso cref="IInjectable" />
    public interface ITimeTravelFacade : IInjectable
    {
        /// <summary>
        ///     Gets the current frame.
        /// </summary>
        /// <returns>Frame.</returns>
        Frame GetCurrentFrame();

        /// <summary>
        ///     Gets the current frame.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Frame.</returns>
        Frame GetCurrentFrame(int threadId);

        /// <summary>
        ///     Gets the current position.
        /// </summary>
        /// <returns>Position.</returns>
        Position GetCurrentPosition();

        /// <summary>
        ///     Gets the current position.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Position.</returns>
        Position GetCurrentPosition(int threadId);

        /// <summary>
        ///     Positionses this instance.
        /// </summary>
        /// <returns>PositionsResult.</returns>
        PositionsResult Positions();

        /// <summary>
        ///     Sets the current position
        /// </summary>
        /// <remarks>
        ///     If the provided position does not exists, the largest real position less than the provided position will be
        ///     set
        /// </remarks>
        /// <param name="position">The position.</param>
        SetPositionResult SetPosition(Position position);

        /// <summary>
        ///     Gets the first.
        /// </summary>
        /// <value>The first.</value>
        Position FirstPosition { get; }

        /// <summary>
        ///     Gets the last.
        /// </summary>
        /// <value>The last.</value>
        Position LastPosition { get; }

    }
}