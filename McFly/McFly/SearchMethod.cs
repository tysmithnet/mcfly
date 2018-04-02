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
        public ISearchResultDisplayStrategy SearchResultDisplayStrategy { get; set; }

        public void Process(string[] args)
        {
            
        }
    }
}