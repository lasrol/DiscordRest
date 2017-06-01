using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordRest.Services;
using DiscordRest.Utility;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging.Abstractions;

namespace DiscordRest
{
    /// <summary>
    /// Client created to handle HTTP request against the discord REST API
    /// </summary>
    public class DiscordHttpClient : IDiscordHttpClient
    {
        private readonly IHttpConnectionBuilder _httpConnectionBuilder;
        private readonly ITokenStore _tokenStore;
        private readonly ITokenService _tokenService;
        private readonly ILogger _logger;
        private readonly ICurrentUserContext _userContext;

        /// <summary>
        /// Utility for running the HTTP requests
        /// </summary>
        /// <param name="httpConnectionBuilder">Builds http request and run the connection</param>
        /// <param name="tokenStore">Store for authorization tokens used for discord services</param>
        /// <param name="tokenService">Service used to communicate with discord token endpoint</param>
        /// <param name="userContext">The user running the requests</param>
        /// <param name="logger">logger instance</param>
        public DiscordHttpClient(IHttpConnectionBuilder httpConnectionBuilder, ITokenStore tokenStore,
            ITokenService tokenService, ICurrentUserContext userContext, ILogger logger = null)
        {
            //TODO: Add injection for configuration for HttpClient
            _httpConnectionBuilder = httpConnectionBuilder;
            _tokenStore = tokenStore;
            _tokenService = tokenService;
            _logger = logger ?? NullLogger.Instance;
            _userContext = userContext;
        }

        /// <summary>
        /// Pass the request to the http connection, and handle the response and deserialization of the requested object
        /// </summary>
        /// <typeparam name="T">Data object the API returns</typeparam>
        /// <param name="method">Valid <see cref="HttpMethod"/></param>
        /// <param name="url">Relativ url for request</param>
        /// <param name="requestBody">any KeyValues to be passed along the request in the body</param>
        public T Run<T>(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody)
        {
            return RunAsync<T>(method, url, requestBody).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Pass the request to the http connection, and handle the response and deserialization of the requested object
        /// </summary>
        /// <typeparam name="T">Data object the API returns</typeparam>
        /// <param name="method">Valid <see cref="HttpMethod"/></param>
        /// <param name="url">Relativ url for request</param>
        /// <param name="requestBody">any KeyValues to be passed along the request in the body</param>
        public async Task<T> RunAsync<T>(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody)
        {
            var token = await _tokenStore.GetAccessTokenAsync(_userContext.UserIdentification);

            var builder = _httpConnectionBuilder
                .AddMethod(method)
                .AddToken(token)
                .AddPath(url)
                .AddParams(requestBody);

            using (var con = builder.Build(DiscordConstants.AuthenticationSchemes.Bearer))
            {
                var result = await con.RunAsync();

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await _tokenService.RenewTokensAsync(_userContext.UserIdentification);
                    con.SetBearerToken(await _tokenStore.GetAccessTokenAsync(_userContext.UserIdentification));
                    result = await con.RunAsync();
                }

                //TODO: Exception and error handling
                var content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}