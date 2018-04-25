// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="ISearchResultDisplayStrategy.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Search
{
    /// <summary>
    ///     Something that can display search results
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface ISearchResultDisplayStrategy : IInjectable
    {
        /// <summary>
        ///     Determines whether this instance can display the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if this instance can display the specified object; otherwise, <c>false</c>.</returns>
        bool CanDisplay(object obj);

        /// <summary>
        ///     Displays the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Display(object obj);
    }
}