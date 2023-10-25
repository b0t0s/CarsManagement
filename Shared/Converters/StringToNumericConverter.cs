using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarsManagement.Shared.Converters;

public class StringToNumericConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(int) || objectType == typeof(long) || objectType == typeof(double) ||
               objectType == typeof(decimal) || objectType == typeof(float) || objectType == typeof(short);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        if (token.Type == JTokenType.String)
        {
            var tokenValue = token.ToString();

            if (objectType == typeof(int))
                return (int)double.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(long))
                return (long)double.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(double))
                return double.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(decimal))
                return decimal.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(float))
                return float.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(short))
                return (short)double.Parse(tokenValue, CultureInfo.InvariantCulture);
        }

        return token.ToObject(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}