using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     One line of !positions
    /// </summary>
    public class PositionsRecord
    {
        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        public int ThreadId { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is thread with break.
        /// </summary>
        /// <value><c>true</c> if this instance is thread with break; otherwise, <c>false</c>.</value>
        public bool IsThreadWithBreak { get; set; }
    }
}