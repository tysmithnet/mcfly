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
        public ISearchPlanInterpreter SearchPlanInterpreter { get; set; }

        [Import]
        public ISearchResultDisplayStrategy SearchResultDisplayStrategy { get; set; }

        public void Process(string[] args)
        {
            
        }
    }
}