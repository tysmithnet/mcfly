using System;
using System.Collections.Generic;

namespace McFly
{
    internal class SearchPlanFactory : ISearchPlanFactory
    {
        /// <inheritdoc />
        public ISearchPlan Create(string[] args)
        {
            if(args == null)
                throw new ArgumentNullException(nameof(args));

            if(args.Length == 0)
                throw new ArgumentOutOfRangeException("You must at least specify the index to use");

            string index = args[0];

            var list = new List<SearchFilter>();

            for (int i = 1; i < args.Length; i++)
            {
                var arg = args[i];

                if (arg != "|")
                {
                    var filter = new SearchFilter()
                    {
                        Command = arg,
                        Args = new List<string>()
                    };
                    for (int j = i + 1; j < args.Length && args[j] != "|"; j++)
                    {
                        filter.Args.Add(args[j]);
                        i++;
                    }
                }
            }

            return new SearchPlan(index, list);
        }
    }
}