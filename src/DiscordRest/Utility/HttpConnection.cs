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
            //TODO: Fix params and validation
            if (_method == HttpMethod.Get)
                return await _client.GetAsync(_url);

            if (_method == HttpMethod.Post)
                return await _client.PostAsync(_url, _content);

            if (_method == HttpMethod.Put)
                return await _client.PutAsync(_url, _content);

            if (_method == HttpMethod.Delete)
                return await _client.DeleteAsync(_url);

            throw new NotSupportedException($"Request method {_method} is not supported");
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