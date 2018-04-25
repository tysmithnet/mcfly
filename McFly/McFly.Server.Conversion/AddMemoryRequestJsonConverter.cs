// ***********************************************************************
// Assembly         : McFly.Server.Conversion
// Author           : @tysmithnet
// Created          : 04-24-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="AddMemoryRequestJsonConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using McFly.Core;
using McFly.Server.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server.Conversion
{
    /// <summary>
    ///     Class AddMemoryRequestJsonConverter.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{McFly.Server.Contract.AddMemoryRequeset}" />
    public class AddMemoryRequestJsonConverter : JsonConverter<AddMemoryRequeset>
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
        public override AddMemoryRequeset ReadJson(JsonReader reader, Type objectType, AddMemoryRequeset existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jobj = JObject.Load(reader);
            MemoryChunk memoryChunk = null;
            foreach (var prop in jobj)
                switch (prop.Key)
                {
                    case "MemoryChunk":
                        memoryChunk = prop.Value.ToObject<MemoryChunk>();
                        break;
                }
            return new AddMemoryRequeset(memoryChunk);
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, AddMemoryRequeset value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}