using Newtonsoft.Json;

namespace Utils.DataManagement.Serializers
{
    public class JsonSerializer : IDataSerializer
    {
        // Runtime
        private readonly JsonSerializerSettings _settings = null;

        public JsonSerializer()
        {
            _settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            };
        }

        public JsonSerializer(JsonSerializerSettings settings)
            => _settings = settings;

        public string Serialize<TData>(TData data)
            => JsonConvert.SerializeObject(data, _settings);

        public TData Deserialize<TData>(string serializedData)
            => JsonConvert.DeserializeObject<TData>(serializedData, _settings);
    }
}