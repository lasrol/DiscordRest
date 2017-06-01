using DiscordRest;
using DiscordRest.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DiscordRest.Extensions;

namespace DiscordRest.Utility
{
    /// <summary>
    /// Helper class to configure a valid <see cref="HttpConnection"/>
    /// </summary>
    public class HttpConnectionBuilder : IHttpConnectionBuilder
    {
        private HttpConnectionOptions _options;
        private HttpMethod _httpMethod = HttpMethod.Get; 
        private Uri _url;
        private IEnumerable<KeyValuePair<string, string>> _content;
        private string _token;
        private ITokenStore _tokenStore;

        /// <inheritdoc />
        public HttpConnectionBuilder()
        {
            _options = new HttpConnectionOptions();
            _url = new Uri(DiscordConstants.BaseUrl);
        }

        /// <inheritdoc />
        public HttpConnectionBuilder(HttpConnectionOptions options)
        {
            _options = options;
            _url = new Uri(DiscordConstants.BaseUrl);
        }

        /// <summary>
        /// Configure or override connection options 
        /// </summary>
        /// <param name="options">Action to setup any connection options</param>
        public IHttpConnectionBuilder Configure(Action<HttpConnectionOptions> options)
        {
            options.Invoke(_options);
            return this;
        }

        /// <summary>
        /// Overrides the default configuration with the specified options object
        /// </summary>
        /// <param name="options"><see cref="HttpConnectionOptions"/> will override any existing configuration</param>
        public IHttpConnectionBuilder AddOptions(HttpConnectionOptions options)
        {
            _options = options;
            return this;
        }

        public IHttpConnectionBuilder AddToken(string token)
        {
            _token = token;
            return this;
        }

        /// <summary>
        /// Add content to be passed along the request in the body
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public IHttpConnectionBuilder AddParams(IEnumerable<KeyValuePair<string, string>> content)
        {
            if (content == null) return this;
            _content = content;
            return this;
        }

        /// <summary>
        /// Add the http method for the request
        /// </summary>
        /// <param name="httpMethod"><see cref="HttpMethod"/> to be used in the request</param>
        public IHttpConnectionBuilder AddMethod(HttpMethod httpMethod)
        {
            _httpMethod = httpMethod;
            return this;
        }

        /// <summary>
        /// Appends the path to the base url
        /// </summary>
        /// <param name="url">relative path to query</param>
        public IHttpConnectionBuilder AddPath(string url)
        {
            url.EnsureSlashPrefixed();
            _url = new Uri(_url, _url.AbsolutePath + url);
            return this;
        }
            

        /// <summary>
        /// Build a valid <see cref="IHttpConnection"/> based on previous configuration
        /// </summary>
        /// <returns></returns>
        public virtual IHttpConnection Build(string authenticationSchemes = null)
        {
            if(string.IsNullOrEmpty(_options.ClientSecret) || string.IsNullOrEmpty(_options.ClientId))
                throw new InvalidOperationException("Require ClientId and ClientSecret to build httpConnection");

                //TODO: Setup httpclient with options and content body
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("UserAgent", DiscordConstants.UserAgent);
            
            if (authenticationSchemes == DiscordConstants.AuthenticationSchemes.Bearer && !string.IsNullOrEmpty(_token))
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValueBuilder.Build(DiscordConstants.AuthenticationSchemes.Bearer, _token);
            }

            if (authenticationSchemes == DiscordConstants.AuthenticationSchemes.Basic)
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValueBuilder.Build(DiscordConstants.AuthenticationSchemes.Basic, $"{_options.ClientId}:{_options.ClientSecret}");
            }

            if (_httpMethod == HttpMethod.Post || _httpMethod == HttpMethod.Put)
                return new HttpConnection(client, _httpMethod, _url.AbsoluteUri, new FormUrlEncodedContent(_content));

            return new HttpConnection(client, _httpMethod, _url.AbsoluteUri);
        }
    }
}
