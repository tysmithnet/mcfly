// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-06-2018
//
// Last Modified By : master
// Last Modified On : 03-06-2018
// ***********************************************************************
// <copyright file="SettingsJsonConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly
{
    /// <summary>
    ///     Class SettingsJsonConverter.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{System.Collections.Generic.IEnumerable{McFly.ISettings}}" />
    internal class SettingsJsonConverter : JsonConverter<IEnumerable<ISettings>>
    {
        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, IEnumerable<ISettings> value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (var settings in value)
            {
                var type = settings.GetType();
                var settingsValue = JObject.FromObject(settings);
                writer.WritePropertyName(type.AssemblyQualifiedName);
                writer.WriteToken(new JTokenReader(settingsValue));
            }
            writer.WriteEndObject();
        }

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
        /// <exception cref="NotImplementedException"></exception>
        public override IEnumerable<ISettings> ReadJson(JsonReader reader, Type objectType,
            IEnumerable<ISettings> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}