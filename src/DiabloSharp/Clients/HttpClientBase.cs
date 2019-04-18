using DiabloSharp.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DiabloSharp.Clients
{
    internal class HttpClientBase : IDisposable
    {
        protected readonly HttpClient _httpClient = new HttpClient();

        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        private bool disposedValue = false;

        public HttpClientBase(Uri baseAddress)
        {
            _httpClient.BaseAddress = baseAddress;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task AddParameterAsync(string key, string value)
        {
            await Task.Run(() => AddParameter(key, value));
        }

        public void AddParameter(string key, string value)
        {
            _parameters.Add(key, value);
        }

        public virtual async Task<T> GetAsync<T>(string requestUri)
        {
            var uriWithParameters = requestUri + BuildUrlParameters();
            using (var response = await _httpClient.GetAsync(uriWithParameters))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                if (response.IsSuccessStatusCode)
                    return await DeserializeJsonFromStreamAsync<T>(stream);

                var content = await StreamToStringAsync(stream);
                throw new DiabloApiHttpException($"An error occured on HTTP GET {requestUri}.")
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }
        }

        public virtual async Task<T> PostAsync<T>(string requestUri)
        {
            var body = new FormUrlEncodedContent(_parameters);
            using (var response = await _httpClient.PostAsync(requestUri, body))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                if (response.IsSuccessStatusCode)
                    return await DeserializeJsonFromStreamAsync<T>(stream);

                var content = await StreamToStringAsync(stream);
                throw new DiabloApiHttpException($"An error occured on HTTP POST {requestUri}.")
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }
        }

        private string BuildUrlParameters()
        {
            if (!_parameters.Any())
                return string.Empty;

            var urlBuilder = new StringBuilder();
            var firstParameter = _parameters.First();
            urlBuilder.Append($"?{firstParameter.Key}={firstParameter.Value}");

            foreach (var parameter in _parameters.Skip(1))
                urlBuilder.Append($"&{parameter.Key}={parameter.Value}");

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
            string content = string.Empty;

            if (stream != null)
                using (var streamReader = new StreamReader(stream))
                    content = await streamReader.ReadToEndAsync();

            return content;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    _httpClient.Dispose();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
