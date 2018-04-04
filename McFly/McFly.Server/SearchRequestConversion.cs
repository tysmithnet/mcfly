using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using McFly.Server.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server
{
    internal class SearchRequestJsonConverter : JsonConverter<SearchCriterionDto>, IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (!typeof(SearchCriterionDto).IsAssignableFrom(bindingContext.ModelType)) return false;
            var val = bindingContext.ValueProvider.GetValue(
                bindingContext.ModelName);
            if (val == null) return false;

            ;
            return true;
        }

        public override void WriteJson(JsonWriter writer, SearchCriterionDto value, JsonSerializer serializer)
        {
            var visitor = new SearchResultJsonWriterVisitor();
            var o = visitor.ConvertToJObject(value);
            writer.WriteToken(o.CreateReader());
        }

        public override SearchCriterionDto ReadJson(JsonReader reader, Type objectType,
            SearchCriterionDto existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var o = JObject.Load(reader);
            return ExtractCriterion(o);
        }

        private SearchCriterionDto ExtractCriterion(JObject o)
        {
            string type = null;
            string[] exp = null;
            SearchCriterionDto[] arr = null;
            foreach (var prop in o)
                switch (prop.Key)
                {
                    case "Type":
                        type = prop.Value.Value<string>();
                        break;
                    case "Args":
                        if (prop.Value is JArray jarr1) exp = jarr1.Values<string>().ToArray();
                        break;
                    case "SubCriteria":
                        if (prop.Value is JArray jarr2)
                            arr = jarr2.OfType<JObject>().Select(ExtractCriterion).ToArray();
                        break;
                }
            if (exp != null)
                return new TerminalSearchCriterionDto
                {
                    Type = type,
                    Args = exp
                };
            return new SearchCriterionDto
            {
                Type = type,
                SubCriteria = arr
            };
        }
    }
}