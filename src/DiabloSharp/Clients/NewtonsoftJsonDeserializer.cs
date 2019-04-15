using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace DiabloSharp.Clients
{
    internal class NewtonsoftJsonDeserializer : IDeserializer
    {
        private readonly JsonSerializer _serializer;

        public NewtonsoftJsonDeserializer()
        {
            _serializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Error };
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content;

            using (var stringReader = new StringReader(content))
            using (var jsonTextReader = new JsonTextReader(stringReader))
                return _serializer.Deserialize<T>(jsonTextReader);
        }
    }
}