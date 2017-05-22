using DiscordRest.Configuration;
using DiscordRest;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DiscordRest.Utility
{
    public class HttpClientHelper : IHttpClientHelper, IDisposable
    {
        private readonly HttpClient _client;

        private ConnectionOptions _options;
        private HttpMethod _httpMethod = HttpMethod.Get; 
        private string _url;
        

        public HttpClientHelper()
        {
            _client = new HttpClient();
            _options = new ConnectionOptions();
        }

        public IHttpClientHelper Configure(Action<ConnectionOptions> options)
        {
            options.Invoke(_options);
            return this;
        }

        public IHttpClientHelper AddOptions(ConnectionOptions options)
        {
            _options = options;
            return this;
        }

        public IHttpClientHelper AddPath(string url, HttpMethod httpMethod = null)
        {
            if(!url.StartsWith("http://") && url.StartsWith("https://"))
                throw new Exception("Not valid a valid url");

            if(_httpMethod != null)
                _httpMethod = httpMethod;

            return this;
        }
            
        public Task<HttpResponseMessage> RunAsync()
        {
            //TODO: Fix params and validation
            if (_httpMethod == HttpMethod.Get)
                return _client.GetAsync(_url);

            if (_httpMethod == HttpMethod.Post)
                return _client.PostAsync(_url, null);

            if (_httpMethod == HttpMethod.Put)
                return _client.PutAsync(_url, null);
                
            if (_httpMethod == HttpMethod.Delete)
                return _client.DeleteAsync(_url);

            throw new NotSupportedException($"Request method {_httpMethod} is not supported");
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
