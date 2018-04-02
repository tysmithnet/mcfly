using System;
using System.Linq;
using McFly.Server.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server.Contract
{
    internal class SearchRequestJsonConverter : JsonConverter<Criterion>
    {
        public override void WriteJson(JsonWriter writer, Criterion value, JsonSerializer serializer)
        {
            var visitor = new SearchResultJsonWriterVisitor();
            var o = visitor.ConvertToJObject(value);
            writer.WriteToken(o.CreateReader());
        }

        public override Criterion ReadJson(JsonReader reader, Type objectType, Criterion existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            return existingValue;
        }
    }

    internal class SearchResultJsonWriterVisitor : ISearchRequestVisitor
    {
        public string ConvertToJson(Criterion searchRequest)
        {
            return ConvertToJObject(searchRequest).ToString(Formatting.Indented);
        }

        public JObject ConvertToJObject(Criterion searchRequest)
        {
            var o = (JObject)Visit(searchRequest);
            return o;
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