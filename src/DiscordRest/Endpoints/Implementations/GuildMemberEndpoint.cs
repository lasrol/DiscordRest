using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordRest.Data;
using DiscordRest.Models;

namespace DiscordRest.Endpoints.Implementations
{
    /// <inheritdoc />
    public class GuildMemberEndpoint : IGuildMemberEndpoint
    {
        private readonly IDiscordHttpClient _httpClient;

        /// <inheritdoc />
        public GuildMemberEndpoint(IDiscordHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //TODO: Add optional parameters
        /// <inheritdoc />
        public Task<GuildMember> AddAsync(ulong id, ulong userId) =>
            _httpClient.RunAsync<GuildMember>(HttpMethod.Put, $"/guilds/{id}/members/{userId}", null);

        /// <inheritdoc />
        public Task<ServiceResult> AddToRoleAsync(ulong id, ulong userId, ulong roleId)
            => _httpClient.RunAsync(HttpMethod.Put, $"/guilds/{id}/members/{userId}/roles/{roleId}", null);

        /// <inheritdoc />
        public Task<GuildMember> GetAsync(ulong id, ulong userId)
            => _httpClient.RunAsync<GuildMember>(HttpMethod.Get, $"/guilds/{id}/members/{userId}", null);

        /// <inheritdoc />
        public Task<IEnumerable<GuildMember>> GetAsync(ulong id)
            => _httpClient.RunAsync<IEnumerable<GuildMember>>(HttpMethod.Get, $"/guilds/{id}/members", null);

        /// <inheritdoc />
        public Task<ServiceResult> ModifyAsync(ulong id, ulong userId)
            => throw new NotImplementedException();

        /// <inheritdoc />
        public Task<ServiceResult> ModifyCurrentUserNickAsync(ulong id)
            => throw new NotImplementedException();

        /// <inheritdoc />
        public Task<ServiceResult> RemoveAsync(ulong id, ulong userId)
            => _httpClient.RunAsync(HttpMethod.Delete, $"/guilds/{id}/members/{userId}", null);

        /// <inheritdoc />
        public Task<ServiceResult> RemoveFromRoleAsync(ulong id, ulong userId, ulong roleId)
            => _httpClient.RunAsync(HttpMethod.Delete, $"/guilds/{id}/members/{userId}/roles/{roleId}", null);
    }
}
