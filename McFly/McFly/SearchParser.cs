using System;
using System.Linq;
using McFly.Core;
using MoreLinq;

namespace McFly
{
    public class SearchParser : ISearchParser
    {
        public SearchPlan Parse(string[] args)
        {
            if(args == null || !args.Any())
                return new SearchPlan();

            var plan = new SearchPlan();

            var parts = args.Split(s => s == "|").ToList();
            var initialSearchArgs = parts.First().ToList();
            var rest = parts.Skip(1);
            
            for (int i = 0; i < initialSearchArgs.Count; i++)
            {
                var arg = args[i];
                switch (arg)
                {
                    case "-s":
                    case "--start":
                        if(i + 1 >= args.Length)
                            throw new ArgumentOutOfRangeException($"You must provide a value for {arg}");
                        plan.InitialSearch.Start = Position.Parse(args[++i]);
                        break;
                    case "-e":
                    case "--end":
                        if (i + 1 >= args.Length)
                            throw new ArgumentOutOfRangeException($"You must provide a value for {arg}");
                        plan.InitialSearch.End = Position.Parse(args[++i]);
                        break;
                    default:
                        plan.InitialSearch.SearchTerm = arg;
                        break;
                }
            }

            foreach (var filterArgs in rest)
            {
                var filter = new SearchFilter();
                var list = filterArgs.ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    var arg = list[i];
                    switch (i)
                    {
                        case 0:
                            filter.Command = arg;
                            break;
                        default:
                            filter.Args.Add(arg);
                            break;
                    }
                }
                plan.AddSearchFilter(filter);
            }

            return plan;
        }
    }
}