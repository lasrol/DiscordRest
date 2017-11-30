using System;
using Newtonsoft.Json;

namespace DiscordRest.Data
{
    /// <summary>
    /// Model to hold token values
    /// </summary>
    public struct DiscordTokens
    {
        /// <summary>
        /// Access token to be used for authorization against discord
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token to renew the access token when it expires
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        ///     TimeSpan until the access token expires
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        ///     Token type could be 'Bearer' or 'Bot'
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}