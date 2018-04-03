using System;
using System.ComponentModel.Composition;

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
        internal ISearchResultDisplayStrategy SearchResultDisplayStrategy { get; set; }

        [Import]
        internal IServerClient ServerClient { get; set; }

        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("search")
            .SetDescription("Search for indexed content")
            .AddExample("!mf search frame | reg rax -eq 1 OR rbx -neq 0",
                "Search for all frames where rax = 1 or rbx != 0")
            .Build();

        public void Process(string[] args)
        {
            var plan = Factory.Create(args);
            var converted = Converter.Convert(plan);
            if (plan.Index == SearchIndex.Frame.ShortName)
            {
                SearchResultDisplayStrategy.Display(ServerClient.SearchFrames(converted));
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Unknown index: {plan.Index}");
            }
        }
    }
}