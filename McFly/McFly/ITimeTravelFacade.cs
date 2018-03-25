// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-20-2018
// ***********************************************************************
// <copyright file="ITimeTravelFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     Interface ITimeTravelFacade
    /// </summary>
    public interface ITimeTravelFacade
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
        ///     Sets the position.
        /// </summary>
        /// <param name="position">The position.</param>
        void SetPosition(Position position);

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
        ///     Gets the starting position of the trace. Many times this is 35:0
        /// </summary>
        /// <returns>Position.</returns>
        Position GetStartingPosition();

        /// <summary>
        ///     Gets the ending position
        /// </summary>
        /// <returns>Position.</returns>
        Position GetEndingPosition();
    }
}