using McFly.Core;

namespace McFly
{
    public interface ITimeTravelFacade
    {
        void SetPosition(Position position);
        Position GetCurrentPosition();
        Position GetCurrentPosition(int threadId);
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