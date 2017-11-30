using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Models;
using DiscordRest.Data;

namespace DiscordRest
{
    /// <summary>
    /// Retriving and saving tokens used to communicate with discord API's
    /// </summary>
    public interface ITokenStore
    {
        /// <summary>
        ///     Gets the access token from the underlying store
        /// </summary>
        /// <param name="id">user identification</param>
        /// <returns>An access token</returns>
        Task<string> GetAccessTokenAsync(string id);

        /// <summary>
        ///     Gets the refresh token from the underlying store
        /// </summary>
        /// <param name="id">user identification</param>
        /// <returns>A refresh token</returns>
        Task<string> GetRefreshTokenAsync(string id);

        /// <summary>
        ///     Gets the access token expiration time in UTC time
        /// </summary>
        /// <param name="id">user identification</param>
        /// <returns>Expiration time in seconds</returns>
        Task<DateTime> GetExpiresAtAsync(string id);

        /// <summary>
        ///     Get the type of token, could be 'Bearer' or 'Bot'
        /// </summary>
        /// <param name="id">user identification</param>
        /// <returns>Token type</returns>
        Task<string> GetTokenTypeAsync(string id);

        /// <summary>
        ///     Saves the tokens provided in the model
        /// </summary>
        /// <param name="id">user identification</param>
        /// <param name="tokens">Model with values to save</param>
        Task SaveTokensAsync(string id, DiscordTokens tokens);
    }
}
