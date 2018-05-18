// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-08-2018
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
        ///     The frame
        /// </summary>
        public static readonly FrameIndex Frame = new FrameIndex();

        /// <summary>
        ///     Gets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public abstract string ShortName { get; }
    }
}