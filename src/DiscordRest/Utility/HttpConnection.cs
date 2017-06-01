using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DiscordRest.Extensions;

namespace DiscordRest.Utility
{
    public class HttpConnection : IHttpConnection, IDisposable
    {
        private readonly HttpClient _client;
        private readonly HttpMethod _method;
        private readonly string _url;
        private readonly HttpContent _content;

        public HttpConnection(HttpClient client, HttpMethod method, string url, HttpContent content = null)
        {
            _client = client;
            _method = method;
            _url = url;
            _content = content;
        }

        public HttpRequestMessage Run()
        {
            throw new NotImplementedException();    
        }

        public async Task<HttpResponseMessage> RunAsync()
        {
            if (!IsSupported(_method))
            {
                throw new NotSupportedException($"Request method {_method} is not supported");
            }

            //TODO: check params and validation
            var request = new HttpRequestMessage(_method, _url)
            {
                Content = _content
            };

            return await _client.SendAsync(request);
        }

        private bool IsSupported(HttpMethod method)
        {
            if (_method == HttpMethod.Get)
                return true;

            if (_method == HttpMethod.Post)
                return true;

            if (_method == HttpMethod.Put)
                return true;

            if (_method == HttpMethod.Delete)
                return true;

            if (_method.Method == "PATCH")
                return true;

            return false;
        }

        public void SetBearerToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization =
                AuthenticationHeaderValueBuilder.Build(DiscordConstants.AuthenticationSchemes.Bearer, token);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}