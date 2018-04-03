using System.Linq;
using McFly.Server.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server
{
    internal class SearchResultJsonWriterVisitor : ISearchRequestVisitor
    {
        public object Visit(SearchCriterionDto searchCriterionDto)
        {
            if (searchCriterionDto is TerminalSearchCriterionDto terminal)
                return Visit(terminal);
            var o = new JObject {{"Type", searchCriterionDto.Type}};
            var childObjects = searchCriterionDto.SubCriteria.Select(c => c.Accept(this)).Cast<JObject>().ToArray();
            var arr = new JArray(childObjects);
            o.Add("SubCriteria", arr);
            return o;
        }

        public string ConvertToJson(SearchCriterionDto searchRequest)
        {
            return ConvertToJObject(searchRequest).ToString(Formatting.Indented);
        }

        public JObject ConvertToJObject(SearchCriterionDto searchRequest)
        {
            var o = (JObject) Visit(searchRequest);
            return o;
        }

        public object Visit(TerminalSearchCriterionDto searchCriterionDto)
        {
            var o = new JObject
            {
                {"Type", searchCriterionDto.Type},
                { "Args", new JArray(searchCriterionDto.Args)}
            };
            return o;
        }
    }
}