// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="SearchIndex.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.WinDbg.Search
{
    /// <summary>
    ///     Type safe enum for search indices
    /// </summary>
    public abstract class SearchIndex
    {
        /// <summary>
        ///     The frame index
        /// </summary>
        public static readonly SearchIndex Frame = new _Frame();

        /// <summary>
        ///     Gets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public abstract string ShortName { get; }

        /// <summary>
        ///     The frame index is used when searching for register values, etc
        /// </summary>
        /// <seealso cref="SearchIndex" />
        private class _Frame : SearchIndex
        {
            /// <summary>
            ///     Gets the short name.
            /// </summary>
            /// <value>The short name.</value>
            /// <inheritdoc />
            public override string ShortName { get; } = "frame";
        }
    }
}