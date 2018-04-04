// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="SearchMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace McFly.Search
{
    /// <summary>
    ///     Class SearchMethod.
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    public class SearchMethod : IMcFlyMethod
    {
        /// <summary>
        ///     Gets or sets the factory.
        /// </summary>
        /// <value>The factory.</value>
        [Import]
        internal ISearchPlanFactory Factory { get; set; }

        /// <summary>
        ///     Gets or sets the converter.
        /// </summary>
        /// <value>The converter.</value>
        [Import]
        internal ISearchPlanConverter Converter { get; set; }

        /// <summary>
        ///     Gets or sets the search result display strategies.
        /// </summary>
        /// <value>The search result display strategies.</value>
        [ImportMany]
        internal ISearchResultDisplayStrategy[] SearchResultDisplayStrategies { get; set; }

        /// <summary>
        ///     Gets or sets the server client.
        /// </summary>
        /// <value>The server client.</value>
        [Import]
        internal IServerClient ServerClient { get; set; }

        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("search")
            .SetDescription("Search for indexed content")
            .AddExample("!mf search frame | reg rax -eq 1 OR rbx -neq 0",
                "Search for all frames where rax = 1 or rbx != 0")
            .Build();

        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        /// <exception cref="InvalidOperationException">No display strategy is registered that can handle the search results</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Process(string[] args)
        {
            var plan = Factory.Create(args);
            var converted = Converter.Convert(plan);
            if (plan.Index == SearchIndex.Frame.ShortName)
            {
                var searchResults = ServerClient.SearchFrames(converted);
                var first = SearchResultDisplayStrategies.FirstOrDefault(x => x.CanDisplay(searchResults));
                if (first == null)
                    throw new InvalidOperationException(
                        "No display strategy is registered that can handle the search results");
                first.Display(searchResults);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Unknown index: {plan.Index}");
            }
        }
    }
}