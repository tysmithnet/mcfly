using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using McFly.Server.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server
{
    internal class SearchRequestJsonConverter : JsonConverter<SearchCriterionDto>, IModelBinder
    {
        public override void WriteJson(JsonWriter writer, SearchCriterionDto value, JsonSerializer serializer)
        {
            var visitor = new SearchResultJsonWriterVisitor();
            var o = visitor.ConvertToJObject(value);
            writer.WriteToken(o.CreateReader());
        }

        public override SearchCriterionDto ReadJson(JsonReader reader, Type objectType, SearchCriterionDto existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            JObject o = JObject.Load(reader);
            return ExtractCriterion(o);
        }

        private SearchCriterionDto ExtractCriterion(JObject o)
        {
            string type = null;
            string exp = null;
            SearchCriterionDto[] arr = null;
            foreach (var prop in o)
            {
                switch (prop.Key)
                {
                    case "Type":
                        type = prop.Value.Value<string>();
                        break;
                    case "Expression":
                        exp = prop.Value.Value<string>();
                        break;
                    case "SubCriteria":
                        if (prop.Value is JArray jarr)
                        {
                            arr = jarr.OfType<JObject>().Select(ExtractCriterion).ToArray();
                        }
                        break;
                }
            }
            if (exp != null)
                return new TerminalSearchCriterionDto()
                {
                    Type = type,
                    Expression = exp
                };
            else // todo: needs to check for type and arr
                return new SearchCriterionDto()
                {
                    Type = type,
                    SubCriteria = arr
                };
        }

        

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (!typeof(SearchCriterionDto).IsAssignableFrom(bindingContext.ModelType)) return false;
            ValueProviderResult val = bindingContext.ValueProvider.GetValue(
                bindingContext.ModelName);
            if (val == null) return false;
            
            ;
            return true;
        }
    }

    internal class SearchResultJsonWriterVisitor : ISearchRequestVisitor
    {
        public string ConvertToJson(SearchCriterionDto searchRequest)
        {
            return ConvertToJObject(searchRequest).ToString(Formatting.Indented);
        }

        public JObject ConvertToJObject(SearchCriterionDto searchRequest)
        {
            var o = (JObject)Visit(searchRequest);
            return o;
        }

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

        public object Visit(TerminalSearchCriterionDto searchCriterionDto)
        {
            var o = new JObject {{"Type", searchCriterionDto.Type}, {"Expression", searchCriterionDto.Expression}};
            return o;
        }
    }
}