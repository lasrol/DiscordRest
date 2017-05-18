using System;

namespace DiscordRest.Models
{
    /// <summary>
    /// Model to hold token values
    /// </summary>
    public struct DiscordTokens
    {
        /// <summary>
        /// Access token to be used for authorization against discord
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token to renew the access token when it expires
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        ///     TimeSpan until the access token expires
        /// </summary>
        public TimeSpan? ExpiresIn { get; set; }

        /// <summary>
        ///     Token type could be 'Bearer' or 'Bot'
        /// </summary>
        public string TokenType { get; set; }
    }
}