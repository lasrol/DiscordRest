using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Exceptions;
using DiscordRest.Models;
using DiscordRest.Utility;
using Newtonsoft.Json;
using DiscordRest.Data;

namespace DiscordRest.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IHttpConnectionBuilder _connectionBuilder;
        private readonly ITokenStore _tokenStore;

        public TokenService(IHttpConnectionBuilder connectionBuilder, ITokenStore tokenStore)
        {
            _connectionBuilder = connectionBuilder;
            _tokenStore = tokenStore;
        }

        public virtual async Task RenewTokensAsync(string userIdentification)
        {
            var refreshToken = await _tokenStore.GetRefreshTokenAsync(userIdentification);
            if(string.IsNullOrWhiteSpace(refreshToken))
                throw new InvalidTokenException("refresh token not found");

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

                if (!result.IsSuccessStatusCode)
                    throw new HttpRequestException("Request to renew tokens failed");
                var content = await result.Content.ReadAsStringAsync();
                var tokens = JsonConvert.DeserializeObject<DiscordTokens>(content);

                if(string.IsNullOrWhiteSpace(tokens.AccessToken) || string.IsNullOrWhiteSpace(tokens.RefreshToken))
                    throw new InvalidTokenException("Discord token response is invalid");

                await _tokenStore.SaveTokensAsync(userIdentification, tokens);

            }
        }
    }
}
