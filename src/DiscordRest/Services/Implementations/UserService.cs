using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

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
        public Task<DiscordUser> ModifyCurrentAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<IEnumerable<UserGuild>> GetCurrentGuildsAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ServiceResult> LeaveGuildAsync(ulong guildId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DMChannel>> GetDMsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DMChannel> CreateDMAsync(ulong toUser)
        {
            throw new NotImplementedException();
        }

        public Task<DMChannel> CreateGroupDMAsync(string[] tokens, Dictionary<ulong, string> nicks)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DiscordConnection>> GetConnectionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
