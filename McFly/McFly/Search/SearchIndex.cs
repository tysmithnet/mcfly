// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="SearchIndex.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Search
{
    /// <summary>
    ///     Class SearchIndex.
    /// </summary>
    public abstract class SearchIndex
    {
        /// <summary>
        ///     The frame
        /// </summary>
        public static readonly SearchIndex Frame = new _Frame();

        /// <summary>
        ///     Gets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public abstract string ShortName { get; }

        /// <summary>
        ///     Class _Frame.
        /// </summary>
        /// <seealso cref="McFly.Search.SearchIndex" />
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