// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="SearchMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;

namespace McFly.WinDbg.Search
{
    // !mf search create --index frame --title "test search" --description "testing the search"
    //      abcd1234-abcd-1234-abcdef012345
    // !mf search add-term abcd1234-abcd-1234-abcdef012345 rax -eq 1a
    //      Term Id: 1
    // !mf search add-term abcd1234-abcd-1234-abcdef012345 stack_len -gt 10
    //      Term Id: 2
    // !mf search add-term abcd1234-abcd-1234-abcdef012345 mem[100:200] -like "%00??abcd??1234%"
    //      Term Id: 3
    // !mf search define abcd1234-abcd-1234-abcdef012345 "(1 && 2) || (3 && !1)"
    //      Success
    // !mf search abcd1234-abcd-1234-abcdef012345
    //      1. ...
    //      2. ...
    /// <summary>
    ///     Method that allows a user to search for domain entities
    /// </summary>
    /// <seealso cref="IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    public class SearchMethod : IMcFlyMethod
    {
        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        /// <exception cref="ConfigurationErrorsException">No display strategy is registered that can handle the search results</exception>
        /// <exception cref="ArgumentOutOfRangeException">When there is no matching index</exception>
        public void Process(string[] args)
        {
            var plan = Factory.Create(args);
            var converted = Converter.Convert(plan);
            if (plan.Index == SearchIndex.Frame.ShortName)
            {
                var searchResults = ServerClient.SearchFrames(converted);
                var first = SearchResultDisplayStrategies.FirstOrDefault(x => x.CanDisplay(searchResults));
                if (first == null)
                    throw new ConfigurationErrorsException(
                        "No display strategy is registered that can handle the search results");
                first.Display(searchResults);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Unknown index: {plan.Index}");
            }
        }

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
        ///     Gets or sets the converter that will convert the request to search criteria
        /// </summary>
        /// <value>The converter.</value>
        [Import]
        internal ISearchRequestConverter Converter { get; set; }

        /// <summary>
        ///     Gets or sets the factory that will create requests
        /// </summary>
        /// <value>The factory.</value>
        [Import]
        internal ISearchRequestFactory Factory { get; set; }

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
    }
}