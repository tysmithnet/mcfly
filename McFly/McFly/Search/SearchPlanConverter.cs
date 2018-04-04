using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Server.Contract;

namespace McFly.Search
{
    [Export(typeof(ISearchPlanConverter))]
    internal class SearchPlanConverter : ISearchPlanConverter
    {
        private static readonly string[] Separators = {"AND", "OR"};

        /// <inheritdoc />
        public SearchCriterionDto Convert(ISearchPlan searchPlan)
        {
            var subs = searchPlan.SearchFilters.Select(Helper).ToArray();
            if (subs.Length == 1)
                return subs[0];
            var crit = new SearchCriterionDto
            {
                Type = "and",
                SubCriteria = subs
            };
            return crit;
        }

        private SearchCriterionDto Helper(SearchFilter filter)
        {
            SearchCriterionDto result;
            switch (filter.Command)
            {
                case "where":
                    result = ExtractWhere(filter.Args.ToArray(), 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown command: {filter.Command}");
            }

            return result;
        }

        private SearchCriterionDto ExtractWhere(string[] args, int start)
        {
            if (args == null || !args.Any() || start > args.Length) return null;
            var property = args[start];
            switch (property)
            {
                case "rax":
                case "rbx":
                    var newArgs = args.Skip(start).TakeWhile(s => !Separators.Contains(s)).ToArray();
                    var term = new TerminalSearchCriterionDto
                    {
                        Type = "register",
                        Args = newArgs
                    };
                    if (start + newArgs.Length >= args.Length) return term;
                    return ExtractCompound(args, start + newArgs.Length, term);
                default:
                    throw new Exception("asabab");
            }
        }

        private SearchCriterionDto ExtractCompound(string[] args, int start, SearchCriterionDto lhs)
        {
            if (args == null || !args.Any() || start > args.Length) return null;
            var op = args[start];
            var crit = new SearchCriterionDto();
            var list = new List<SearchCriterionDto>();
            if (op == "AND")
                crit.Type = "and";
            else if (op == "OR")
                crit.Type = "or";
            else
                throw new Exception("Aasdfj;asldkfmn");
            list.Add(lhs);
            list.Add(ExtractWhere(args, start + 1));
            crit.SubCriteria = list.ToArray();
            return crit;
        }
    }
}