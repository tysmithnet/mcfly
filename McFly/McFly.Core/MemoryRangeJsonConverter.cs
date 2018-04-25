// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-24-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-24-2018
// ***********************************************************************
// <copyright file="MemoryRangeJsonConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Core
{
    /// <summary>
    /// Class MemoryRangeJsonConverter.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class MemoryRangeJsonConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is MemoryRange memoryRange)) return;
            writer.WriteStartObject();
            writer.WritePropertyName("LowAddress");
            writer.WriteValue(memoryRange.LowAddress);
            writer.WritePropertyName("HighAddress");
            writer.WriteValue(memoryRange.HighAddress);
            writer.WriteEndObject();
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!(existingValue is MemoryRange memoryRange)) return existingValue;
            var jobj = JObject.Load(reader);
            foreach (var prop in jobj)
            {
                switch (prop.Key)
                {
                    case "LowAddress":
                        memoryRange.LowAddress = prop.Value.Value<ulong>();
                        break;
                    case "HighAddress":
                        memoryRange.HighAddress = prop.Value.Value<ulong>();
                        break;
                }
            }

            return existingValue;
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MemoryRange);
        }
    }
}