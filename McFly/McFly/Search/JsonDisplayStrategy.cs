using System.ComponentModel.Composition;
using Newtonsoft.Json;

namespace McFly.Search
{
    [Export(typeof(ISearchResultDisplayStrategy))]
    internal class JsonDisplayStrategy : ISearchResultDisplayStrategy
    {
        [Import]
        internal IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <inheritdoc />
        public bool CanDisplay(object obj)
        {
            return true;
        }

        /// <inheritdoc />
        public void Display(object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            DebugEngineProxy.WriteLine(json);
        }
    }
}