using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace McFly.Search
{
    [Export(typeof(ISearchPlanFactory))]
    internal class SearchPlanFactory : ISearchPlanFactory
    {
        /// <inheritdoc />
        public ISearchPlan Create(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (args.Length == 0)
                throw new ArgumentOutOfRangeException("You must at least specify the index to use");

            var index = args[0];

            var list = new List<SearchFilter>();

            for (var i = 1; i < args.Length; i++)
            {
                var arg = args[i];

                if (arg == "|") continue;
                var filter = new SearchFilter
                {
                    Command = arg,
                    Args = new List<string>()
                };
                for (var j = i + 1; j < args.Length && args[j] != "|"; j++)
                {
                    filter.Args.Add(args[j]);
                    i++;
                }

                list.Add(filter);
            }

            return new SearchPlan(index, list);
        }
    }
}