using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DiabloSharp.Exceptions;
using DiabloSharp.RateLimit;
using Newtonsoft.Json;

namespace DiabloSharp.Clients
{
    internal class HttpClientBase : IDisposable
    {
        private readonly Dictionary<string, string> _parameters;

        private readonly RateLimiter _rateLimiter;

        private bool _disposedValue;

        public HttpClientBase(string baseAddress)
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _parameters = new Dictionary<string, string>();
            _rateLimiter = new RateLimiter(125, TimeSpan.FromSeconds(1));
        }

        protected HttpClient Client { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddParameter(string key, string value)
        {
            _parameters.Add(key, value);
        }

        {
        public Task<T> GetAsync<T>(string requestUri)
        {
            return _rateLimiter.Perform(() => GetAsyncInternal<T>(requestUri));
        }

        public Task<T> PostAsync<T>(string requestUri)
        {
            return _rateLimiter.Perform(() => PostAsyncInternal<T>(requestUri));
        }

        private async Task<T> GetAsyncInternal<T>(string requestUri)
        {
            var uriWithParameters = requestUri + BuildUrlParameters();
            using (var response = await Client.GetAsync(uriWithParameters))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                if (response.IsSuccessStatusCode)
                    return await DeserializeJsonFromStreamAsync<T>(stream);

                var content = await StreamToStringAsync(stream);
                throw new DiabloApiHttpException(requestUri, response.StatusCode, content);
            }
        }

        private async Task<T> PostAsyncInternal<T>(string requestUri)
        {
            var body = new FormUrlEncodedContent(_parameters);
            using (var response = await Client.PostAsync(requestUri, body))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                if (response.IsSuccessStatusCode)
                    return await DeserializeJsonFromStreamAsync<T>(stream);

                var content = await StreamToStringAsync(stream);
                throw new DiabloApiHttpException(requestUri, response.StatusCode, content);
            }
        }

        private string BuildUrlParameters()
        {
            var urlBuilder = new StringBuilder();

            var first = true;
            foreach (var parameter in _parameters)
            {
                var separator = "&";
                if (first)
                {
                    separator = "?";
                    first = false;
                }

                urlBuilder.Append($"{separator}{parameter.Key}={parameter.Value}");
            }

            return urlBuilder.ToString();
        }

        private async Task<T> DeserializeJsonFromStreamAsync<T>(Stream stream)
        {
            return await Task.Run(() =>
            {
                if (stream == null || stream.CanRead == false)
                    return default;

                using (var streamReader = new StreamReader(stream))
                using (var textReader = new JsonTextReader(streamReader))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(textReader);
                }
            });
        }

        private async Task<string> StreamToStringAsync(Stream stream)
        {
            if (stream == null)
                return string.Empty;
            using (var streamReader = new StreamReader(stream))
                return await streamReader.ReadToEndAsync();
        }

        private void Dispose(bool disposing)
        {
            if (_disposedValue)
                return;

            if (disposing)
            {
                Client.Dispose();
                _rateLimiter.Dispose();
            }

            _disposedValue = true;
        }

        ~HttpClientBase()
        {
            Dispose(false);
        }
    }
}