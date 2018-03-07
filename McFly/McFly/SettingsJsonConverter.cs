using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly
{
    internal class SettingsJsonConverter : JsonConverter<IEnumerable<ISettings>>
    {
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

        public override IEnumerable<ISettings> ReadJson(JsonReader reader, Type objectType, IEnumerable<ISettings> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
