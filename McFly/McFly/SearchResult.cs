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
            //.AddExample("!mf search frame -rax 1 -mod kernel32 -fun *Create*", "Find frames where rax=1 and the mask for the frame is kernel32!*Create*")
            //.AddExample("!mf search all regex nt*", "Search all indices for content matching the regex \"nt.*\"")
            //.AddExample("!mf search note -text \"encryption\"", "Search for all notes containing encryption")
            .AddExample("!mf search", "List all indexed frames (up to the setting \"MaxNumSearchResults\")")
            .AddExample("!mf search -s 0:0 -e 100:0", "List all indexed frames between position 0:0 and 100:0")
            .AddExample("!mf search kernel32", "Searches all indices for the general term kernel32")
            .AddExample("!mf search | where rax -eq 1 and mod -contains 32 | fields rax rip mod fun", "Get the rax, rip, mod, fun all frames where rax=1 the instruction module contains 32")
            .Build();

        [Import]
        public ISearchParser SearchParser { get; set; }

        [Import]
        public ISearchPlanInterpreter SearchPlanInterpreter { get; set; }

        [Import]
        public ISearchResultDisplayStrategy SearchResultDisplayStrategy { get; set; }

        public void Process(string[] args)
        {
            var searchPlan = SearchParser.Parse(args);
            var searchResults = SearchPlanInterpreter.Interpret(searchPlan);
            SearchResultDisplayStrategy.Display(searchResults);
            /*
             tokenize everything
             construct search plan
             give it to the search plan executor and get results
             display results in text table
             */
             
        }
    }

    public class SearchParser : ISearchParser
    {
        public SearchPlan Parse(string[] args)
        {
            return null;
        }
    }

    public class SearchPlanInterpreter : ISearchPlanInterpreter
    {
        public IEnumerable<ISearchResult> Interpret(SearchPlan searchPlan)
        {
            throw new System.NotImplementedException();
        }
    }

    public class SearchPlan : ISearchPlan
    {
        public InitialSearch InitialSearch { get; set; }
        public IEnumerable<SearchFilter> SearchFilters { get; set; }
    }

    public sealed class InitialSearch
    {
        
    }

    public sealed class SearchFilter
    {
        public string Property { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }


    public interface ISearchResult : IInjectable
    {
        string DisplayText { get; set; }
    }

    public interface ISearchIndex : IInjectable
    {
        IEnumerable<ISearchResult> GeneralSearch(string searchText);
        IEnumerable<ISearchResult> Search(string[] args);
    }

    public interface ISearchResultDisplayStrategy : IInjectable
    {
        void Display(IEnumerable<ISearchResult> searchResults);
    }
}