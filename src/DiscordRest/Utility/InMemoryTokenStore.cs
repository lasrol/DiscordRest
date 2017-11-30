using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRest.Data;

namespace DiscordRest.Utility
{

    /// <summary>
    /// An InMemory implementation of the Token storage, used for testing
    /// </summary>
    public class InMemoryTokenStore : ITokenStore
    {
        private IDictionary<string, DiscordTokens> Tokens { get; set; }

        /// <summary>
        /// Default constructor for the InMemory Token store
        /// </summary>
        public InMemoryTokenStore()
        {
            Tokens = new Dictionary<string, DiscordTokens>();
        }

        /// <summary>
        /// Retrieve the stored access token
        /// </summary>
        /// <param name="id">id the token belongs to</param>
        public Task<string> GetAccessTokenAsync(string id)
        {
            if (!Tokens.ContainsKey(id))
                return Task.FromResult(string.Empty);

            return Task.FromResult(Tokens.SingleOrDefault(dt => dt.Key == id).Value.AccessToken);
        }

        public Task<int> GetExpiresInAsync(string id)
        {
            if (!Tokens.ContainsKey(id))
                return Task.FromResult(0);

            return Task.FromResult(Tokens.SingleOrDefault(dt => dt.Key == id).Value.ExpiresIn.GetValueOrDefault().Milliseconds);
        }

        public Task<string> GetRefreshTokenAsync(string id)
        {
            if (!Tokens.ContainsKey(id))
                return Task.FromResult(string.Empty);

            var tokens = Tokens.SingleOrDefault(dt => dt.Key == id).Value;

            return Task.FromResult(tokens.RefreshToken);
        }

        public Task<string> GetTokenTypeAsync(string id)
        {
            if (!Tokens.ContainsKey(id))
                return Task.FromResult(string.Empty);

            return Task.FromResult(Tokens.SingleOrDefault(dt => dt.Key == id).Value.TokenType);
        }

        public Task SaveTokensAsync(string id, DiscordTokens tokens)
        {
            if(string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            Tokens.Remove(id);
            Tokens.Add(id, tokens);

            return Task.FromResult(false);
        }
    }
}
