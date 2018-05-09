// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 05-08-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-08-2018
// ***********************************************************************
// <copyright file="FrameIndex.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.WinDbg.Search
{
    /// <summary>
    ///     Class FrameIndex.
    /// </summary>
    /// <seealso cref="McFly.WinDbg.Search.SearchIndex" />
    public class FrameIndex : SearchIndex
    {
        /// <summary>
        ///     Gets the short name.
        /// </summary>
        /// <value>The short name.</value>
        /// <inheritdoc />
        public override string ShortName { get; } = "frame";
    }
}