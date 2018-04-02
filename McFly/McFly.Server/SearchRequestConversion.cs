using System;
using System.Linq;
using McFly.Server.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server
{
    internal class SearchRequestJsonConverter : JsonConverter<SearchRequest>
    {
        public override void WriteJson(JsonWriter writer, SearchRequest value, JsonSerializer serializer)
        {
        }

        public override SearchRequest ReadJson(JsonReader reader, Type objectType, SearchRequest existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    internal class SearchResultJsonWriterVisitor : ISearchRequestVisitor
    {
        public string ConvertToJson(SearchRequest searchRequest)
        {
            var o = (JObject) Visit(searchRequest.Criterion);
            return o.ToString(Formatting.Indented);
        }

        public object Visit(Criterion criterion)
        {
            if (criterion is TerminalCriterion terminal)
                return Visit(terminal);
            var o = new JObject {{"Type", criterion.Type}};
            var childObjects = criterion.SubCriteria.Select(c => c.Accept(this)).Cast<JObject>().ToArray();
            var arr = new JArray(childObjects);
            o.Add("SubCriteria", arr);
            return o;
        }

        public object Visit(TerminalCriterion criterion)
        {
            var o = new JObject {{"Type", criterion.Type}, {"Expression", criterion.Expression}};
            return o;
        }
    }
}