using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DiabloSharp.Exceptions;
using DiabloSharp.RateLimiters;
using Utf8Json;
using Utf8Json.Resolvers;

namespace DiabloSharp.Clients
{
    internal abstract class HttpClientBase : IDisposable
    {
        private readonly Dictionary<string, string> _parameters;

        private readonly ITokenBucket _tokenBucket;

        private bool _disposedValue;

        protected HttpClientBase(string baseAddress, ITokenBucket tokenBucket)
        {
            _tokenBucket = tokenBucket;
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _parameters = new Dictionary<string, string>();
        }

        protected HttpClient Client { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void AddParameter(string key, string value)
        {
            _parameters.Add(key, value);
        }

        protected async Task<T> GetAsync<T>(string requestUri)
        {
            await _tokenBucket.ConsumeAsync();

            var uriWithParameters = requestUri + BuildUrlParameters();
            using (var response = await Client.GetAsync(uriWithParameters))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                if (response.IsSuccessStatusCode)
                    return await JsonSerializer.DeserializeAsync<T>(stream, StandardResolver.AllowPrivate);

                var content = await StreamToStringAsync(stream);
                throw new DiabloApiHttpException(requestUri, response.StatusCode, content);
            }
        }

        protected async Task<T> PostAsync<T>(string requestUri)
        {
            await _tokenBucket.ConsumeAsync();

            var body = new FormUrlEncodedContent(_parameters);
            using (var response = await Client.PostAsync(requestUri, body))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                if (response.IsSuccessStatusCode)
                    return await JsonSerializer.DeserializeAsync<T>(stream, StandardResolver.AllowPrivate);

                var content = await StreamToStringAsync(stream);
                throw new DiabloApiHttpException(requestUri, response.StatusCode, content);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
                return;

            if (disposing)
                Client.Dispose();

            _disposedValue = true;
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

        private async Task<string> StreamToStringAsync(Stream stream)
        {
            if (stream == null)
                return string.Empty;
            using (var streamReader = new StreamReader(stream))
                return await streamReader.ReadToEndAsync();
        }

        ~HttpClientBase()
        {
            Dispose(false);
        }
    }
}