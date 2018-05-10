// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="SearchRequestConversion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using McFly.Server.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server.Conversion
{
    /// <summary>
    ///     Json converter for <see cref="SearchCriterionDto" />
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{McFly.Server.Core.SearchCriterionDto}" />
    /// <seealso cref="System.Web.Http.ModelBinding.IModelBinder" />
    public class SearchCriterionDtoJsonConverter : JsonConverter<SearchCriterionDto>
    {
        /// <summary>
        ///     Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">
        ///     The existing value of object being read. If there is no existing value then <c>null</c>
        ///     will be used.
        /// </param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override SearchCriterionDto ReadJson(JsonReader reader, Type objectType,
            SearchCriterionDto existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var o = JObject.Load(reader);
            return ExtractCriterion(o);
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, SearchCriterionDto value, JsonSerializer serializer)
        {
            var visitor = new SearchRequestJsonWriterVisitor();
            var o = visitor.ConvertToJObject(value);
            writer.WriteToken(o.CreateReader());
        }

        /// <summary>
        ///     Extracts the criterion.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>SearchCriterionDto.</returns>
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