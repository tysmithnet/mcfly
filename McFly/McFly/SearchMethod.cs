using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    public class SearchMethod : IMcFlyMethod
    {                                                                       
        [ImportMany]
        public ISearchIndex[] SearchIndices { get; set; }

        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("search")
            .SetDescription("Search for indexed content")
            .Build();
         
        [Import]
        internal ISearchPlanFactory Factory { get; set; }

        [Import]
        internal ISearchPlanInterpreter Interpreter { get; set; }

        [Import]
        internal ISearchResultDisplayStrategy SearchResultDisplayStrategy { get; set; }

        public void Process(string[] args)
        {
            var plan = Factory.Create(args);
            var results = Interpreter.Interpret(plan);
            SearchResultDisplayStrategy.Display(results);
        }
    }

    public interface ISearchPlanFactory
    {
        ISearchPlan Create(string[] args);
    }
}