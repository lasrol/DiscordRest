using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Exceptions;
using DiscordRest.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace DiscordRest.Endpoints.Implementations
{
    public class TokenEndpoint : ITokenEndpoint
    {
        private readonly IHttpConnectionBuilder _connectionBuilder;
        private readonly ITokenStore _tokenStore;
        private readonly ILogger<TokenEndpoint> _logger;

        public TokenEndpoint(IHttpConnectionBuilder connectionBuilder, ITokenStore tokenStore, ILogger<TokenEndpoint> logger)
        {
            _connectionBuilder = connectionBuilder;
            _tokenStore = tokenStore;
            _logger = logger;
        }

        public virtual async Task RenewTokensAsync(string userIdentification)
        {
            var refreshToken = await _tokenStore.GetRefreshTokenAsync(userIdentification);
            if(string.IsNullOrWhiteSpace(refreshToken))
                throw new InvalidTokenException("refresh token not found");

            _logger.LogDebug($"Renewing token for {userIdentification} with refresh token {refreshToken}");

            var parameters = new Dictionary<string, string>
            {
                { "grant_type","refresh_token" },
                { "refresh_token", refreshToken }
            };

            var builder = _connectionBuilder
                .AddMethod(HttpMethod.Post)
                .AddPath("/oauth2/token")
                .AddParams(parameters);

            using (var con = builder.Build(DiscordConstants.AuthenticationSchemes.Basic))
            {
                var result = await con.RunAsync();
                if(result.StatusCode == HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException("Could not refresh tokens with provided refresh token");

                if (!result.IsSuccessStatusCode) { 
                    _logger.LogError($"Request to renew token failed, with {result.StatusCode} and {result.ReasonPhrase}");
                    throw new HttpRequestException("Request to renew tokens failed");
                }

                var content = await result.Content.ReadAsStringAsync();
                var tokens = JsonConvert.DeserializeObject<DiscordTokens>(content);

                if(string.IsNullOrWhiteSpace(tokens.AccessToken) || string.IsNullOrWhiteSpace(tokens.RefreshToken))
                    throw new InvalidTokenException("Discord token response is invalid");

                await _tokenStore.SaveTokensAsync(userIdentification, tokens);
            }
        }
    }
}
