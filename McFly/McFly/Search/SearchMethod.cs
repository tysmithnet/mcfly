using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Server.Contract;

namespace McFly.Search
{
    [Export(typeof(IMcFlyMethod))]
    public class SearchMethod : IMcFlyMethod
    {
        [Import]
        internal ISearchPlanFactory Factory { get; set; }

        [Import]
        internal ISearchPlanConverter Converter { get; set; }

        [Import]
        internal ISearchPlanInterpreter Interpreter { get; set; }

        [Import]
        internal ISearchResultDisplayStrategy SearchResultDisplayStrategy { get; set; }

        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("search")
            .SetDescription("Search for indexed content")
            .AddExample("!mf search frame | reg rax -eq 1 OR rbx -neq 0",
                "Search for all frames where rax = 1 or rbx != 0")
            .Build();

        public void Process(string[] args)
        {
            var plan = Factory.Create(args);
            var results = Interpreter.Interpret(plan);
            SearchResultDisplayStrategy.Display(results);
        }
    }

    internal interface ISearchPlanConverter
    {
        SearchCriterionDto Convert(ISearchPlan searchPlan);
    }

    internal class SearchPlanConverter : ISearchPlanConverter
    {
        /// <inheritdoc />
        public SearchCriterionDto Convert(ISearchPlan searchPlan)
        {
            
        }

        private SearchCriterionDto Helper(SearchFilter filter)
        {
            SearchCriterionDto result;
            switch (filter.Command)
            {
                case "where":
                    for (int i = 0; i < filter.Args.Count; i++)
                    {
                        var arg = filter.Args[i];

                        switch (arg)
                        {
                            case "rax":
                                break;
                        }
                    }
                    result = new SearchCriterionDto();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown command: {filter.Command}");
            }

            return result;
        }

        private SearchCriterionDto Extract(string[] args, int start)
        {
            if (args == null || !args.Any() || start > args.Length) return null;
            var property = args[0];
            switch (property)
            {
                
            }
        }
    }
}