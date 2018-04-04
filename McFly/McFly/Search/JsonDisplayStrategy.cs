// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="JsonDisplayStrategy.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.Composition;
using Newtonsoft.Json;

namespace McFly.Search
{
    /// <summary>
    /// Class JsonDisplayStrategy.
    /// </summary>
    /// <seealso cref="McFly.Search.ISearchResultDisplayStrategy" />
    [Export(typeof(ISearchResultDisplayStrategy))]
    internal class JsonDisplayStrategy : ISearchResultDisplayStrategy
    {
        /// <summary>
        /// Gets or sets the debug engine proxy.
        /// </summary>
        /// <value>The debug engine proxy.</value>
        [Import]
        internal IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        /// Determines whether this instance can display the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if this instance can display the specified object; otherwise, <c>false</c>.</returns>
        /// <inheritdoc />
        public bool CanDisplay(object obj)
        {
            return true;
        }

        /// <summary>
        /// Displays the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <inheritdoc />
        public void Display(object obj)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            DebugEngineProxy.WriteLine(json);
        }
    }
}