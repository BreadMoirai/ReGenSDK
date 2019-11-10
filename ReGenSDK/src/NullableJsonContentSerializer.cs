using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace ReGenSDK
{
    public class NullableJsonContentSerializer : JsonContentSerializer
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public NullableJsonContentSerializer()
        {
        }

        public NullableJsonContentSerializer(JsonSerializerSettings jsonSerializerSettings) : base(
            jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public new async Task<T> DeserializeAsync<T>(HttpContent content)
        {
            var serializer = JsonSerializer.Create(_jsonSerializerSettings);
            using (var stream = await content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var reader = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(reader))
                return serializer.Deserialize<T>(jsonTextReader);

        }
    }
}