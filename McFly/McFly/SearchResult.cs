using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    public class SearchMethod : IMcFlyMethod
    {
        [ImportMany]
        public ISearchResultDisplayStrategy[] DisplayStrategies { get; set; }

        [ImportMany]
        public ISearchIndex[] SearchIndices { get; set; }

        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("search")
            .SetDescription("Search for indexed content")
            //.AddExample("!mf search frame -rax 1 -mod kernel32 -fun *Create*", "Find frames where rax=1 and the mask for the frame is kernel32!*Create*")
            //.AddExample("!mf search all regex nt*", "Search all indices for content matching the regex \"nt.*\"")
            //.AddExample("!mf search note -text \"encryption\"", "Search for all notes containing encryption")
            .AddExample("!mf search kernel32", "Searches for frames that contain kernel32")
            .Build();

        public void Process(string[] args)
        {
        }
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