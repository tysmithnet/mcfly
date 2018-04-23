// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="PositionsResult.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace McFly
{
    /// <summary>
    ///     Class PositionsResult.
    /// </summary>
    /// <seealso cref="PositionsRecord" />
    /// <seealso cref="PositionsRecord" />
    public class PositionsResult : IEnumerable<PositionsRecord>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PositionsResult" /> class.
        /// </summary>
        /// <param name="positionsRecords">The positions records.</param>
        /// <exception cref="ArgumentNullException">positionsRecords</exception>
        public PositionsResult(IEnumerable<PositionsRecord> positionsRecords)
        {
            PositionsRecords = positionsRecords?.ToList() ?? throw new ArgumentNullException(nameof(positionsRecords));
        }

        /// <summary>
        ///     Gets the enumerator.
        /// </summary>
        /// <returns>IEnumerator&lt;PositionsRecord&gt;.</returns>
        public IEnumerator<PositionsRecord> GetEnumerator()
        {
            return PositionsRecords.GetEnumerator();
        }

        /// <summary>
        ///     Gets the enumerator.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Gets the current thread.
        /// </summary>
        /// <value>The current thread.</value>
        public PositionsRecord CurrentThreadResult => PositionsRecords.Single(x => x.IsCurrentThread);

        /// <summary>
        ///     Gets or sets the positions records.
        /// </summary>
        /// <value>The positions records.</value>
        private IEnumerable<PositionsRecord> PositionsRecords { get; }
    }
}