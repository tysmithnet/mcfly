// ***********************************************************************
// Assembly         : McFly.Core.JsonConverters
// Author           : @tysmithnet
// Created          : 04-24-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-24-2018
// ***********************************************************************
// <copyright file="PositionJsonConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using McFly.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server.Conversion
{
    /// <summary>
    ///     Class PositionJsonConverter.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{McFly.Core.Position}" />
    public class PositionJsonConverter : JsonConverter<Position>, IModelBinder
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
        /// <inheritdoc />
        public override Position ReadJson(JsonReader reader, Type objectType, Position existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jobj = JObject.Load(reader);
            int? low = null;
            int? high = null;
            foreach (var prop in jobj)
                switch (prop.Key)
                {
                    case "Low":
                        low = prop.Value.Value<int>();
                        break;
                    case "High":
                        high = prop.Value.Value<int>();
                        break;
                }

            if (low == null) throw new JsonSerializationException("Low must be a valid positive integer");
            if (high == null) throw new JsonSerializationException("High must be a valid positive integer");
            return new Position(high.Value, low.Value);
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, Position value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Low");
            writer.WriteValue(value.Low);
            writer.WritePropertyName("High");
            writer.WriteValue(value.High);
            writer.WriteEndObject();
        }

        /// <inheritdoc />
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (!typeof(Position).IsAssignableFrom(bindingContext.ModelType)) return false;
            var val = bindingContext.ValueProvider.GetValue(
                bindingContext.ModelName);
            if (val == null) return false;
            return true;
        }
    }
}