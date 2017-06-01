using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordRest.Models;
using DiscordRest.Services;
using DiscordRest.Utility;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging.Abstractions;

namespace DiscordRest
{
    /// <inheritdoc />
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

        /// <inheritdoc />
        public T Run<T>(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody)
        {
            return RunAsync<T>(method, url, requestBody).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<T> RunAsync<T>(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody)
        {
            using (var con = await CreateConnectionAsync(method, url, requestBody, DiscordConstants.AuthenticationSchemes.Bearer))
            {
                var result = await RunRequestAsync(con);

                //TODO: Exception and error handling
                var content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(content);
            }
        }

        private async Task<HttpResponseMessage> RunRequestAsync(IHttpConnection con)
        {
            var result = await con.RunAsync();

            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _tokenService.RenewTokensAsync(_userContext.UserIdentification);
                con.SetBearerToken(await _tokenStore.GetAccessTokenAsync(_userContext.UserIdentification));
                result = await con.RunAsync();
            }

            return result;
        }

        /// <inheritdoc />
        public async Task<ServiceResult> RunAsync(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody)
        {
            using (var con = await CreateConnectionAsync(method, url, requestBody, DiscordConstants.AuthenticationSchemes.Bearer))
            {
                var result = await RunRequestAsync(con);

                //TODO: Improve error message
                if(!result.IsSuccessStatusCode)
                    return ServiceResult.Failed("REQUEST_FAILED", "Service status code indicates a failure");
            }

            return ServiceResult.Success;
        }

        private async Task<IHttpConnection> CreateConnectionAsync(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> requestBody, string authScheme)
        {
            var token = await _tokenStore.GetAccessTokenAsync(_userContext.UserIdentification);

            var builder = _httpConnectionBuilder
                .AddMethod(method)
                .AddToken(token)
                .AddPath(url)
                .AddParams(requestBody);

            return builder.Build(authScheme);
        }
    }
}