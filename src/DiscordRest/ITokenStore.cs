using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Models;

namespace DiscordRest
{
    public interface ITokenStore
    {
        /// <summary>
        ///     Gets the access token from the underlying store
        /// </summary>
        /// <returns>An access token</returns>
        Task<string> GetAccessTokenAsync();

        /// <summary>
        ///     Gets the refresh token from the underlying store
        /// </summary>
        /// <returns>A refresh token</returns>
        Task<string> GetRefreshTokenAsync();

        /// <summary>
        ///     Gets the access token expiration time in seconds
        /// </summary>
        /// <returns>Expiration time in seconds</returns>
        Task<int> GetExpiresInAsync();

        /// <summary>
        ///     Get the type of token, could be 'Bearer' or 'Bot'
        /// </summary>
        /// <returns>Token type</returns>
        Task<string> GetTokenTypeAsync();

        /// <summary>
        ///     Saves the tokens provided in the model
        /// </summary>
        /// <param name="tokens">Model with values to save</param>
        Task SaveTokensAsync(DiscordTokens tokens);
    }
}
