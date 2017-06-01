using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Extensions;
using DiscordRest.Models;
using DiscordRest.Utility;

namespace DiscordRest.Services.Implementations
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IDiscordHttpClient _httpClient;

        /// <inheritdoc />
        public UserService(IDiscordHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task<DiscordUser> GetCurrentAsync() => _httpClient.RunAsync<DiscordUser>(HttpMethod.Get, "/users/@me", null);

        /// <inheritdoc />
        public Task<DiscordUser> GetAsync(ulong id) => _httpClient.RunAsync<DiscordUser>(HttpMethod.Get, $"/users/{id}", null);

        /// <inheritdoc />
        public Task<DiscordUser> ModifyCurrentAsync() => throw new NotImplementedException();

        /// <inheritdoc />
        public Task<IEnumerable<UserGuild>> GetCurrentGuildsAsync() => _httpClient.RunAsync<IEnumerable<UserGuild>>(HttpMethod.Get, $"/users/@me/guilds", null);

        /// <inheritdoc />
        public Task<ServiceResult> LeaveGuildAsync(ulong guildId) => _httpClient.RunAsync(HttpMethod.Delete, $"/users/@me/guilds/{guildId}", null);

        /// <inheritdoc />
        public Task<IEnumerable<DMChannel>> GetDMsAsync() => _httpClient.RunAsync<IEnumerable<DMChannel>>(HttpMethod.Get, $"/users/@me/channels", null);

        /// <inheritdoc />
        public Task<DMChannel> CreateDMAsync(ulong toUser) => _httpClient.RunAsync<DMChannel>(HttpMethod.Post, $"/users/@me/channels", new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("recipient_id", toUser.ToString()) });

        //public Task<DMChannel> CreateGroupDMAsync(string[] tokens, Dictionary<ulong, string> nicks) => _httpClient.RunAsync<DMChannel>(HttpMethod.Post, $"/users/@me/channels", new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("recipient_id", toUser.ToString()) });
        //{
        //    throw new NotImplementedException();
        //}

        /// <inheritdoc />
        public Task<IEnumerable<DiscordConnection>> GetConnectionsAsync() => _httpClient.RunAsync<IEnumerable<DiscordConnection>>(HttpMethod.Post, $"/users/@me/channels", null);
    }
}
