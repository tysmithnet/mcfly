// ***********************************************************************
// Assembly         : McFly.Server.Conversion
// Author           : @tysmithnet
// Created          : 04-24-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="MemoryChunkJsonConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using McFly.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server.Conversion
{
    /// <summary>
    ///     Json converter for <see cref="MemoryChunk" />
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{McFly.Core.MemoryChunk}" />
    public class MemoryChunkJsonConverter : JsonConverter<MemoryChunk>
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
        public override MemoryChunk ReadJson(JsonReader reader, Type objectType, MemoryChunk existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jobj = JObject.Load(reader);
            byte[] bytes = null;
            Position position = null;
            MemoryRange memoryRange = null;
            foreach (var prop in jobj)
                switch (prop.Key)
                {
                    case "Bytes":
                        bytes = prop.Value.Value<byte[]>();
                        break;
                    case "Position":
                        position = prop.Value.ToObject<Position>(serializer);
                        break;
                    case "MemoryRange":
                        memoryRange = prop.Value.Value<MemoryRange>();
                        break;
                }
            return new MemoryChunk
            {
                Bytes = bytes,
                Position = position,
                MemoryRange = memoryRange
            };
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, MemoryChunk value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}