using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarsManagement.Shared.Converters;

public class BoolConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        if (token.Type == JTokenType.String) return token.ToString() == "1";
        return token.ToObject<bool>();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}