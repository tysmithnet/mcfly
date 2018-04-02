using System.ComponentModel.Composition;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    public class SearchMethod : IMcFlyMethod
    {
        [Import]
        internal ISearchPlanFactory Factory { get; set; }

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
}